using Microsoft.AspNetCore.Mvc;
using Translator.Data.Interfaces;

namespace Translator.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly IDictionaryRepository _dictionaryRepository;

        public DictionaryController(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
            _dictionaryRepository.DictionatyFilling("Data/Repositories/Dictionary.txt");
        }

        public ViewResult Translation(string word)
        {
            ViewBag.word = word;
            ViewBag.translation = _dictionaryRepository.WordTranslation(word);
            return View("Translator");
        }
    }
}
