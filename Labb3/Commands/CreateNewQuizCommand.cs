using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    class CreateNewQuizCommand : Command
    {

        private readonly PlayViewModel _playViewModel;

        public CreateNewQuizCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            _playViewModel.CreateNewQuiz();
        }
    }
}
