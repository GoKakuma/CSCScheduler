using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    /// <summary>
    /// アプリケーションの機能を提供するためのクラスに継承されるための抽象クラス
    /// データ項目の値が変更されたときの検証や値が変化した際の通知、エラーインフォメーションの管理などの共通機能を実装するクラス
    /// </summary>
    abstract public class SchedulerLogicBase : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        ///INotifyPropertyChangedの実装
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発行するメソッド
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// IDataErrorInfoの実装
        /// </summary>
        abstract public string Error { get; }

        /// <summary>
        /// エラーコレクション変数
        /// </summary>
        protected readonly Dictionary<string, string> _errors =
            new Dictionary<string, string>();

        /// <summary>
        /// IDataErrorInfoの実装
        /// インデックスを受け取って対応する値を返す
        /// </summary>
        /// <param name="propertyName">キー</param>
        /// <returns>対応する値もしくはnull</returns>
        public string this[string propertyName]
        {
            get
            {
                // キーが存在する場合はその要素の値を返す
                // 存在しなければnull（条件演算子）
                return
                    _errors.ContainsKey(propertyName) ? 
                    _errors[propertyName] :
                    null;
            }
        }

        /// <summary>
        /// プロパティ名とプロパティの値を受け取って、各プロパティのエラー情報を更新するメソッド
        /// </summary>
        /// <param name="name">プロパティ名</param>
        /// <param name="value">プロパティ値</param>
        protected void UpdateErrors(string name, object value)
        {
            try
            {
                ValidationContext v = new ValidationContext(this, null, null);
                v.MemberName = name;
                Validator.ValidateProperty(value, v);
                _errors.Remove(name);
            }
            catch (Exception ex)
            {
                _errors[name] = ex.Message;
            }
        }
    }
}
