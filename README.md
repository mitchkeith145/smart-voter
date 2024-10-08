Smart Voter

1. As a user, I want to take a political quiz and instantly get my results.
	- APIs
		- GetRandomQuiz() -> List<Question>
		- GradeQuiz(List<Answer> answers) -> QuizResult
	- Classes

		Question
			- String content
			- List<String> possibleAnswers
			- String answer

		Answer
			- Question question
			- String userAnswer
			- bool isCorrect {
				return question.answer == this.userAnswer
			}


www.smartvoter.com



	1.a. 
		HTTP GET www.smartvoter.com/v0/api/randomquiz
			{
				"questions": [
					{
						"id": 1,
						"content": "Did trump do that thing?",
						"possibleAnswers": [ "yes", "no" ]
					},
					{
						"id": 2,
						"content": "Did trump do that thing?"
					},
					{
						"id": 3,
						"content": "Did trump do that thing?"
					},
					{
						"id": 4,
						"content": "Did trump do that thing?"
					},
				]
			}

	2. User completes quiz, GUI compiling answers:
		[  
			{
				"id": 1,
				"answer": 0
			},
			{
				"id": 1,
				"answer": 1
			}
		]
	3. HTTP POST www.smartvoter.com/v0/api/gradequiz
		{
			"results": {
				"numberOfCorrectAnswer": 8,
				"numberOfQuestions": 10,
				"questions": [
					{
						"questionId": 1,
						"content": "Did trump do that thing?",
						"possibleAnswers": [ "yes", "no" ],
						"answer": 0,
						"userAnswer": 0
					},
					{
						"questionId": 1,
						"content": "Did trump do that thing?",
						"possibleAnswers": [ "yes", "no" ],
						"answer": 0,
						"userAnswer": 0
					},
					{
						"questionId": 1,
						"content": "Did trump do that thing?",
						"possibleAnswers": [ "yes", "no" ],
						"answer": 0,
						"userAnswer": 0
					}
				]
			}

		}
