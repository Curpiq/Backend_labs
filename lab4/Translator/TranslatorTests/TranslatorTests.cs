using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator.Data.Interfaces;
using Translator.Data.Repositories;

namespace TranslatorTests
{
    [TestClass]
    public class Tests
    {
        private IDictionaryRepository _dictionaryRepository;
        public void Setup()
        {
            _dictionaryRepository = new DictionaryRepository();
            _dictionaryRepository.DictionatyFilling("Dictionary.txt");
        }
        [TestMethod]
        public void WordTranslation_CorrectEndlishWord_ReturnedTranslation()
        {
            string word = "cat";
            string translation = _dictionaryRepository.WordTranslation(word);
            Assert.AreEqual("кот", translation);
        }
        [TestMethod]
        public void WordTranslation_IncorrectWord_ReturnedNull()
        {
            string word = "123";
            var translation = _dictionaryRepository.WordTranslation(word);
            Assert.IsNull(translation);
        }
    }
}
