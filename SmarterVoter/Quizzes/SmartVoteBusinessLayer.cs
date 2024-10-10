namespace SmarterVoter.Quizzes
{
    public class SmartVoteBusinessLayer
    {
        public static LevelSystem InitializeLevels()
        {
            return LevelSystem.Instance;
        }
        public static User GetUser(string userName, string password)
        {
            User joeUser = new User(2, "joe blow", "12345", 1, 0, 0);
            return joeUser;
        }
        public static PoliticalTest CreateTest(User user)
        {
            PoliticalTest newTest = new PoliticalTest(6, user);
            return newTest;
        }
    }
}
