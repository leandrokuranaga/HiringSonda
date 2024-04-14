using HiringSonda.Application.Person.Services;
using HiringSonda.Domain;
using HiringSonda.Domain.UserAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HiringSonda.Controllers
{
    public class UserController(
        ILogger<UserController> logger,
        IPersonService personService
            ) : Controller
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IPersonService _personService = personService;

        [HttpGet("all-customers")]
        public async Task<ActionResult> Index()
        {
            var allUsers = await _personService.GetAllUsers();
            return View("~/Views/User/Index.cshtml", allUsers);
        }

        [HttpGet("page")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDomain user)
        {
            await _personService.RegisterAddress(user);
            return View("~/Views/Home/Index.cshtml");            
        }

        [HttpGet("details")]
        public async Task<ActionResult> Details(int id)
        {
            var user = await _personService.GetAddressById(id);

            if (user == null)
            {
                _logger.LogError($"User with id: {id}, not found.");
                return NotFound();
            }

            return View("~/Views/User/Details.cshtml", user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
