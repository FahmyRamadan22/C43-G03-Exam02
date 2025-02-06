namespace OOP_Exam.Questions
{
    internal abstract class QuestionBase
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] answers { get; set; }
        public Answer rightAnswer { get; set; }



        public QuestionBase(string header, string body, int mark, int answerCount)
        {
            Header = header;
            Body = body;
            Mark = mark;
            answers = new Answer[answerCount];
        }


        abstract public void DisplayQuestion();



    }
}

