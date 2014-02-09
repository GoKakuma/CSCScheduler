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
        /// <summary>
        /// コマンドを実行するためのメソッドへの参照を格納する変数
        /// 戻り値を返さない汎用デリゲート型
        /// </summary>
        private readonly Action<object> _execute;
        /// <summary>
        /// コマンドを実行できるかどうかを判定して結果を返すためのメソッドへの参照を格納する変数
        /// 戻り値を返さす汎用デリゲート型
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">実行するメソッド</param>
        /// <param name="canExecute">実行できるかを返すメソッド</param>
        public Command(Action<object> execute,
            Func<Object, bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute ?? new Func<object, bool>(x => true);  // 匿名メソッド
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">実行するメソッド</param>
        /// <param name="canExecute">実行できるかを返すメソッド</param>
        public Command(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = x => execute();
            _canExecute =
                canExecute == null ?
                new Func<object, bool>(x => true) :
                new Func<object, bool>(x => canExecute());    // 匿名メソッド
        }

        /// <summary>
        /// コマンドを実行するためのメソッド
        /// </summary>
        /// <param name="value">メソッド</param>
        public void Execute(object value) { _execute(value); }

        /// <summary>
        /// オブジェクトの状態（データ）を基に、そのコマンドが実行できるかを示す値を返すメソッド
        /// </summary>
        /// <param name="value">メソッド</param>
        /// <returns></returns>
        public bool CanExecute(object value) { return _canExecute(value); }
    }
}
