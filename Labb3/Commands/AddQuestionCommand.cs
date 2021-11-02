using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labb3.ViewModels;

namespace Labb3.Commands
{
    public class AddQuestionCommand : Command
    {
        private readonly CreateViewModel _createViewModel;

        public AddQuestionCommand(CreateViewModel createViewModel)
        {
            _createViewModel = createViewModel;
        }
        public override void Execute(object parameter)
        {
            _createViewModel.AddNewQuestion();
        }

        public override bool CanExecute(object parameter)
        {
            // return !string.IsNullOrEmpty(_createViewModel.InputStatement);

            return true;
        }
    }
}
