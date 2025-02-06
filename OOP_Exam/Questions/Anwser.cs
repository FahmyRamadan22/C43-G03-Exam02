using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal class Anwser
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }


        public Anwser (int Id, string AnswerText)
        {
            AnswerId = Id;
            this.AnswerText = AnswerText;
        }


        public override string ToString()
        {
            return AnswerText;
        }

    }
}
