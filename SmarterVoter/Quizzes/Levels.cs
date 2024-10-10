using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SmarterVoter.Quizzes
{
    public class Level
    {
        public int LevelIndex { get; set; }
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }
        public int NumberRightToAdvance { get; set; }
        public List<PoliticalQuestion> Questions { get; set; }

        public Level(int levelIndex, string name, string welcomeMessage, int numbToAdvance, List<PoliticalQuestion> allTheQuestions)
        {
            LevelIndex = levelIndex;
            Name = name;
            WelcomeMessage = welcomeMessage;
            NumberRightToAdvance = numbToAdvance;

            List<PoliticalQuestion> questionsForLevel = new List<PoliticalQuestion>();
            foreach (PoliticalQuestion question in allTheQuestions)
            {
                if (question.Level == levelIndex)
                {
                    questionsForLevel.Add(question);
                }
            }
            Questions = questionsForLevel;
        }
    }
    public sealed class LevelSystem
    {
        private static readonly LevelSystem instance = new LevelSystem();
        private static List<PoliticalQuestion> AllQuestions = new List<PoliticalQuestion>();
        private List<Level> Levels { get; set; }
        private LevelSystem()   //private to prevent instantiation
        {
            Levels = new List<Level>();
            Initialize();
        }
        private void Initialize()
        {
            AllQuestions = GetAllQuestions();
            Levels.Add(new Level(1, "SmartVote Civic Explorer", "Welcome to the Explorer Level 1", 7, AllQuestions));
            Levels.Add(new Level(2, "SmartVote Civic Engaged", "Welcome to the Engaged Level 2", 7, AllQuestions));
            Levels.Add(new Level(3, "SmartVote Super Informed", "Welcome to the Super Informed Level 3", 8, AllQuestions));
            Levels.Add(new Level(4, "SmartVote Civic Expert", "Welcome to the Expert Level 4", 9, AllQuestions));
            Levels.Add(new Level(5, "SmartVote Guru 1", "Welcome to the Guru Apprentice Level 5", 9, AllQuestions));
            Levels.Add(new Level(6, "SmartVote Guru 2", "Welcome to the Guru Master Level 6", 10, AllQuestions));
        }

        // Public static method to access the single instance
        public static LevelSystem Instance
        {
            get
            {
                return instance;
            }
        }
        public static List<PoliticalQuestion> GetQuestionsAtLevel(int level)
        {
            //passed in level is 1-based, but actual levels are 0-based
            return Instance.Levels[level - 1].Questions;
        }

        public static List<PoliticalQuestion> GetAllQuestions()
        {
            string json = RawJSON();
            var allQuestions = JsonConvert.DeserializeObject<List<PoliticalQuestion>>(json);
            if (allQuestions == null)
                throw new Exception();
            return (List<PoliticalQuestion>)allQuestions;
        }
        private static string RawJSON()
        {
            string rawJson = @"[
    {
        ""Bias"": ""RightLean"",
        ""Level"": 1,
        ""QuestionText"": ""On Jan 6th 2020, did Trump actually say ''We are going to march peacefully to the capital building?''"",
        ""MultipleChoices"": [""True"", ""False""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""Trump made this statement during his speech on January 6th, 2020."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""RightLean"",
        ""Level"": 1,
        ""QuestionText"": ""Did the Trump administration secure record-high funding for the U.S. military?"",
        ""MultipleChoices"": [""Yes"", ""No""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""Trump increased defense spending significantly during his time in office."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""RightLean"",
        ""Level"": 1,
        ""QuestionText"": ""Which U.S. president enacted significant tax cuts in 2017?"",
        ""MultipleChoices"": [""Barack Obama"", ""Donald Trump"", ""Joe Biden"", ""George W. Bush""],
        ""CorrectAnswerNumber"": 2,
        ""Background"": ""In 2017, the Trump administration passed a tax cut package, officially known as the Tax Cuts and Jobs Act."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""RightLean"",
        ""Level"": 1,
        ""QuestionText"": ""Did Trump reduce regulations on businesses during his presidency?"",
        ""MultipleChoices"": [""Yes"", ""No""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""Trump rolled back a significant number of federal regulations on businesses."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""RightLean"",
        ""Level"": 1,
        ""QuestionText"": ""Which of the following was a priority for Trump''s immigration policy?"",
        ""MultipleChoices"": [""Family reunification"", ""Border wall construction"", ""Increased refugee intake""],
        ""CorrectAnswerNumber"": 2,
        ""Background"": ""The Trump administration prioritized the construction of a border wall along the U.S.-Mexico border."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""LeftLean"",
        ""Level"": 1,
        ""QuestionText"": ""When Trump left office, unemployment was extremely high?"",
        ""MultipleChoices"": [""True"", ""False""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""Unemployment remained high as a result of the COVID-19 pandemic, even when Trump left office."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""LeftLean"",
        ""Level"": 1,
        ""QuestionText"": ""Did the Trump administration implement a policy that separated migrant children from their families at the border?"",
        ""MultipleChoices"": [""True"", ""False""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""The family separation policy was part of a ''zero-tolerance'' immigration enforcement strategy in 2018."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""LeftLean"",
        ""Level"": 1,
        ""QuestionText"": ""Which president rejoined the Paris Climate Agreement?"",
        ""MultipleChoices"": [""Donald Trump"", ""Joe Biden"", ""George W. Bush"", ""Barack Obama""],
        ""CorrectAnswerNumber"": 2,
        ""Background"": ""One of Joe Biden''s first acts as president was to rejoin the Paris Climate Agreement."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""LeftLean"",
        ""Level"": 1,
        ""QuestionText"": ""Did Trump attempt to overturn the results of the 2020 U.S. presidential election?"",
        ""MultipleChoices"": [""Yes"", ""No""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""After the 2020 election, Trump and his allies made numerous attempts to challenge and overturn the results."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""LeftLean"",
        ""Level"": 1,
        ""QuestionText"": ""Which healthcare program did Trump attempt to repeal without a replacement plan?"",
        ""MultipleChoices"": [""Medicare"", ""Medicaid"", ""Affordable Care Act""],
        ""CorrectAnswerNumber"": 3,
        ""Background"": ""The Trump administration sought to repeal the Affordable Care Act without a replacement."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""Neutral"",
        ""Level"": 1,
        ""QuestionText"": ""In what year did the COVID-19 pandemic start?"",
        ""MultipleChoices"": [""2018"", ""2019"", ""2020""],
        ""CorrectAnswerNumber"": 2,
        ""Background"": ""The first known cases of COVID-19 emerged in late 2019."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""Neutral"",
        ""Level"": 1,
        ""QuestionText"": ""True or False: The United Nations was founded after World War II."",
        ""MultipleChoices"": [""True"", ""False""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""The UN was created in 1945 after World War II to promote peace and cooperation among nations."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""Neutral"",
        ""Level"": 1,
        ""QuestionText"": ""Which country is the world''s largest democracy?"",
        ""MultipleChoices"": [""India"", ""United States"", ""Brazil""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""India, with its population of over 1.3 billion, is the world''s largest democracy."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""Neutral"",
        ""Level"": 1,
        ""QuestionText"": ""True or False: The Federal Reserve sets interest rates in the United States."",
        ""MultipleChoices"": [""True"", ""False""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""The Federal Reserve is responsible for setting the country''s interest rates as part of its monetary policy."",
        ""SourceURL"": ""https://example.com""
    },
    {
        ""Bias"": ""Neutral"",
        ""Level"": 1,
        ""QuestionText"": ""What is the maximum number of years a U.S. president can serve?"",
        ""MultipleChoices"": [""8 years"", ""12 years"", ""10 years"", ""6 years""],
        ""CorrectAnswerNumber"": 1,
        ""Background"": ""A U.S. president can serve a maximum of two 4-year terms, totaling 8 years, under the 22nd Amendment."",
        ""SourceURL"": ""https://example.com""
    }
]
";
            return rawJson;
        }
    }
}
