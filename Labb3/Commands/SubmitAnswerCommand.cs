using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _playViewModel.SubmitAnswer();
        }

        public override bool CanExecute(object parameter)
        {
            //return _playViewModel.CurrentQuestion != null;
            return !_playViewModel.FinishedAQuiz;
            //return true;
        }
    }
}
