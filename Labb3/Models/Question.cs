using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3.Models
{
    public class Question
    {
        
        public string Statement { get; set; }
        public string[] Answers { get; set; }

        
        public int CorrectAnswer { get; set; }

        public Question(string statement, string[] answers, int correctAnswer)
        {
            Statement = statement;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
        
        
    }
}
