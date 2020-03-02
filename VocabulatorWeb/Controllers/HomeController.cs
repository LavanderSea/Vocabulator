using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;

namespace VocabulatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserFacadeFactory _userFacadeFactory;
        private UserFacade _userFacade;

        public HomeController(
            ILogger<HomeController> logger,
            UserFacadeFactory userFacadeFactory)
        {
            _logger = logger;
            _userFacadeFactory = userFacadeFactory;
        }
        public IActionResult Index() => View();

        [Route("/load")]
        public IActionResult LoadView() => View();

        [Route("/test")]
        public IActionResult TestView() => View();

        [Route("/words")]
        public IActionResult WordView()
        {
            _userFacade = _userFacadeFactory.Create();
            return View(_userFacade.GetDtoCollection());
        }

        [HttpPut]
        [Route("/setDictionaryType")]
        public IActionResult SetUserFacade([FromBody] string type)
        {
            _userFacadeFactory.SetType(type);
            _userFacade = _userFacadeFactory.Create();
            return Ok();
        }

        [HttpPost]
        [Route("/next")]
        public IActionResult DownloadText([FromBody] string text)
        {
            _userFacade = _userFacadeFactory.Create();
            _userFacade.SaveWords(text.Split("\r\n"));
            return Ok("Ready");
        }
    }
}