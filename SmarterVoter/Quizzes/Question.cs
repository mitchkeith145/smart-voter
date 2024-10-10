namespace SmarterVoter.Quizzes
{
    public enum QuestionBias
    {
        LeftLean,
        Neutral,
        RightLean
    }
    public class PoliticalQuestion
    {
        public QuestionBias Bias { get; set; }
        public int Level { get; set; }
        public string QuestionText { get; set; }
        public string Background { get; set; }
        public string Source { get; set; }
        public List<string> MultipleChoices { get; set; }
        public int CorrectAnswerNumber { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public PoliticalQuestion(QuestionBias bias, string questionText, string background, string sourceURL, List<string> multipleChoices, int correctAnswerNumber)
        {
            Bias = bias;
            QuestionText = questionText;
            Background = background;
            Source = sourceURL;
            MultipleChoices = multipleChoices;
            CorrectAnswerNumber = correctAnswerNumber;          //1-based
            CorrectAnswerIndex = correctAnswerNumber - 1;       //0-based
        }

        public string GetCorrectAnswer()
        {
            return this.MultipleChoices[CorrectAnswerIndex];
        }
        public bool IsCorrectAnswer(int answerNumber)
        {
            return answerNumber == CorrectAnswerNumber;
        }
        public void Show()
        {
            // Display Question Text
            Console.WriteLine($"Question: {QuestionText}");

            // Display Multiple Choices
            for (int i = 0; i < MultipleChoices.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {MultipleChoices[i]}");
            }

            // Display Correct Answer (Indented) with Bias on the same line
            string correctAnswer = this.GetCorrectAnswer();
            Console.WriteLine($"  Correct Answer: {correctAnswer} ({CorrectAnswerNumber}) - Bias: {Bias}");
        }
    }
}
