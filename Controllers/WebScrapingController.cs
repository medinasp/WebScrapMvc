using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using WebScraping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraping.Controllers
{
    public class WebScraping : Controller
    {
        public IActionResult Index()
        {
            List<ScrapElementItems> ScrapElementItemss = new List<ScrapElementItems>();
            var web = new HtmlWeb();
            var doc = web.Load("https://www.rekrute.com/offres-emploi-afrique.html");

            foreach (var item in doc.DocumentNode.SelectNodes("//li[@class='post-id']"))
            {
                var checkVarItem = item;
                string title = item.ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText.Trim();
                string link = "https://www.rekrute.com/" + item.ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[1].ChildNodes[1].GetAttributeValue("href", null).Trim();

                ScrapElementItemss.Add(new ScrapElementItems()
                {
                    title = title,
                    link  = link
                });
            }
            return View(ScrapElementItemss);
        }
    }
}
