using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    /// <summary>
    /// CSVファイルをインポートする際に発生する例外をスローするためのクラス
    /// </summary>
    public class ImportDataException : Exception
    {

        public ImportDataException()
            : base("このファイルはインポートできません") { }
    }
}
