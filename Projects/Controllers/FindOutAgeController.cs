using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using System;

namespace Projects.Controllers
{
    public class FindOutAgeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FindOutAge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindOutAge(FindOutAgeModel findOutAgeModel)

        {
            int leapYear = findOutAgeModel.BirthData.Year;

            int age = DateTime.Now.Year - findOutAgeModel.BirthData.Year;

            if (DateTime.IsLeapYear(leapYear))
            {
                leapYear = Convert.ToInt32(findOutAgeModel.BirthData.DayOfYear - 1);

                if (leapYear == DateTime.Today.DayOfYear)
                {
                    TempData["msg"] = "Eba! Hoje é seu Aniversário! e sua idade é : " + age + " e você nasceu em um ano bissexto!";
                    return View();
                }
                if (DateTime.Now.DayOfYear < leapYear)
                {
                    age = age - 1;
                    TempData["msg"] = "Sua idade é " + age + " e você nasceu em um ano bissexto!";
                }
                else
                    TempData["msg"] = "Sua idade é " + age + " e você nasceu em um ano bissexto!";

                return View();
            }
            if (findOutAgeModel.BirthData.DayOfYear == DateTime.Today.DayOfYear)
            {
                TempData["msg"] = "Eba! Hoje é seu Aniversário! e sua idade é : " + age;
                return View();
            }
            if (DateTime.Now.DayOfYear < findOutAgeModel.BirthData.DayOfYear)
            {
                age = age - 1;
                TempData["msg"] = "Sua idade é " + age + " anos.";
            }

            TempData["msg"] = "Sua idade é " + age + " anos.";

            return View();
        }
    }
}
