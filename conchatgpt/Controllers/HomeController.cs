using conchatgpt.Models;
using conchatgpt.repositorio;
using conchatgpt.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace conchatgpt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IDB _db;
        private Iservice _promptService;


        public HomeController(ILogger<HomeController> logger, IDB db, Iservice service)
        {
            _logger = logger;
            _db = db;
            _promptService = service;  
        }

        public async Task<IActionResult> Get(string prompt) 
        {
            var sql = await _promptService.Get(prompt);
            var data = _db.Get(sql);
            return View(data);
        
        }

        public IActionResult Index()
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