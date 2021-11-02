using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    public class SetActiveQuizCommand : Command
    {
       
        private readonly PlayViewModel _playViewModel;

        public SetActiveQuizCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_playViewModel.SelectedQuiz == null)
            {
                MessageBox.Show("You have not chosen a quiz");
                return;
            }
            _playViewModel.SetActiveQuiz();
            _playViewModel.SetStartQuestion();
            _playViewModel.FinishedAQuiz = false;
            _playViewModel.FinishedTheQuiz = String.Empty;
            MessageBox.Show("The quiz has been chosen, now switch to the play tab");
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
