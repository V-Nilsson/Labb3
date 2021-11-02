using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Labb3.Commands;
using Labb3.Models;

namespace Labb3.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        private string _inputStatement;

        public string InputStatement
        {
            get { return _inputStatement; }
            set
            {
                _inputStatement = value;
                OnPropertyChanged(nameof(InputStatement));
            }
        }

        private string[] _inputAnswers;

        public string[] InputAnswers
        {
            get { return _inputAnswers; }
            set
            {
                _inputAnswers = value;
                OnPropertyChanged(nameof(InputAnswers));
            }
        }

        private string _inputCorrectAnswer;

        public string InputCorrectAnswer
        {
            get { return _inputCorrectAnswer; }
            set
            {
                _inputCorrectAnswer = value;
                OnPropertyChanged(nameof(InputCorrectAnswer));
            }
        }

        private string _inputTitle;

        public string InputTitle
        {
            get { return _inputTitle; }
            set
            {
                _inputTitle = value;
                OnPropertyChanged(nameof(InputTitle));
            }
        }

        private string _inputAnswer1;

        public string InputAnswer1
        {
            get { return _inputAnswer1; }
            set
            {
                _inputAnswer1 = value;
                OnPropertyChanged(nameof(InputAnswer1));
            }
        }

        private string _inputAnswer2;

        public string InputAnswer2
        {
            get { return _inputAnswer2; }
            set
            {
                _inputAnswer2 = value;
                OnPropertyChanged(nameof(InputAnswer2));
            }
        }

        private string _inputAnswer3;

        public string InputAnswer3
        {
            get { return _inputAnswer3; }
            set
            {
                _inputAnswer3 = value;
                OnPropertyChanged(nameof(InputAnswer3));
            }
        }

        private string _inputAnswer4;

        public string InputAnswer4
        {
            get { return _inputAnswer4; }
            set
            {
                _inputAnswer4 = value; 
                OnPropertyChanged(nameof(InputAnswer4));
            }
        }

        // Property to disable input´s for title
        private bool _titleIsNotSet;

        public bool TitleIsNotSet
        {
            get { return _titleIsNotSet; }
            set
            {
                _titleIsNotSet = value;
                OnPropertyChanged(nameof(TitleIsNotSet));
            }
        }

        private Quiz _newQuiz;

        public Quiz NewQuiz
        {
            get { return _newQuiz; }
            set
            {
                _newQuiz = value; 
                OnPropertyChanged(nameof(NewQuiz));
            }
        }

        public void CreateNewQuiz()
        {
            if (string.IsNullOrEmpty(InputTitle))
            {
                MessageBox.Show("You must enter a Title, please try again");
                return;
            }
            NewQuiz = new Quiz(InputTitle);
            AllQuizzes.Add(NewQuiz);
            TitleIsNotSet = false;
        }

        public void AddNewQuestion()
        {
            // if statement, answer 1- 3 is empty- error message! 
            // TODO Can I clean this up a little? Ugly code right now
            if (string.IsNullOrEmpty(InputStatement) || string.IsNullOrEmpty(InputAnswer1) || string.IsNullOrEmpty(InputAnswer2) || string.IsNullOrEmpty(InputAnswer3) || string.IsNullOrEmpty(InputCorrectAnswer))
            {
                MessageBox.Show("Invalid input, something is missing. Please try again");
                return;
            }

            string[] answers = new string[] { InputAnswer1, InputAnswer2, InputAnswer3, InputAnswer4 };
            //var newQuestion = new Question(InputStatement, InputAnswers, int.Parse(InputCorrectAnswer));

            bool CorrectInput = int.TryParse(InputCorrectAnswer, out int result);
            if (!CorrectInput || result > 4)
            {
                MessageBox.Show("Invalid input. Correct Answer must be a number between 1 - 4.\r\n " +
                                "Please change your input and press Add Question again");
            }
            else
            {
                NewQuiz.AddQuestion(InputStatement, (result - 1), answers);
                MessageBox.Show("The Question was added!");
                ClearInputTextBoxes();
            }
        }

        private void ClearInputTextBoxes()
        {
            InputStatement = string.Empty;
            InputAnswer1 = string.Empty;
            InputAnswer2 = string.Empty;
            InputAnswer3 = string.Empty;
            InputAnswer4 = string.Empty;
            InputCorrectAnswer = string.Empty;
        }

        public CreateViewModel()
        {
            LoadMyCollection();
            AddQuestionCommand = new AddQuestionCommand(this);
            CreateQuizCommand = new CreateNewQuizCommand(this);
            SaveQuizCommand = new SaveQuizCommand(this);
            TitleIsNotSet = true;
            NewQuiz = new Quiz();
        }

        public ICommand AddQuestionCommand { get; }

        public ICommand CreateQuizCommand { get; }

        public ICommand SaveQuizCommand { get; }
    }
}
