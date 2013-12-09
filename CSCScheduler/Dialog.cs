using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace CSCScheduler
{
    static public class Dialog
    {
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

        static public void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(
                message,
                Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

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

        static private string GetTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetFileNameWithoutExtension(assembly.CodeBase);
        }
    }
}
