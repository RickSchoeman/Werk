using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.Translations;

namespace Demo.Extras.Translation
{
    class TranslationDemo
    {
        private const string TranslationType = "XLT";
        private readonly TranslationService translationService;

        public TranslationDemo(Session session)
        {
            translationService = new TranslationService(session);
        }

        public void Run()
        {
            if (!FindTranslations())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindTranslations()
        {
            Console.WriteLine("Searching translations");
            const int searchField = 0;
            var translations = translationService.FindTranslations("*", TranslationType, searchField);
            DisplayTranslationSummaries(translations);
            if (translations.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayTranslationSummaries(IEnumerable<TranslationSummary> translations)
        {
            foreach (var t in translations)
            {
                Console.WriteLine("{0,-16} {1}", t.Code, t.Name);
            }
            Console.WriteLine();
        }
    }
}
