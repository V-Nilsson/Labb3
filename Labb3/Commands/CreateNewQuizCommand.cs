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
        private readonly CreateViewModel _createViewModel;

        public CreateNewQuizCommand(CreateViewModel createViewModel)
        {
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _createViewModel.CreateNewQuiz();
            //_createViewModel.TitleIsNotSet = false;
        }
    }
}
