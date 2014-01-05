using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace CSCScheduler
{
    /// <summary>
    /// 確認メッセージなどのダイアログボックスを表示するためのクラス
    /// </summary>
    static public class Dialog
    {
        /// <summary>
        /// インフォメーションメッセージを表示するためのメッセージボックスを開く
        /// </summary>
        /// <param name="message">メッセージ</param>
        static public void ShowInfoMessage(string message)
        {
            MessageBox.Show(
                message,
                Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        static public bool IsExecuteMessageBox(string message)
        {
            return
                DialogResult.Yes ==
                    MessageBox.Show(
                        message,
                        Title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// エラーメッセージ専用のメッセージボックスを開く
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        static public void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(
                message,
                Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// 開きたいファイル名を返す
        /// </summary>
        /// <param name="title">ダイアログタイトル</param>
        /// <param name="filler">拡張子フィルタ</param>
        /// <returns>ファイル名</returns>
        static public string GetOpenFilename(string title, string filler)
        {
            using (OpenFileDialog x = new OpenFileDialog())
            {
                x.Filter = filler;
                x.Title = title;
                x.CheckPathExists = true;
                x.CheckFileExists = true;
                return (x.ShowDialog() == DialogResult.OK) ? x.FileName : null;
            }
        }

        /// <summary>
        /// 保存したいファイル名を返す
        /// </summary>
        /// <param name="title">ダイアログタイトル</param>
        /// <param name="filter">拡張子フィルタ</param>
        /// <returns>ファイル名</returns>
        static public string GetSaveFilename(string title, string filter)
        {
            using (SaveFileDialog x = new SaveFileDialog())
            {
                x.Filter = filter;
                x.Title = title;
                x.CheckPathExists = true;
                return (x.ShowDialog() == DialogResult.OK) ? x.FileName : null;
            }
        }

        static private string _title;
        static private string Title
        {
            get
            {
                if (string.IsNullOrEmpty(_title))
                {
                    _title = GetTitle();
                }
                return _title;
            }
        }

        /// <summary>
        /// 実行中のアプリケーションタイトルを取得する
        /// </summary>
        /// <returns>タイトル名</returns>
        static private string GetTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetFileNameWithoutExtension(assembly.CodeBase);
        }
    }
}
