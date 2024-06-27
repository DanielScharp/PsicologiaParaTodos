using Microsoft.AspNetCore.Mvc;
using Psicologia.Domain;
using Psicologia.Web.App;
using Psicologia.Web.Models;
using Psicologia.Web.Services;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Psicologia.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpService<List<Usuario>> _httpService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, TokenCookie tokenCookie)
        {
            _logger = logger;
            _httpService = new HttpService<List<Usuario>>(configuration, tokenCookie); // Modificação aqui
        }

        public IActionResult Index()
        {
            var result = _httpService.ReturnService("api/Usuario/Listar");

            return View(result);
        }

    }
}
