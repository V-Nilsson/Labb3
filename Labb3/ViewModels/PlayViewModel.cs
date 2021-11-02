using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Labb3.Commands;

namespace Labb3.ViewModels
{
    public class PlayViewModel : ViewModelBase
    {
        //private Question _currentQuestion;

        //public Question CurrentQuestion
        //{
        //    get { return _currentQuestion; }
        //    set
        //    {
        //        _currentQuestion = value;
        //        OnPropertyChanged(nameof(CurrentQuestion));
        //    }
        //}

        private string _selectedAnswer;

        public string SelectedAnswer
        {
            get { return _selectedAnswer; }
            set { _selectedAnswer = value; }
        }


        private int _score;

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                // varför använder vi här nameof? Kommer från Singelton Sean
                OnPropertyChanged(nameof(Score));
            }
        }

        private int _answeredQuestions;

        public int AnsweredQuestions
        {
            get { return _answeredQuestions; }
            set
            {
                _answeredQuestions = value;
                OnPropertyChanged(nameof(AnsweredQuestions));
            }
        }

        private string _finishedTheQuiz;

        public string FinishedTheQuiz
        {
            get { return _finishedTheQuiz; }
            set
            {
                _finishedTheQuiz = value;
                OnPropertyChanged(nameof(FinishedTheQuiz));
            }
        }

        private string _correctPercentage;

        public string CorrectPercentage
        {
            get { return _correctPercentage; }
            set
            {
                _correctPercentage = value;
                OnPropertyChanged(nameof(CorrectPercentage));
            }
        }


        public PlayViewModel()
        {
            // LoadMyCollection();
            // AllQuizzes = new ObservableCollection<Quiz>();
            LoadQuizzesAsync();
            Score = 0;
            AnsweredQuestions = 0;
            SubmitAnswerCommand = new SubmitAnswerCommand(this);
            SetActiveQuizCommand = new SetActiveQuizCommand(this);
            SaveEditedQuizCommand = new SaveEditedQuizCommand(this);
            FinishedAQuiz = false;
        }

        private bool _finishedAQuiz;

        public bool FinishedAQuiz
        {
            get { return _finishedAQuiz; }
            set
            {
                _finishedAQuiz = value;
                OnPropertyChanged(nameof(FinishedAQuiz));
            }
        }

        // Run when Submit Answer button is pressed. Evaluate if answer is correct, if so update Score. Update answered questions and CurrentQuestion
        public void SubmitAnswer()
        {
            if (SelectedAnswer == CurrentQuestion.Answers[CurrentQuestion.CorrectAnswer])
            {
                Score++;
            }

            AnsweredQuestions++;
            double correctAnswersDouble = ((double) Score / (double) AnsweredQuestions) * 100;
            CorrectPercentage = Math.Round(correctAnswersDouble, 0).ToString() + "%";

            
            if (AnsweredQuestions >= ActiveQuiz.Questions.Count)
            {
                CurrentQuestion = null;
                FinishedAQuiz = true;
                FinishedTheQuiz = $"Congratulations, you finished the quiz! You scored {Score} out of {AnsweredQuestions}";
            }
            else
            {
                CurrentQuestion = ActiveQuiz.GetRandomQuestion();
            }
            
            
        }
        public ICommand SubmitAnswerCommand { get; }

      
        public ICommand SetActiveQuizCommand { get; }

        public ICommand SaveEditedQuizCommand { get; }

        public void SetStartQuestion()
        {
            CurrentQuestion = ActiveQuiz.GetRandomQuestion();
        }

        public void SetActiveQuiz()
        {
            ActiveQuiz = SelectedQuiz;
            ActiveQuiz.AskedQuestions = new List<int>();
            Score = 0;
            AnsweredQuestions = 0;
            CorrectPercentage = String.Empty;
        }

        private Quiz _selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                OnPropertyChanged(nameof(SelectedQuiz));
            }
        }

    }
}
