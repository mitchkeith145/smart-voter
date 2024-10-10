using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SmarterVoter.Quizzes;


namespace SmarterVoter.Quizzes
{
    public class PoliticalTest
    {
        public List<PoliticalQuestion> SelectedQuestions { get; set; }
        public List<int> UserAnswers { get; set; }
        public int TotalCorrectAnswers { get; private set; }

        public PoliticalTest(int numQuestions, User user)
        {
            List<PoliticalQuestion> allQuestionsForLevel = LevelSystem.GetQuestionsAtLevel(user.CurrentLevel);

            SelectedQuestions = new List<PoliticalQuestion>();

            //initialize to impossible index
            UserAnswers = new List<int>();
            for (int i = 0; i < numQuestions; i++) UserAnswers.Add(-1);

            // Randomly select questions ensuring 1/3 are Left, Right, and Neutral
            Random rand = new Random();
            List<PoliticalQuestion> leftQuestions = allQuestionsForLevel.Where(q => q.Bias == QuestionBias.LeftLean).ToList();
            List<PoliticalQuestion> rightQuestions = allQuestionsForLevel.Where(q => q.Bias == QuestionBias.RightLean).ToList();
            List<PoliticalQuestion> neutralQuestions = allQuestionsForLevel.Where(q => q.Bias == QuestionBias.Neutral).ToList();

            int questionsPerCategory = numQuestions / 3;

            SelectedQuestions.AddRange(leftQuestions.OrderBy(x => rand.Next()).Take(questionsPerCategory));
            SelectedQuestions.AddRange(rightQuestions.OrderBy(x => rand.Next()).Take(questionsPerCategory));
            SelectedQuestions.AddRange(neutralQuestions.OrderBy(x => rand.Next()).Take(numQuestions - 2 * questionsPerCategory));
        }
        public void Show()
        {
            Console.WriteLine("Political Test Questions:");

            // Loop through each question and call its Show method
            foreach (var question in SelectedQuestions)
            {
                question.Show();
                Console.WriteLine(); // Adding space between questions
            }
        }
        public void SetAnswerForQuestion(int questionIndex, int answerIndex)
        {
            if (questionIndex < 0 || questionIndex >= SelectedQuestions.Count)
            {
                Console.WriteLine("Invalid question index.");
                return;
            }

            if (answerIndex < 0 || answerIndex >= SelectedQuestions[questionIndex].MultipleChoices.Count)
            {
                Console.WriteLine("Invalid answer index.");
                return;
            }

            // Store the answer provided by the user
            UserAnswers[questionIndex] = answerIndex;
        }
        public int UserAnswerNumberForQuestion(int questionIndex)
        {
            //this is 1-based
            return this.UserAnswers[questionIndex];
        }
        public int GradeTest()
        {
            int correctAnswers = 0;

            for (int i = 0; i < SelectedQuestions.Count; i++)
            {
                if (SelectedQuestions[i].IsCorrectAnswer(UserAnswers[i]))
                {
                    correctAnswers++;
                }
            }

            // Store the test result (number of correct answers)
            TotalCorrectAnswers = correctAnswers;
            return TotalCorrectAnswers;
        }
        public int NumberOfQuestions()
        {
            return SelectedQuestions.Count;
        }
        public string QuestionAt(int index)
        {
            return SelectedQuestions[index].QuestionText;        }
        public List<string> QuestionAnswerChoicesAt(int index)
        {
            return SelectedQuestions[index].MultipleChoices;
        }
        public string ChosenAnswerForQuestion(int answerIndex, int questionIndex)
        {
            return SelectedQuestions[questionIndex].MultipleChoices[answerIndex - 1];
        }
        public bool IsCorrectAnswerAt(int answerIndex)
        {
            int userAnswer = UserAnswers[answerIndex];
            int correctAnswers = SelectedQuestions[answerIndex].CorrectAnswerIndex;
            return correctAnswers == userAnswer;    
        }
        public void ShowResults()
        {
            Console.WriteLine("Test Results:");

            // Loop through each question and compare the selected answer with the correct answer
            for (int i = 0; i < SelectedQuestions.Count; i++)
            {
                var question = SelectedQuestions[i];
                question.Show();

                var userAnswerNumber = this.UserAnswerNumberForQuestion(i);
                var userAnswer = this.ChosenAnswerForQuestion(userAnswerNumber, i);

                // Indicate whether the user's answer was correct or incorrect
                if (question.IsCorrectAnswer(userAnswerNumber))
                {
                    Console.WriteLine($"    You chose: {userAnswer} ({userAnswerNumber}) which is Correct!");
                }
                else
                {
                    Console.WriteLine($"  You chose: {userAnswer} ({userAnswerNumber}) which is Incorrect");
                }

                Console.WriteLine(); // Space between questions
            }
            Console.WriteLine(FinalResultStr());
        }
        public string FinalResultStr()
        {
            string finalResult = "You answered " + FinalCorrectResultRatio() + " correctly, or " + FinalPercentage();
            return finalResult;
        }
        public string FinalCorrectResultRatio()
        {
            return TotalCorrectAnswers.ToString() + "/" + SelectedQuestions.Count;
        }
        public string FinalPercentage()
        {
            float ratio = (float)TotalCorrectAnswers / (float)SelectedQuestions.Count;
            ratio = ratio * 100;
            return $"{ratio:F1}" + "%";
        }
    }
}
