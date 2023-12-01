using Microsoft.AspNetCore.Mvc;
using SATapp.UI.MVC.Models;
using System.Diagnostics;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace SATapp.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Enrollment()
        {
            return View();
        }

        public IActionResult Classes()
        {
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }        

        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = $"You have recieved an email from {model.FirstName} {model.LastName}" +
                    $"(reply to: {model.Email}.\n" +
                    $"*Message: \n{model.Message}";

                var Msg = new MimeMessage();
                Msg.From.Add(new MailboxAddress("No Reply", _configuration.GetValue<string>("Credentials:Email:User")));
                Msg.To.Add(new MailboxAddress("You", _configuration.GetValue<string>("Credentials:Email:User")));

                Msg.Subject = model.Subject;
                Msg.Body = new TextPart("HTML") { Text = model.Message };
                Msg.ReplyTo.Add(new MailboxAddress(model.FirstName + " " + model.LastName, model.Email));

                using (var Client = new SmtpClient())
                {
                    try
                    {
                        Client.Connect(_configuration.GetValue<string>("Credentials:Email:Client"), 8889);

                        Client.Authenticate(_configuration.GetValue<string>("Credentials:Email:User"),
                                            _configuration.GetValue<string>("Credentials:Email:Password"));

                        Client.Send(Msg);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = $"An error occured while sending this email, try again later please";
                        return View(model);
                    }

                }

                return RedirectToAction(nameof(ThankYou));
            }
            return View(model); // shoots the user back to the same page view 
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}