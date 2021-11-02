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
        private readonly CreateViewModel _createViewModel;

        public SaveQuizCommand(CreateViewModel createViewModel)
        {
            _createViewModel = createViewModel;
        }


        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_createViewModel.NewQuiz.Title))
            {
                MessageBox.Show("You must enter a title and press Create Quiz before saving");
                return;
            }
            _createViewModel.SaveQuizAsync(_createViewModel.NewQuiz);
            MessageBox.Show("The Quiz was successfully saved!");
            _createViewModel.NewQuiz = new Quiz();
            _createViewModel.TitleIsNotSet = true;
            _createViewModel.InputTitle = string.Empty;
        }
    }
}
