using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuizModel
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public int CorrectAnswer { get; set; }
        public int? UserAnswer { get; set; }
        public bool IsCorrect { get; set; } // Для проверки правильности ответа
    }
}
