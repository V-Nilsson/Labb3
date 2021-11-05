using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labb3.Models;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    public class SubmitAnswerCommand : Command
    {
        private readonly PlayViewModel _playViewModel;

        public SubmitAnswerCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_playViewModel.CurrentQuestion == null)
            {
                MessageBox.Show("Please Select a Quiz to play");
                return;
            }
            _playViewModel.SubmitAnswer();
        }

        public override bool CanExecute(object parameter)
        {
            return !_playViewModel.FinishedAQuiz;
        }
    }
}
