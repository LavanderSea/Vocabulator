using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;
using VocabulatorWeb.Serializers;

namespace VocabulatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserFacadeFactory _userFacadeFactory;
        private UserFacade _userFacade;
        private readonly IDeserializer<IEnumerable<Word>> _deserializer;

        public HomeController(
            ILogger<HomeController> logger,
            UserFacadeFactory userFacadeFactory,
            IDeserializer<IEnumerable<Word>> deserializer)
        {
            _logger = logger;
            _userFacadeFactory = userFacadeFactory;
            _deserializer = deserializer;
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
        [Route("/addWord")]
        public IActionResult AddWord([FromBody] string word)
        {
            _userFacade = _userFacadeFactory.Create();
            return Ok(_userFacade.ToCsv(_deserializer.Deserialize(word)));
        }

        [HttpPost]
        [Route("/next")]
        public IActionResult DownloadText([FromBody] string text)
        {
            _userFacade = _userFacadeFactory.Create();
            _userFacade.SaveWords(text.Split("\r\n"));
            return Ok();
        }
    }
}