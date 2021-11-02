using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Labb3.Commands;
using Labb3.Models;

namespace Labb3.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        // Via valet i comboboxen så sätter vi en ActiveQuiz.
        //public Quiz ActiveQuiz { get; set; }

        //public StartViewModel()
        //{
        //    LoadMyCollection();
        //    //SetActiveQuiz();
        //    SetActiveQuizCommand = new SetActiveQuizCommand(this);
            
        //}

        //public ICommand SetActiveQuizCommand { get; set; }

        //public void SetStartQuestion()
        //{
        //    CurrentQuestion = ActiveQuiz.GetRandomQuestion();
        //}

        //public void SetActiveQuiz()
        //{
        //    ActiveQuiz = SelectedQuiz;
        //    //foreach (var quiz in AllQuizzes)
        //    //{
        //    //    if (quiz.Title.ToLower() == SelectedQuiz.ToLower())
        //    //    {
        //    //        ActiveQuiz = quiz;
        //    //    }
        //    //}
        //}

        //private Quiz _selectedQuiz;

        //public Quiz SelectedQuiz
        //{
        //    get { return _selectedQuiz; }
        //    set
        //    {
        //        _selectedQuiz = value;
        //        OnPropertyChanged(nameof(SelectedQuiz));
        //    }
        //}

    }
}
