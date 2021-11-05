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

        private readonly PlayViewModel _playViewModel;

        public AddQuestionCommand(PlayViewModel playViewModel)
        {
            _playViewModel = playViewModel;
        }

        public override void Execute(object parameter)
        {
            _playViewModel.AddNewQuestion();
        }

    }
}
