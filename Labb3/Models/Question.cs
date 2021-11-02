using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.Models
{
    public class Question
    {
        // TODO change back to get only properties
        public string Statement { get; set; }
        public string[] Answers { get; set; }

        // TESTING
        public string OneAnswer { get; set; }

        // TODO change to readonly?
        public int CorrectAnswer { get; }

        public Question(string statement, string[] answers, int correctAnswer)
        {
            Statement = statement;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public Question(){}
    }
}
