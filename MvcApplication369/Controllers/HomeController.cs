using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index() => View();

        [HttpGet]
        public ViewResult RsvpForm() => View(new GuestResponse());

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse x, string click)
        {
            if (click == "Результат" && ModelState.IsValid)
            {
                switch (x.Operation)
                {
                    case "+":
                        x.Result = (sbyte)(x.Operand_1 + x.Operand_2);
                        break;
                    case "-":
                        x.Result = (sbyte)(x.Operand_1 - x.Operand_2);
                        break;
                    case "*":
                        x.Result = (sbyte)(x.Operand_1 * x.Operand_2);
                        break;
                    case "/":
                        x.Result = (sbyte)(x.Operand_1 / x.Operand_2);
                        break;
                }
                HttpCookie cookie = new HttpCookie("SolutionEquation");
                cookie.Value = x.Operand_1.ToString() + x.Operation.ToString() + x.Operand_2.ToString() + " = " + x.Result.ToString();
                Response.Cookies.Add(cookie);
               return View("ResultEquation",x);
            }
            else
            {
                if (click == "Очистить")
                {
                    x.Operand_1 = 0;
                    x.Operand_2 = 0;
                   // return View("RsvpForm", x);
                }
            }
            //ViewBag.Resulta = 24;
            return View(x);
           //return View("RsvpForm", x);
        }
        public ViewResult Equation()
        {
            if (Request.Cookies["SolutionEquation"] != null)
            {
                string Result = Request.Cookies["SolutionEquation"].Value;
                string ResultInfo = Result.Substring(0, Result.LastIndexOf('=')) + "=" + Result.Substring(Result.LastIndexOf('=') + 1);
                ViewBag.Equat = ResultInfo;
            }
            return View();
        }
    }
}



//public ViewResult Index()
//{
//    return View();
//}



//[HttpGet]
//public ViewResult RsvpForm()
//{
//    return View(new GuestResponse());
//}