using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Questions;

namespace OOP_Exam.Exams
{
    internal abstract class ExamBase
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionBase[] Questions { get; set; }


        public ExamBase(int time, int number)
        {
            this.Time = time;
            this.NumberOfQuestions = number;
            Questions = new QuestionBase[NumberOfQuestions];
        }


        public abstract void ShowExam();
        public abstract void StartExam();



    }
}
