﻿using HealthyFoodWeb.Models.Quiz;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IQuizServices
    {
        QuizViewModel GetAllQuiz();
        StartQuizViewModel GetQuestion(int numberOfQuestion, bool IsRightThisAnswer, int conutRight);

    }
}