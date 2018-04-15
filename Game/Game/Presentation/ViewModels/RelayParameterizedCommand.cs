using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Presentation
{
    public class RelayParameterizedCommand : ICommand
    {
        #region Private Properties

        private Action<object> myAction;

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor
        public RelayParameterizedCommand(Action<object> action)
        {
            myAction = action;
        }

        #endregion

        #region Command Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myAction(parameter);
        }

        #endregion
    }
}
