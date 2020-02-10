using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocabulatorLibrary;

namespace VocabulatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserFacade _userFacade;

        //path = $"temp{_id}.csv";

        public HomeController(
            ILogger<HomeController> logger,
            UserFacade userFacade)
        {
            _logger = logger;
            _userFacade = userFacade;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}