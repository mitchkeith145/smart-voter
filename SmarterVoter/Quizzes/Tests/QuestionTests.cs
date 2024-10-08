using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmarterVoter.Quizzes.Tests
{
    [TestClass]
    public class QuestionTests
    {

        [TestMethod]
        public void TestQuestion_ShouldInstantiateWithValidProperties()
        {
            string testQuestionText = "How many branches exist in the United States Government?";
            Bias testQuestBias = Bias.None;
            List<string> testPossibleAnswers = new List<string> { "One", "Two", "Three", "Four" };
            string testAnswer = "Three";

            Question question = new Question(
                text: "How many branches exist in the United States Government?",
                bias: Bias.None,
                possibleAnswers: new List<string> { "One", "Two", "Three", "Four" },
                answer: "Three");

            Assert.AreEqual(testQuestionText, question.Text);
            Assert.AreEqual(testQuestBias, question.Bias);
            Assert.AreEqual(testPossibleAnswers, question.PossibleAnswers);
            Assert.AreEqual(testAnswer, question.Answer);
        }

        [TestMethod]
        public void TestQuestion_CorrectlyEvaluatesAnswers()
        {
            Question question = new Question(
                text: "How many branches exist in the United States Government?",
                bias: Bias.None,
                possibleAnswers: new List<string> { "One", "Two", "Three", "Four" },
                answer: "Three");

            Assert.AreEqual(true, question.Evaluate("three"));
            Assert.AreEqual(false, question.Evaluate("one"));
        }

    }
}
