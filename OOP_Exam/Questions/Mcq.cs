using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal class Mcq : QuestionBase
    {
        public Mcq(string header, string body, int mark, int answerCount) : base(header, body, mark, answerCount)
        {

        }


        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body}");
           
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {answers[i].AnswerText}");
            }
        }

    }
}

