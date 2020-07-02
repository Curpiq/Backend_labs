using System.Collections.Generic;
using System.IO;
using Translator.Data.Interfaces;
using Translator.Data.Models;

namespace Translator.Data.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly Dictionary _dictionary = new Dictionary();
        public void DictionatyFilling(string dictPath)
        {
            StreamReader dictFile = new StreamReader(dictPath);
            string str;
            while ((str = dictFile.ReadLine()) != null)
            {
                string[] pairOfWords = str.Split("\t");
                _dictionary.data.Add(pairOfWords[0], pairOfWords[1]);
            }
        }
        public string WordTranslation(string word)
        {
            string translation = null;
            if (word != null)
            {
                //English word
                if (_dictionary.data.TryGetValue(word, out translation))
                {
                    return translation;
                }
                //Russian word
                foreach (KeyValuePair<string, string> keyword in _dictionary.data)
                {
                    if (keyword.Value == word)
                    {
                        translation = keyword.Key;
                    }
                }
            }
            return translation;
        }
    }
}
