using Microsoft.AspNetCore.Mvc;
using Parsing.Models;

namespace Parsing.Controllers
{
    public class ParsingModelController : Controller
    {
        private int operand1;
        private string Operator;
        private int operand2;

        // Ручной парсинг и отображение формы
        [HttpGet]
        public IActionResult Manual()
        {
            return View(); // Отображение формы для ввода данных
        }

        [HttpPost]
        public IActionResult Manual(int operand1, string Operator, int operand2)
        {
            int result = PerformCalculation(operand1, Operator, operand2);
            ViewBag.Result = $"{operand1} {Operator} {operand2} = {result}";
            return View("Result"); // Отображение результата
        }

        // Поэтапный парсинг и отображение формы
        [HttpGet]
        public IActionResult ManualSeparate()
        {
            var model = new ParsingModel();
            return View(model); 
        }

        [HttpPost]
        public IActionResult ManualSeparate(int? operand1, string Operator, int? operand2)
        {
            // Если все данные еще не собраны
            if (operand1.HasValue) HttpContext.Session.SetInt32("operand1", operand1.Value);
            if (!string.IsNullOrEmpty(Operator)) HttpContext.Session.SetString("Operator", Operator);
            if (operand2.HasValue) HttpContext.Session.SetInt32("operand2", operand2.Value);


            if (operand1.HasValue && !string.IsNullOrEmpty(Operator) && operand2.HasValue)
            {
                int result = PerformCalculation(operand1.Value, Operator, operand2.Value);

                ViewBag.Result = $"{operand1.Value} {Operator} {operand2.Value} = {result}";
                return View("Result");
            }

            return View();
        }

        // Привязка модели (параметры)
        [HttpGet]
        public IActionResult ModelBinding()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult ModelBinding(int operand1, string Operator, int operand2)
        {
            int result = PerformCalculation(operand1, Operator, operand2);
            ViewBag.Result = $"{result}";
            return View("Result");
        }

        // Привязка модели (отдельная модель)
        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModelBindingSeparate(ParsingModel model)
        {
            if (ModelState.IsValid)
            {
                int result = PerformCalculation(model.Operand1, model.Operator, model.Operand2);
                ViewBag.Result = $"{result}";
                return View("Result"); // Показываем результат
            }

            return View(model); // В случае ошибки возвращаем форму с текущими данными
        }

        private int PerformCalculation(int operand1, string Operator, int operand2)
        {
            return Operator switch
            {
                "+" => operand1 + operand2,
                "-" => operand1 - operand2,
                "*" => operand1 * operand2,
                "/" => operand2 != 0 ? operand1 / operand2 : 0,
                _ => 0
            };
        }
    }
}
