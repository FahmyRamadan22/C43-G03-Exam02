using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Questions;

namespace OOP_Exam.Exams
{
    internal class Final : ExamBase
    {
        public Final(int Time, int Number) : base(Time, Number)
        {

        }
        public override void ShowExam()
        {
            Console.WriteLine("Final Exam:");
            foreach (QuestionBase question in Questions)
            {
                question.DisplayQuestion();
                Console.WriteLine("---");
            }
        }
        public override void StartExam()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Clear();
            int userMark = 0;
            int totalMark = 0;
          
            
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].DisplayQuestion();
                Console.Write("Please Enter Right Answer Option Number : ");
                int userInput = int.Parse(Console.ReadLine());
              
                if (Questions[i].rightAnswer.AnswerId == userInput)
                    userMark += Questions[i].Mark;
                totalMark += Questions[i].Mark;
            }
           
            Console.WriteLine($"Your total mark is {userMark} / {totalMark} ");
            Console.WriteLine($"The Time Taken is {stopwatch.Elapsed} ");
        }
    }
}

