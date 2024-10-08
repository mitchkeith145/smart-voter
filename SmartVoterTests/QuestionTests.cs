using SmarterVoter.Quizzes;

namespace SmartVoterTests
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
            Assert.AreEqual(testPossibleAnswers[0], question.PossibleAnswers[0]);
            Assert.AreEqual(testPossibleAnswers[1], question.PossibleAnswers[1]);
            Assert.AreEqual(testPossibleAnswers[2], question.PossibleAnswers[2]);
            Assert.AreEqual(testPossibleAnswers[3], question.PossibleAnswers[3]);
            Assert.AreEqual(testAnswer, question.Answer);
        }

    }
}
