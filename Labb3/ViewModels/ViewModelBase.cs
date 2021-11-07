using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json;

namespace Labb3.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public ObservableCollection<Quiz> AllQuizzes { get; set; }

        public Quiz ActiveQuiz { get; set; }

        private Question _currentQuestion;

        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        public ViewModelBase()
        {
            AllQuizzes = new ObservableCollection<Quiz>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Finds available quizzes in the appdata\local folder\VictorsQuiz
        public async Task LoadQuizzesAsync()
        {
            // Gets the path to AppData
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            // path += "\\VictorsQuiz\\MyTestQuiz.csv";
            path += "\\VictorsQuiz";

            // If the folder for quizzes does not exist we can exit the method here
            if (!Directory.Exists(path))
            {
                return;
            }

            string[] savedQuizzes = Directory.GetFiles(path);

            await Task.Run(() =>
            {
                foreach (var quiz in savedQuizzes)
                {
                    using (var reader = new StreamReader(quiz))
                    {
                        var questionsToAdd = new ObservableCollection<Question>();
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var testing = line.Split(";");
                            string statement = testing[0];
                            string[] answers = testing[1].Split("¤");
                            int correctAnswer = int.Parse(testing[2]);
                            Question question = new Question(statement, answers, correctAnswer);
                            questionsToAdd.Add(question);
                        }

                        string title = quiz.Split("\\").Last();
                        title = title.Remove(title.Length - 4);
                        Quiz loadedQuiz = new Quiz(questionsToAdd, title);
                        AllQuizzes.Add(loadedQuiz);
                    }
                }
            });
        }
        
        public async Task SaveQuizAsync(Quiz quiz)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path += "\\VictorsQuiz\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += quiz.Title + ".csv";

            await Task.Run(() =>
            {
                using (var writer = new StreamWriter(path))
                {
                    foreach (var question in quiz.Questions)
                    {
                        string answers = "";
                        foreach (var answer in question.Answers)
                        {
                            answers += answer + "¤";
                        }
                        answers = answers.Remove(answers.Length - 1);

                        writer.WriteLine($"{question.Statement};{answers};{question.CorrectAnswer}");
                    }
                }
            });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //  <--- For our EditView --->

        private Quiz _quizToEdit;

        public Quiz QuizToEdit
        {
            get { return _quizToEdit; }
            set
            {
                _quizToEdit = value;
                OnPropertyChanged(nameof(QuizToEdit));
            }
        }

        private Question _questionToEdit;

        public Question QuestionToEdit
        {
            get { return _questionToEdit; }
            set
            {
                _questionToEdit = value;
                OnPropertyChanged(nameof(QuestionToEdit));
            }
        }
    }
}
