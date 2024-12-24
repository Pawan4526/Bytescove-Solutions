using Bytescove_Solutions.CommonServices;
using Bytescove_Solutions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bytescove_Solutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{type}")]
        public IActionResult CmsPage(string type)
        {
            string viewName = "";
            try
            {
                viewName = Util.GetViewName(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(viewName);
        }

        [Route("Error404")]
        public IActionResult HandleError()
        {
            return View("~/Views/Shared/Error404.cshtml");
        }

        [HttpPost]
        public IActionResult EmailSend(EmailViewModel model)
        {
            var status = false;
            var message = "";
            var bodyContent = "";
            try
            {
                bodyContent += "Name : " + model.Name + "<br />";
                bodyContent += "Email Address : " + model.Email + "<br />";
                bodyContent += "Contact No. : " + model.Phone + "<br />";
                if (model.Skype != null)
                {
                    bodyContent += "Skype/Whats App : " + model.Skype + "<br />";
                }
                bodyContent += "Looking For : " + model.LookingFor + "<br />";
                bodyContent += "Description : " + model.Body;
                Util.SendMail("", model.LookingFor, bodyContent, "", model.Attachment);
                status = true;
                message = "mail sent successfully.";
            }
            catch (Exception ex)
            {
                message = ex.InnerException != null ? ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.InnerException.Message : ex.Message;
                message = message + " : mail sending failure.";
            }
            return Json(new { status, message });
        }
    }
}
