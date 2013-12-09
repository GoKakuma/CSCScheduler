using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCScheduler
{
    public class WindowsFormsCommandBindings
    {
        private List<Action> _resetEnabledActions;

        public WindowsFormsCommandBindings()
        {
            _resetEnabledActions = new List<Action>();
        }

        public void AddCommand(dynamic control, Command command)
        {
            Action a = () => control.Enabled = command.CanExecute(null);
            _resetEnabledActions.Add(a);

            EventHandler handler = (s, e) => command.Execute(null);
            control.Click += new EventHandler(handler);
        }

        public void RefreshControlEnabled()
        {
            foreach (Action x in _resetEnabledActions) x();
        }
    }
}
