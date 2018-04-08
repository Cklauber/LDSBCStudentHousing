using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using StudentHousing.Identity;
using StudentHousing.Models;

namespace StudentHousing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<StudentHousingUser> userManager;
        private readonly IUserClaimsPrincipalFactory<StudentHousingUser> claimsPrincipalFactory;

        public AccountController(UserManager<StudentHousingUser> userManager,
            IUserClaimsPrincipalFactory<StudentHousingUser> claimsPrincipalFactory)
        {
            this.userManager = userManager;
            this.claimsPrincipalFactory = claimsPrincipalFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    user = new StudentHousingUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    };


                }
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {


                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationEmail = Url.Action("ConfirmEmailAddress", "Account",
                        new { token = token, email = user.Email }, Request.Scheme);



                    EmailConfirmation(user, confirmationEmail);
                    ViewBag.message = "<h3>An e-mail was sent to your e-mail address with the confirmation link to register to the website. Please check your e-mail and open the link.</h3>";
                    ViewBag.title = "Check e-mail";
                    return View("Message");
                }
                AddErrors(result);

            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmailAddress(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    ViewBag.message = "<div class='alert alert-success'>" +
                                      "<p>Account created successfully. Please, go ahead and log in.</p>" +
                                      "</div>";
                    ViewBag.title = "Success";
                    return View("Message");
                }
            }
            return View("Error");
        }

        private void EmailConfirmation(StudentHousingUser user, string confirmationEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Student Housing", "studenthousingcs260@gmail.com"));
            message.To.Add(new MailboxAddress(user.FirstName + " " + user.LastName, user.Email));
            message.Subject = "E-mail Confirmation - DO NOT REPLY";
            message.Body = new TextPart("plain")
            {
                Text = "Thank you for registering in the Student Housing website. Please confirm your registration by clicking on this link: " + confirmationEmail
            };

            SendEmail(message);

        }

        private void SendEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("studenthousingcs260@gmail.com", "ldsbcrocks123");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Email is not confirmed");
                        return View();
                    }


                    var principal = await claimsPrincipalFactory.CreateAsync(user);

                    await HttpContext.SignInAsync("Identity.Application", principal);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid UserName or Password");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Identity.Application");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }

}
