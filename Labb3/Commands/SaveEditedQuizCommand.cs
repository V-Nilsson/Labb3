using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    class SaveEditedQuizCommand : Command
    {
        private readonly PlayViewModel _playViewModel;

        public SaveEditedQuizCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_playViewModel.QuizToEdit == null)
            {
                MessageBox.Show("Nope cant do that!");
                return;
            }

            _playViewModel.SaveQuizAsync(_playViewModel.QuizToEdit);
            MessageBox.Show("The Quiz has been edited and saved!");
        }
    }
}
