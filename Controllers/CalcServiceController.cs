using Microsoft.AspNetCore.Mvc;
using CalcService.Services;
using CalcService.Models;
using System;
using System.Reflection;

namespace CalcService.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly CalcService1 _calcService;

        public CalcServiceController(CalcService1 calcService)
        {
            _calcService = calcService;
        }

        // Передача данных через модель
        public IActionResult PassUsingModel()
        {
            var model = GetCalculationModel();
            return View(model);
        }

        // Передача данных через ViewData
        public IActionResult PassUsingViewData()
        {
            var model = GetCalculationModel();
            ViewData["FirstNumber"] = model.FirstNumber;
            ViewData["SecondNumber"] = model.SecondNumber;
            ViewData["Addition"] = model.Addition;
            ViewData["Subtraction"] = model.Subtraction;
            ViewData["Multiplication"] = model.Multiplication;
            ViewData["Division"] = model.Division;
            return View();
        }

        // Передача данных через ViewBag
        public IActionResult PassUsingViewBag()
        {
            var model = GetCalculationModel();
            ViewBag.FirstNumber = model.FirstNumber;
            ViewBag.SecondNumber = model.SecondNumber;
            ViewBag.Addition = model.Addition;
            ViewBag.Subtraction = model.Subtraction;
            ViewBag.Multiplication = model.Multiplication;
            ViewBag.Division = model.Division;
            return View();
        }

        // Действие для использования Service Injection
        public IActionResult PassUsingServiceInjection()
        {
            var model = GetCalculationModel();
            return View(model);
        }

        // Вспомогательный метод для генерации модели с данными
        private CalculationModel GetCalculationModel()
        {
            var rand = new Random();
            int firstNumber = rand.Next(0, 11);
            int secondNumber = rand.Next(0, 11);

            return new CalculationModel
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Addition = $"{firstNumber} + {secondNumber} = {_calcService.Add(firstNumber, secondNumber)}" ,
                Subtraction = $"{firstNumber} - {secondNumber} = {_calcService.Subtract(firstNumber, secondNumber)}",
                Multiplication = $"{firstNumber} * {secondNumber} = {_calcService.Multiply(firstNumber, secondNumber)}",
                Division = $"{firstNumber} / {secondNumber} = {_calcService.Divide(firstNumber, secondNumber)}"
            };
        }
    }
}
