namespace SmarterVoter.Quizzes
{
    public enum EventType
    {
        TookTest,
        NewContent
    }
    public class Event
    {
        public EventType TypeOfEvent { get; set; }
        public DateTime Date { get; set; }
        public int CreditChange { get; set; }
        public int RatingChange { get; set; }
        public string NewContentRef { get; set; }

        public Event(EventType type, int creditChange, int ratingChange, string newContentRef)
        {
            TypeOfEvent = type;
            Date = DateTime.Now;
            CreditChange = creditChange;
            RatingChange = ratingChange;
            NewContentRef = newContentRef;
        }
    }
    public class UserHistory
    {
        User MyUser;
        public List<Event> UserEvents { get; set; }
        public UserHistory(User user)
        {
            MyUser = user;
            UserEvents = new List<Event>();
        }
    }
    public sealed class UserId
    {
        // Private static instance of the class
        private static readonly UserId instance = new UserId();

        // A counter to keep track of the next user ID
        private int currentId = 0;

        // Private constructor to prevent instantiation
        private UserId() { }

        // Public static method to access the single instance
        public static UserId Instance
        {
            get
            {
                return instance;
            }
        }
        public static int Next()
        {
            return ++Instance.currentId;
        }
    }
    public class User
    {
        public long MyUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserHistory MyHistory { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentRating { get; set; }
        public int CurrentCredits { get; set; }

        public User(long id, string username, string password, int level, int rating, int credits)
        {
            if (id < 0)
            {
                MyUserId = UserId.Next();
            }
            Username = username;
            Password = password;
            CurrentLevel = level;
            CurrentRating = rating;
            CurrentCredits = credits;
            MyHistory = new UserHistory(this);
        }
        public void UpdateUserHistory(EventType type, int creditChange)
        {
        }
    }
}
