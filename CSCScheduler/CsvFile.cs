using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CSCScheduler
{
    /// <summary>
    /// インポートやエクスポートのコマンドが実行されたときに使用するクラス
    /// DBに格納されているデータをCSVに出力したり、CSVファイルのデータをDBに挿入する機能を実装
    /// </summary>
    static public class CsvFile
    {
        #region メソッド
        /// <summary>
        /// 引数として受け取ったファイルのデータを、アプリケーションのデータとして追加登録する
        /// </summary>
        /// <param name="filename">ファイル名</param>
        static public void Import(string filename)
        {
            IEnumerable<CSCSchedule> schedules = GetImportCSCSchedules(filename);
            using (CSCScheduleDataClassesDataContext d = 
                new  CSCScheduleDataClassesDataContext())
            {
                foreach (CSCSchedule x in schedules) d.CSCSchedule.InsertOnSubmit(x);
                d.SubmitChanges();
            }

        }

        /// <summary>
        /// 指定されたファイルからスケジュールデータを取得する
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns>スケジュールデータ</returns>
        static private IEnumerable<CSCSchedule> GetImportCSCSchedules(string filename)
        {
            List<CSCSchedule> list = new List<CSCSchedule>();
            Encoding encode = Encoding.GetEncoding("Shift_Jis");
            using (TextFieldParser p = new TextFieldParser(filename, encode))
            {
                p.TextFieldType = FieldType.Delimited;
                p.SetDelimiters(",");
                p.HasFieldsEnclosedInQuotes = true;
                p.TrimWhiteSpace = false;
                while (!p.EndOfData)
                {
                    string[] a = p.ReadFields();
                    CSCSchedule schedule = CreateCSCSchedule(a);
                    list.Add(schedule);
                }
            }
            return list;
        }

        /// <summary>
        /// 指定された文字配列の値からCSCScheduleオブジェクトを作成する
        /// </summary>
        /// <param name="fields">文字列配列</param>
        /// <returns>CSCScheduleオブジェクト</returns>
        static private CSCSchedule CreateCSCSchedule(string[] fields)
        {
            if (fields.Length != 4) throw new ImportDataException();
            var q = from x in fields where x == null select x;
            if (q.Any()) throw new ImportDataException();
            CSCSchedule schedule = new CSCSchedule();

            schedule.Title = fields[0].TrimEnd();
            if (schedule.Title.Length == 0 || schedule.Title.Length > 32)
                throw new ImportDataException();

            schedule.Contents = fields[1].TrimEnd();
            if (schedule.Contents.Length > 32)
                throw new ImportDataException();

            DateTime d;
            if (!DateTime.TryParse(fields[2], out d))
                throw new ImportDataException();
            schedule.Limit = d;

            bool b;
            if (!bool.TryParse(fields[3], out b))
                throw new ImportDataException();
            schedule.IsFinished = b;

            return schedule;
        }

        /// <summary>
        /// 引数として受け取ったファイルに対して、アプリケーションのデータを出力する
        /// </summary>
        /// <param name="filename">ファイル名</param>
        static public void Export(string filename)
        {
            Encoding encode = Encoding.GetEncoding("Shift_Jis");
            using (StreamWriter w = new StreamWriter(filename, false, encode))
            {
                using (CSCScheduleDataClassesDataContext d = 
                    new CSCScheduleDataClassesDataContext())
                {
                    foreach (CSCSchedule x in d.CSCSchedule)
                    {
                        string s = string.Format(
                            "\"{0}\",\"{1}\",\"{2}\",{3}",
                            x.Title,
                            x.Contents,
                            x.Limit.Value.ToString("yyyy/MM/dd"),
                            x.IsFinished);
                        w.WriteLine(s);
                    }
                }
            }

        }
        #endregion
    }
}
