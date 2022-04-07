using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Net;

namespace Задание_из_Анкеты
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            //Получения текста с указанного в задании сайта
            WebClient client = new WebClient();
            string text = client.DownloadString(url);
            //Перевод текста в XML файл
            XDocument doc = XDocument.Parse(text);
            //Получение из файла данных о запрашиваемых валютах
            var cursNordway = doc.Element("ValCurs").Elements("Valute").FirstOrDefault(p=>p.Attribute("ID").Value== "R01535");
            var cursHungary = doc.Element("ValCurs").Elements("Valute").FirstOrDefault(p => p.Attribute("ID").Value == "R01135");
            //Получение значений курса
            double nordVal = Convert.ToDouble(cursNordway.Element("Value").Value);
            double hungVal = Convert.ToDouble(cursHungary.Element("Value").Value);
            //Вычисление значения
            double result = nordVal / hungVal;
            Console.WriteLine("Одна норвежская крона стоит " + Math.Round(result,2) + " венгерских форинтов.");
            Console.ReadKey();
        }
    }
}
