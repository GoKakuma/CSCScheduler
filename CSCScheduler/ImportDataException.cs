using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    public class ImportDataException : Exception
    {
        public ImportDataException()
            : base("このファイルはインポートできません") { }
    }
}
