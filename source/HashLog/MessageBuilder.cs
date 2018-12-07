using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLog
{
    static class MessageBuilder
    {
        public static string BuildMessage(Exception exception, int innerExceptionLevel = 0)
        {
            string text = "";

            if (innerExceptionLevel != 0)
                text = AddTabulatorsToString(text, innerExceptionLevel);

            text += String.Format("Source: {0} || Message: {1} || Data: {2}", exception.Source, exception.Message, GetDataMessage(exception));

            if (exception.InnerException != null)
            {
                text += Environment.NewLine;
                text += BuildMessage(exception.InnerException, innerExceptionLevel + 1);
            }

            return text;
        }

        private static string AddTabulatorsToString(string text, int tabulators)
        {
            string tabsText = "└";

            for (int i = 1; i < tabulators; i++)
            {
                tabsText += "─";
            }

            tabsText += text;
            return tabsText;
        }

        private static string GetDataMessage(Exception exception)
        {
            string text = "{ ";

            bool useComma = false;

            foreach (System.Collections.DictionaryEntry entry in exception.Data)
            {
                if (useComma)
                    text += ", ";
                else
                {
                    text += " ";
                    useComma = true;
                }

                text += String.Format("{0}: {1}", entry.Key, entry.Value);
            }

            text += " }";
            return text;
        }
    }
}
