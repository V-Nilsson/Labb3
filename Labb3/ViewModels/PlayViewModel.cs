using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Labb3.Commands;

namespace Labb3.ViewModels
{
    public class PlayViewModel : ViewModelBase
    {

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
            // While we test Json loading:
            _ = LoadQuizzesAsync();
            // LoadQuizAsJson();


            SubmitAnswerCommand = new SubmitAnswerCommand(this);
            SetActiveQuizCommand = new SetActiveQuizCommand(this);
            SaveEditedQuizCommand = new SaveEditedQuizCommand(this);
            FinishedAQuiz = false;

            // From CreateViewModel:
            AddQuestionCommand = new AddQuestionCommand(this);
            CreateQuizCommand = new CreateNewQuizCommand(this);
            SaveQuizCommand = new SaveQuizCommand(this);
            TitleIsNotSet = true;
            NewQuiz = new Quiz();
        }

        private bool _finishedAQuiz;

        public bool FinishedAQuiz
        {
            get { return _finishedAQuiz; }
            set
            {
                _finishedAQuiz = value;
                //OnPropertyChanged(nameof(FinishedAQuiz));
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
                FinishedTheQuiz = $"Congratulations, you finished the quiz! You scored {Score} out of {AnsweredQuestions} \r\n" +
                                  $"To play again, switch to the Start tab and choose a Quiz";
            }
            else
            {
                CurrentQuestion = ActiveQuiz.GetRandomQuestion();
            }
        }
        public ICommand SubmitAnswerCommand { get; }

        public ICommand SetActiveQuizCommand { get; }

        public ICommand SaveEditedQuizCommand { get; }
        
        // <--- For our StartView --->

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

        // <--- For out CreateView --->

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
            // if answer 1- 3 is empty- error message! 
            if (string.IsNullOrEmpty(InputStatement) || string.IsNullOrEmpty(InputAnswer1) || string.IsNullOrEmpty(InputAnswer2) || string.IsNullOrEmpty(InputAnswer3) || string.IsNullOrEmpty(InputCorrectAnswer))
            {
                MessageBox.Show("Invalid input, something is missing. Please try again");
                return;
            }

            string[] answers = new string[] { InputAnswer1, InputAnswer2, InputAnswer3, InputAnswer4 };
            

            bool correctInput = int.TryParse(InputCorrectAnswer, out int result);
            if (!correctInput || result > 4)
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

        public ICommand AddQuestionCommand { get; }

        public ICommand CreateQuizCommand { get; }

        public ICommand SaveQuizCommand { get; }
    }


}

