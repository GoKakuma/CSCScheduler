using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    /// <summary>
    /// スケジュール管理アプリケーションのデータの保持や検証、コマンドを処理するためのロジックを実装するクラス
    /// スケジュール管理アプリケーションの本体
    /// </summary>
    sealed public class CSCSchedulerLogic : SchedulerLogicBase, IDisposable
    {
        #region フィールドメンバー
        /// <summary>
        /// Filterプロパティに格納するための定数
        /// </summary>
        private const string CSV_FILTER = "CSV ファイル(*.csv)|*.csv|" + "テキスト ファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";

        /// <summary>
        /// 
        /// </summary>
        private readonly CSCScheduleDataClassesDataContext _dataContext;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public CSCSchedulerLogic()
        {
            _dataContext = new CSCScheduleDataClassesDataContext(); 
            FillItems();
        }
        #endregion

        #region Dispose メソッド
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _dataContext.Dispose(); // _dataContextオブジェクトの解放
        }
        #endregion
        
        #region エラープロパティ
        /// <summary>
        /// エラープロパティ
        /// </summary>
        public override string Error
        {
            get
            {
                if (_errors.Count > 0)
                {
                    return "入力されている値が正しくありません";
                }
                if (Id == 0 && IsFinished)
                {
                    return "新規タスクは、最初から「済み」に設定できません";
                }
                return null;
            }
        }
        #endregion

        #region クリア
        /// <summary>
        /// クリアコマンド
        /// </summary>
        private Command _clearCommand;
        /// <summary>
        /// クリアコマンドプロパティ
        /// </summary>
        public Command ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new Command(ExecuteClearCommand);
                }
                return _clearCommand;
            }
        }

        /// <summary>
        /// キーワードをクリアして全てのタイトルを表示する
        /// </summary>
        private void ExecuteClearCommand()
        {
            Keyword = string.Empty;
            FillItems();
        }
        #endregion

        #region 検索
        /// <summary>
        /// 検索コマンド
        /// </summary>
        private Command _searchCommand;
        /// <summary>
        /// 検索コマンドプロパティ
        /// </summary>
        public Command SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new Command(ExecuteSearchCommand);
                }
                return _searchCommand;
            }
        }

        /// <summary>
        /// キーワードを含むスケジュールをリストい表示する
        /// </summary>
        private void ExecuteSearchCommand()
        {
            FillItems(Keyword);
        }
        #endregion

        #region 新規コマンドプロパティ
        /// <summary>
        /// 新規コマンド
        /// </summary>
        private Command _addNewCommand;
        /// <summary>
        /// 新規コマンドプロパティ
        /// </summary>
        public Command AddNewCommand
        {
            get
            {
                if (_addNewCommand == null)
                {
                    _addNewCommand = new Command(ExecuteAddNewCommand);
                }
                return _addNewCommand;
            }
        }

        /// <summary>
        /// 新規データを選択する
        /// </summary>
        private void ExecuteAddNewCommand()
        {
            Item = Items[0];
        }
        #endregion

        #region 更新コマンドプロパティ
        /// <summary>
        /// 更新コマンド
        /// </summary>
        private Command _updateCommand;
        /// <summary>
        /// 更新コマンドプロパティ
        /// </summary>
        public Command UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new Command(
                        ExecuteUpdateCommand, CanExecuteUpdateCommand);
                }
                return _updateCommand;
            }
        }

        /// <summary>
        /// 編集中のデータをデータベースに保存する
        /// </summary>
        private void ExecuteUpdateCommand()
        {
            Action action =
                (Id == 0) ?
                    new Action(InsertRecord) :
                    new Action(UpdateRecord);
            action();
            return;
        }

        /// <summary>
        /// Updateコマンドが実行できる状態かを返す
        /// </summary>
        /// <returns>bool値</returns>
        private bool CanExecuteUpdateCommand()
        {
            return string.IsNullOrEmpty(Error);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertRecord()
        {
            CSCSchedule schedule = new CSCSchedule();
            GetDataPropertyValues(schedule);
            _dataContext.CSCSchedule.InsertOnSubmit(schedule);
            _dataContext.SubmitChanges();
            Items.Add(schedule);
            Item = schedule;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateRecord()
        {
            GetDataPropertyValues(Item);
            _dataContext.SubmitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        private void GetDataPropertyValues(CSCSchedule schedule)
        {
            schedule.Id = Id;
            schedule.Title = Title;
            schedule.Contents = Contents;
            schedule.Limit = Limit;
            schedule.IsFinished = IsFinished;
        }

        #endregion

        #region 削除コマンドプロパティ
        /// <summary>
        /// 削除コマンド
        /// </summary>
        private Command _deleteCommand;
        /// <summary>
        /// 削除コマンドプロパティ
        /// </summary>
        public Command DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new Command(
                        ExecuteDeleteCommand, CanExecuteDeleteCommand);
                }
                return _deleteCommand;
            }
        }

        /// <summary>
        /// 実行を確認後にデータを削除する
        /// </summary>
        private void ExecuteDeleteCommand()
        {
            const string message = "削除して良いですか？";
            if (!Dialog.IsExecuteMessageBox(message)) return;

            _dataContext.CSCSchedule.DeleteOnSubmit(Item);
            _dataContext.SubmitChanges();

            int i = Items.IndexOf(Item);
            Items.Remove(Item);

            Item = (i < Items.Count) ? Items[i] : Items[i - 1];
        }

        /// <summary>
        /// 新規でないかつ済みマークがオンであればtrueを返す
        /// </summary>
        /// <returns>bool値</returns>
        private bool CanExecuteDeleteCommand()
        {
            return (Id != 0) && (IsFinished);
        }
        #endregion

        #region 済み削除コマンドプロパティ
        /// <summary>
        /// 削除コマンド
        /// </summary>
        private Command _autoDeleteCommand;
        /// <summary>
        /// 済み削除コマンドプロパティ
        /// </summary>
        public Command AutoDeleteCommand
        {
            get
            {
                if (_autoDeleteCommand == null)
                {
                    _autoDeleteCommand = new Command(ExecuteAutoDeleteCommand);
                }
                return _autoDeleteCommand;
            }
        }

        /// <summary>
        /// 実行確認した後、済みマークの付いたデータをまとめて削除する
        /// </summary>
        private void ExecuteAutoDeleteCommand()
        {
            const string message = "済みマークの付いているタスクを削除して良いですか？";
            if (!Dialog.IsExecuteMessageBox(message)) return;

            _dataContext.ExecuteCommand("DELETE FROM CSCSchedule WHERE IsFinished = 1");
            FillItems();
        }
        #endregion

        #region インポートコマンドプロパティ
        /// <summary>
        /// 
        /// </summary>
        private Command _importCommand;
        /// <summary>
        /// 
        /// </summary>
        public Command ImportCommand
        {
            get
            {
                if (_importCommand == null)
                {
                    _importCommand = new Command(ExecuteImportCommand);
                }
                return _importCommand;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteImportCommand()
        {
            string message = "インポートしたいファイルを選択して下さい";
            string filter = CSV_FILTER;
            string filename = Dialog.GetOpenFilename(message, filter);
            if (string.IsNullOrEmpty(filename)) return;
            try
            {
                CsvFile.Import(filename);
                Dialog.ShowInfoMessage("インポート完了！");
                FillItems();
            }
            catch (Exception ex)
            {
                Dialog.ShowErrorMessageBox(ex.Message);
            }
        }
        #endregion

        #region エクスポートコマンドプロパティ
        /// <summary>
        /// 
        /// </summary>
        private Command _executeExportCommand;
        public Command ExportCommand
        {
            get
            {
                if (_executeExportCommand == null)
                {
                    _executeExportCommand = new Command(ExecuteExportCommand);
                }
                return _executeExportCommand;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExecuteExportCommand()
        {
            string message = "エクスポートしたいファイルを選択して下さい";
            string filter = CSV_FILTER;
            string filename = Dialog.GetSaveFilename(message, filter);
            if (string.IsNullOrEmpty(filename)) return;
            try
            {
                CsvFile.Export(filename);
                Dialog.ShowInfoMessage("エクスポート完了！");
            }
            catch (Exception ex)
            {
                Dialog.ShowErrorMessageBox(ex.Message);
            }
        }
        #endregion

        // データプロパティ

        #region keyword プロパティ
        /// <summary>
        /// 
        /// </summary>
        private string _keyword;
        public string Keyword
        {
            get
            {
                return _keyword;
            }
            set
            {
                _keyword = value;
                OnPropertyChanged("Keyword");
            }
        }
        #endregion

        #region Items プロパティ
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<CSCSchedule> _items = new ObservableCollection<CSCSchedule>();
        public ObservableCollection<CSCSchedule> Items
        {
            get
            {
                return _items;
            }
        }
        #endregion

        #region Item プロパティ
        /// <summary>
        /// 
        /// </summary>
        private CSCSchedule _item;
        public CSCSchedule Item
        {
            get
            {
                return _item;
            }
            set
            {
                if (value == null) return;
                _item = value;
                Id = _item.Id;
                Title = _item.Title;
                Contents = _item.Contents;
                Limit = _item.Limit ?? DateTime.Today;

                IsFinished = _item.IsFinished ?? false;
                OnPropertyChanged("Item");
            }

         }
        #endregion

        #region Id プロパティ
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        #endregion

        #region Title プロパティ
        /// <summary>
        /// Titleプロパティ
        /// </summary>
        private string _title;
        [Required(ErrorMessage = "タイトルを入力してください")]
        [StringLength(32, ErrorMessage = "32文字以内で入力してください")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                UpdateErrors("Title", value); 
                OnPropertyChanged("Title");
            }
        }
        #endregion

        #region Contents プロパティ
        /// <summary>
        /// Contents プロパティ
        /// </summary>
        private string _contents;
        [StringLength(32, ErrorMessage = "32文字以内で入力してください")]
        public string Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
                UpdateErrors("Contents", value); 
                OnPropertyChanged("Contents");
            }
        }
        #endregion

        #region Limit プロパティ
        /// <summary>
        /// 
        /// </summary>
        private DateTime _limit;
        public DateTime Limit
        {
            get
            {

                return _limit;
            }
            set
            {
                _limit = value;
                OnPropertyChanged("Limit");
            }
        }
        #endregion

        #region IsFinished プロパティ
        /// <summary>
        /// 
        /// </summary>
        private bool _isFinished;
        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }
            set
            {
                _isFinished = value;
                OnPropertyChanged("IsFinished");
            }
        }
        #endregion
        
        #region FillItems メソッド
        /// <summary>
        /// 指定されたタイトルを含むデータをデータベースから読み込んでItemプロパティに格納する
        /// </summary>
        /// <param name="keyword">タイトル</param>
        private void FillItems(String keyword = null)
        {
            string k = (keyword ?? string.Empty).Trim();
            var q =
                from p in _dataContext.CSCSchedule
                where p.Title.Contains(k)
                orderby p.Id descending
                select p;

            Items.Clear();
            CSCSchedule newSchedule = new CSCSchedule { Title = "(新規)" };
            Items.Add(newSchedule);
            foreach (var x in q)
            {
                Items.Add(x);
            }
            Item = Items[0];
        }
        #endregion
    }
}
