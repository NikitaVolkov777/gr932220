using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Quiz.Controllers
{
    public class QuizController : Controller
    {
        // Список для хранения истории вопросов и ответов
        private static List<QuizModel> quizHistory = new List<QuizModel>();
        private Random random = new Random();

        // Метод для отображения текущего вопроса
        public IActionResult Quiz()
        {
            // Если нет вопросов в истории, то генерируем первый
            if (quizHistory.Count == 0)
            {
                var firstQuestion = GenerateQuestion(1);
                quizHistory.Add(firstQuestion);
            }

            var currentQuestion = quizHistory.Last();
            return View(currentQuestion);
        }

        // Метод для обработки ответа и перехода к следующему вопросу
        //[HttpPost]
        //public IActionResult Next(QuizModel model)
        //{
        //    // Если ответ пустой, мы явно присваиваем null
        //    if (string.IsNullOrEmpty(model.UserAnswer?.ToString()))
        //    {
        //        model.UserAnswer = null;
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Сохраняем ответ пользователя для предыдущего вопроса
        //        quizHistory.Last().UserAnswer = model.UserAnswer;

        //        // Проверка правильности ответа
        //        if (quizHistory.Last().CorrectAnswer != model.UserAnswer)
        //        {
        //            quizHistory.Last().IsCorrect = false;
        //        }
        //        else
        //        {
        //            quizHistory.Last().IsCorrect = true;
        //        }

        //        // Генерация следующего вопроса
        //        var nextQuestion = GenerateQuestion(quizHistory.Count + 1);

        //        // Добавляем новый вопрос в историю
        //        quizHistory.Add(nextQuestion);

        //        // Очищаем поле для ответа
        //        nextQuestion.UserAnswer = null; // Очистка ответа

        //        return View("Quiz", nextQuestion);
        //    }

        //    // Если модель не прошла валидацию, возвращаем тот же вопрос
        //    return View("Quiz", model);
        //}

        //// Метод для вывода результатов
        //public IActionResult Result(QuizModel model)
        //{
        //    // Подсчёт правильных ответов
        //    int correctCount = quizHistory.Count(q => q.IsCorrect);
        //    ViewBag.CorrectCount = correctCount;
        //    return View(quizHistory);
        //}
        [HttpPost]
        public IActionResult Next(QuizModel model)
        {
            // Если ответ пустой, мы явно присваиваем null
            if (string.IsNullOrEmpty(model.UserAnswer?.ToString()))
            {
                model.UserAnswer = 0;
            }

            if (ModelState.IsValid)
            {
                // Сохраняем ответ пользователя для предыдущего вопроса
                quizHistory.Last().UserAnswer = model.UserAnswer;

                // Проверка правильности ответа
                if (quizHistory.Last().CorrectAnswer != model.UserAnswer)
                {
                    quizHistory.Last().IsCorrect = false;
                }
                else
                {
                    quizHistory.Last().IsCorrect = true;
                }

                // Генерация следующего вопроса
                var nextQuestion = GenerateQuestion(quizHistory.Count + 1);

                // Добавляем новый вопрос в историю
                quizHistory.Add(nextQuestion);

                // Очищаем поле для ответа
                nextQuestion.UserAnswer = null; // Очистка ответа

                return View("Quiz", nextQuestion);
            }

            // Если модель не прошла валидацию, возвращаем тот же вопрос
            return View("Quiz", model);
        }
        public IActionResult Result(QuizModel model)
        {
            // Проверка, есть ли вопросы в истории
            if (!quizHistory.Any())
            {
                ViewBag.Message = "Тестов ещё не было, куда спешим? Быстро проходить тест!";
                return View(); // Переход на представление с сообщением
            }
            // Если ответ пустой, мы явно присваиваем null
            if (string.IsNullOrEmpty(model.UserAnswer?.ToString()))
            {
                quizHistory.Last().UserAnswer = 0;
            }
            else
            {
                quizHistory.Last().UserAnswer = model.UserAnswer;
            }
            // Подсчёт правильных ответов
            int correctCount = quizHistory.Count(q => q.CorrectAnswer == q.UserAnswer);

            // Передаем количество правильных ответов в ViewBag
            ViewBag.CorrectCount = correctCount;
            ViewBag.CountQuestions = quizHistory.Count();

            // Отображаем все вопросы и ответы
            return View(quizHistory);
        }
        // Метод для генерации случайного вопроса
        private QuizModel GenerateQuestion(int questionNumber)
        {
            int a = random.Next(0, 11);
            int b = random.Next(0, 11);
            var model = new QuizModel
            {
                QuestionNumber = questionNumber,
                QuestionText = $"{a} - {b} = ",
                CorrectAnswer = a - b,
                UserAnswer = null,
                IsCorrect = false
            };
            return model;
        }
    }
}
