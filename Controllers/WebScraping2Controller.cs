using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using WebScraping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraping.Controllers
{
    public class WebScraping2 : Controller
    {
        public IActionResult Index()
        {
            List<ScrapElementItems> ScrapElementItemss = new List<ScrapElementItems>();
            var web = new HtmlWeb();
            var doc = web.Load("https://artesanaldaterra.com/categoria-produto/topicos/");
            var specitem = doc.DocumentNode.SelectSingleNode("//h2[@class='woocommerce-loop-product__title']");
            var specmore = specitem.InnerText;

            var docw = web.Load("https://www.w3schools.com/html/html_intro.asp");
            var specw = docw.DocumentNode.SelectSingleNode("//div[@id='leftmenuinnerinner']");
            var specwmore = specw.ChildNodes[3].InnerText;

            var docwhat = web.Load("https://www.b3.com.br/pt_br/market-data-e-indices/servicos-de-dados/market-data/cotacoes/");
            var specwhat = docwhat.DocumentNode.SelectSingleNode("//div[@class='titulo-internas']");
            var specwmorehat = specwhat.ChildNodes[1].InnerText;


            foreach (var item in doc.DocumentNode.SelectNodes("//h2[@class='woocommerce-loop-product__title']"))
            {
                var checkVarItem = item;
                string title = item.InnerText.Trim();
                //string title = item.ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[1].ChildNodes[1].InnerText.Trim();
                //string link = "https://www.rekrute.com/" + item.ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[1].ChildNodes[1].GetAttributeValue("href", null).Trim();

                ScrapElementItemss.Add(new ScrapElementItems()
                {
                    title = title + " - " + specmore + " - " + specwmore + " - " + specwmorehat,
                    //link  = link
                });
            }
            return View(ScrapElementItemss);
        }
    }
}