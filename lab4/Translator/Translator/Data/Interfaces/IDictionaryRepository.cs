using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Data.Interfaces
{
    public interface IDictionaryRepository
    {
        public void DictionatyFilling(string dictPath);
        public string WordTranslation(string word);
    }
}
