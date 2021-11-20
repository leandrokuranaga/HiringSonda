using HiringSonda.Domain.Interfaces;
using HiringSonda.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HiringSonda.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allUsers = await _repository.GetAllUsers();
            return View("~/Views/User/Index.cshtml", allUsers);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            await _repository.RegisterAddress(user);
            
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var user = await _repository.GetAddressById(id);

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
