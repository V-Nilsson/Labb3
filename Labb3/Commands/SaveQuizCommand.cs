using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labb3.Models;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    class SaveQuizCommand : Command
    {

        private readonly PlayViewModel _playViewModel;

        public SaveQuizCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_playViewModel.NewQuiz.Title))
            {
                MessageBox.Show("You must enter a title and press Create Quiz before saving");
                return;
            }
            _ = _playViewModel.SaveQuizAsync(_playViewModel.NewQuiz);
            //_playViewModel.SaveQuizAsJson(_playViewModel.NewQuiz);
            MessageBox.Show("The Quiz was successfully saved!");
            _playViewModel.NewQuiz = new Quiz();
            _playViewModel.TitleIsNotSet = true;
            _playViewModel.InputTitle = string.Empty;
        }

    }
}
