namespace SmarterVoter.Quizzes
{
    public class Question
    {
        public string Text { get; set; }

        public Bias Bias { get; set; }

        public List<string> PossibleAnswers { get; set; }

        public string Answer { get; set; }

        public Question(string text, Bias bias, List<string> possibleAnswers, string answer)
        {
            Text = text;
            Bias = bias;
            PossibleAnswers = possibleAnswers;
            Answer = answer;
        }

        public bool Evaluate(string attemptedAnswer)
        {
            return attemptedAnswer == Answer;
        }
    }
}
