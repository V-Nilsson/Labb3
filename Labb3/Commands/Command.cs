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

        // Vi sätter CanExecute till true här, med möjligheten att ändra i klasserna som ärver
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);


        // Taget från Singelton Sean, lite osäker på vad detta gör :|
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
