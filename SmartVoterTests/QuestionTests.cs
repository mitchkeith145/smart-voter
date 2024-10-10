using SmarterVoter.Quizzes;

namespace SmartVoterTests
{
    [TestClass]
    public class QuestionTests
    {

        [TestMethod]
        public void TestQuestion_ShouldInstantiateWithValidProperties()
        {
            List<string> possibleAnswers = new List<string> { "One", "Two", "Three", "Four" };
            PoliticalQuestion question = new PoliticalQuestion(QuestionBias.Neutral, "what is life?",
                "background", "mySourceURL", possibleAnswers, 2);

            Assert.AreEqual(question.QuestionText, "what is life?");
        }
        [TestMethod]
        public void CreateTestFromUser()
        {
            User joeUser = new User(2, "joe blow", "12345", 1, 0, 0);

            PoliticalTest newTest = new PoliticalTest(6, joeUser);
            Assert.IsNotNull( newTest );    
            //newTest.Show();
            newTest.SetAnswerForQuestion(0, 1);
            newTest.SetAnswerForQuestion(1, 1);
            newTest.SetAnswerForQuestion(2, 1);
            newTest.SetAnswerForQuestion(3, 1);
            newTest.SetAnswerForQuestion(4, 1);
            newTest.SetAnswerForQuestion(5, 1);
            int testResult = newTest.GradeTest();

            newTest.ShowResults();
        }

    }
}
