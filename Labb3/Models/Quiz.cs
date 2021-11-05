using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.Models
{
    public class Quiz 
    {

        public ICollection<Question> Questions { get; }

        public string Title { get; }

        public List<int> AskedQuestions { get; set; }

        public Quiz(string title)
        {
            Questions = new ObservableCollection<Question>();
            AskedQuestions = new List<int>();
            Title = title;
        }

        public Quiz(ObservableCollection<Question> questions, string title)
        {
            Questions = questions;
            Title = title;
        }

        public Quiz()
        {
            Questions = new ObservableCollection<Question>();
            AskedQuestions = new List<int>();
        }

        public Question GetRandomQuestion()
        {
            int randomIndex = 0;
            Random rnd = new Random();
            randomIndex = rnd.Next(0, Questions.Count);
            while (AskedQuestions.Contains(randomIndex))
            {
                randomIndex = rnd.Next(0, Questions.Count);
            }
            AskedQuestions.Add(randomIndex);
            return Questions.ElementAt(randomIndex);
        }

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            var addedQuestion = new Question(statement, answers, correctAnswer);
            Questions.Add(addedQuestion);
        }

        public void RemoveQuestion(int index)
        {
            var removeQuestion = Questions.ElementAt(index);
            Questions.Remove(removeQuestion);
        }
    }
}
