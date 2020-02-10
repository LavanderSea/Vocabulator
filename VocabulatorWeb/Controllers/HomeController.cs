using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocabulatorLibrary;
using VocabulatorWeb.Serializers;

namespace VocabulatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISerializer _responseSerializer;
        private readonly UserFacade _userFacade;

        //path = $"temp{_id}.csv";

        public HomeController(
            ILogger<HomeController> logger,
            UserFacade userFacade,
            ISerializer responseSerializer)
        {
            _logger = logger;
            _userFacade = userFacade;
            _responseSerializer = responseSerializer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/next")]
        public IActionResult DownloadText([FromBody] string text)
        {
            //TODO: проверка корректности текста

            var r = text.Split("\r\n");
            var dtos = _userFacade.GetDtos(r);

            var jsonString = _responseSerializer.Serialize(dtos);
            var response = jsonString.ConvertFromUnicode();

            return Ok($"{response}");
        }
    }
}