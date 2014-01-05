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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        abstract public string Error { get; }

        protected readonly Dictionary<string, string> _errors =
            new Dictionary<string, string>();
        public string this[string propertyName]
        {
            get
            {
                return
                    _errors.ContainsKey(propertyName) ?
                    _errors[propertyName] :
                    null;
            }
        }

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
