using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Presentation
{
    public class RelayCommand : ICommand
    {
        #region Private Properties

        private Action myAction;

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor
        public RelayCommand(Action action)
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
            myAction();
        }

        #endregion
    }
}
