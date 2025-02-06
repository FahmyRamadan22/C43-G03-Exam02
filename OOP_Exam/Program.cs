using System.Diagnostics;
using OOP_Exam.Exams;
using OOP_Exam.Questions;

namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Take The Subject Name and Id From User

            bool IsParsed01, IsParsed02;

            int numberOfQuestions, time, optionsCount, correctOption, userAnswer, mark;

            Console.WriteLine("Welcome in Examination system :) ");
            Console.Write("Please Enter Subject Name : ");

            string SubjectName = Console.ReadLine()!;
            Console.Write("Please Enter Subject ID : ");

            IsParsed01 = int.TryParse(Console.ReadLine(), out int SubjectID);
            Subject subject01;

            if (IsParsed01 && SubjectName is not null)
            {
                subject01 = new Subject(SubjectID, SubjectName);
            }
            else
            {
                Console.WriteLine("Invalid Subject Name and ID ");
                return;
            }


            #endregion
            #region Take The Time and Number Of Questions

            do
            {
                Console.Clear();
                Console.Write("Enter Time Of The Exam : ");

                IsParsed02 = int.TryParse(Console.ReadLine(), out time);
                Console.WriteLine("Enter Number Of Questions");

                IsParsed01 = int.TryParse(Console.ReadLine(), out numberOfQuestions);
            } while (!IsParsed02 || !IsParsed01);
            Console.Clear();
            #endregion
            #region Take The Exam Type

            Console.WriteLine("Choose The Exam  [1] Practical , [2] Final");
            IsParsed01 = int.TryParse(Console.ReadLine(), out int userExam);

            ExamBase exam;

            if (IsParsed01 && userExam == 1 && time > 0)
            {
                exam = new Practical(time, numberOfQuestions);
            }
            else if (IsParsed01 && userExam == 2 && time > 0)
            {
                exam = new Final(time, numberOfQuestions);
            }
            else
            {
                Console.WriteLine("Invalid Exam");
                return;
            }
            Console.Clear();
            #endregion
            #region Create The Exam

            for (int i = 0; i < numberOfQuestions; i++)
            {
                //first take Header,body,mark 
                Console.WriteLine($"Enter details for Question {i + 1}:");
                Console.Write("Header: ");
                string header = Console.ReadLine();

                Console.Write("Body: ");
                string body = Console.ReadLine();

                do
                {
                    Console.Write("Mark: ");
                    IsParsed01 = int.TryParse(Console.ReadLine(), out mark);
                } while (!IsParsed01);
                //based on exam type 
                if (exam is Practical)
                {
                    //practical exam only allows MCQ
                    do
                    {
                        Console.Write("Enter number of options: ");
                        IsParsed01 = int.TryParse(Console.ReadLine(), out optionsCount);
                    } while (!IsParsed01);
                    //to make the user free to enter any number of options
                    Mcq mcqQuestion = new Mcq(header, body, mark, optionsCount);
                    //take options from the user
                    for (int j = 0; j < optionsCount; j++)
                    {
                        Console.Write($"Enter option {j + 1}: ");
                        mcqQuestion.answers[j] = new Answer(j + 1, Console.ReadLine());
                    }
                    //take the rightAnswer option
                    do
                    {
                        Console.Write("Enter the number of the correct option: ");
                        IsParsed02 = int.TryParse(Console.ReadLine(), out correctOption);
                    } while (!IsParsed02);
                    //add rightAnswer to his property
                    mcqQuestion.rightAnswer = mcqQuestion.answers[correctOption - 1];
                    //Add Question in exam
                    exam.Questions[i] = mcqQuestion;
                    Console.Clear();
                }
                else
                {
                    // Final Exam allows both True/False and MCQ
                    Console.Write("Enter type (1 for True/False, 2 for MCQ): ");
                    int type = int.Parse(Console.ReadLine());

                    if (type == 1) // True/False Question
                    {
                        TrueOrFalse tfQuestion = new TrueOrFalse(header, body, mark);
                        tfQuestion.answers[0] = new Answer(1, "True");
                        tfQuestion.answers[1] = new Answer(2, "False");

                        do
                        {
                            Console.Write("Enter the correct answer \n1.True\n2.False : ");
                            IsParsed02 = int.TryParse(Console.ReadLine(), out correctOption);
                        } while (!IsParsed02);
                        if (correctOption == 1)
                        {
                            tfQuestion.rightAnswer = tfQuestion.answers[0];
                        }
                        else if (correctOption == 2)
                        {
                            tfQuestion.rightAnswer = tfQuestion.answers[1];
                        }
                        else
                        {
                            Console.WriteLine("Invalid answer entered. Defaulting to 'True'");
                            tfQuestion.rightAnswer = tfQuestion.answers[0];
                        }

                        exam.Questions[i] = tfQuestion;
                    }

                    else if (type == 2)
                    {
                        do
                        {
                            Console.Write("Enter number of options: ");
                            IsParsed01 = int.TryParse(Console.ReadLine(), out optionsCount);
                        } while (!IsParsed01);

                        Mcq mcqQuestion = new Mcq(header, body, mark, optionsCount);

                        for (int j = 0; j < optionsCount; j++)
                        {
                            Console.Write($"Enter option {j + 1}: ");
                            mcqQuestion.answers[j] = new Answer(j + 1, Console.ReadLine()); //j=0 //op=1 id=1
                        }

                        Console.Write("Enter the number of the correct option: ");
                        correctOption = int.Parse(Console.ReadLine());

                        mcqQuestion.rightAnswer = mcqQuestion.answers[correctOption - 1];

                        exam.Questions[i] = mcqQuestion;
                    }
                    Console.Clear();
                }
            }
            //associate the exam with the subject
            subject01.CreateExam(exam);
            Console.Clear();


            #endregion
            #region Start The Exam
            Console.Write("Do you want to start the exam? (yes/no): ");
            string startExam = Console.ReadLine();
            if (startExam.ToLower() == "yes")
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                int totalScore = 0;
                int TotalMark = 0;
                for (int i = 0; i < exam.Questions.Length; i++)
                {
                    QuestionBase question = exam.Questions[i];
                    question.DisplayQuestion();
                    do
                    {
                        Console.Write("Your answer Option: ");
                        IsParsed01 = int.TryParse(Console.ReadLine(), out userAnswer);
                    } while (!IsParsed01);

                    if (question.rightAnswer.AnswerId == userAnswer)
                    {
                        totalScore += question.Mark;
                    }
                    TotalMark += question.Mark;
                }



                stopwatch.Stop();
                Console.Clear();
                Console.WriteLine("\nExam Completed!");
                Console.WriteLine("Right Answers : ");
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine($"{exam.Questions[i].Header}: {exam.Questions[i].rightAnswer}");
                }

                if (exam is Final)
                {


                    Console.WriteLine($"\nYour Grade is: {totalScore} from {TotalMark}");
                }


                if (stopwatch.Elapsed.TotalMinutes > time)
                {
                    Console.WriteLine("You have exceeded the exam time");
                }
                Console.WriteLine($"Time Taken: {stopwatch.Elapsed.TotalMinutes:F2} minutes");
                Console.WriteLine("Thank you For your effort,Keep Going :) ");

            }
            #endregion
        }
    }
}

