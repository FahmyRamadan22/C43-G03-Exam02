using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Exams;

namespace OOP_Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public ExamBase Exam { get; set; }

        public Subject (int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        public void CreateExam(ExamBase exam)
        {
            Exam = exam;
        }
    }
}

