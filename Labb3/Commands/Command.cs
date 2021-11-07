using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Labb3.Commands
{
    public abstract class Command : ICommand
    {
       
        public event EventHandler CanExecuteChanged;
        // Set CanExecute to true here, with the possibility to change in the inheriting classes
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
