using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    /// <summary>
    /// 各コマンドのロジックと、各コマンドが実行できるかどうかを判定するロジックを実装するクラス
    /// </summary>
    public class Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> execute,
            Func<Object, bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute ?? new Func<object, bool>(x => true);
        }

        public Command(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = x => execute();
            _canExecute =
                canExecute == null ?
                new Func<object, bool>(x => true) :
                new Func<object, bool>(x => canExecute());
        }

        public void Execute(object value) { _execute(value); }
        public bool CanExecute(object value) { return _canExecute(value); }
    }
}
