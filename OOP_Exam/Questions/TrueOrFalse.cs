using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal class TrueOrFalse : QuestionBase
    {

        public TrueOrFalse(string header, string body, int mark) : base(header, body, mark, 2)
        {

        }


        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} \n1.True\n2.False");
        }

    }
}

