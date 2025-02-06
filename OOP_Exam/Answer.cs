namespace OOP_Exam
{
    internal class Answer
    {
        internal int AnswerId;
        private int v1;
        private string? v2;

        public Answer(int v1, string? v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public object AnswerText { get; internal set; }
    }
}