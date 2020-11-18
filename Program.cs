using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        GetHtml();

        Console.ReadLine();
    }

      static void GetHtml()
    {
        Console.OutputEncoding = Encoding.UTF8;

        bool Loop = true;

        var url = @"https://shop.kz";

        var htmlWeb = new HtmlWeb();

        var htmlDoc = htmlWeb.Load(url + "/videokarty/filter/almaty-is-v_nalichii-or-ojidaem-or-dostavim/apply/?PAGEN_1=1");

        //Getting links of products

        var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='bx-catalog-middle-part']//div[@class='bx_catalog_item_title']//a[@href]");

        List<string> result1 = new List<string>();

        foreach (var ProductsHtmlSeparate in node)
        {
            var ItemPage = ((url + ProductsHtmlSeparate.GetAttributeValue("href", null)));
            List<string> result = ItemPage.Split(new char[] { ',' }).ToList();
            //This is bad and I don't like how this is done but I haven't found any way to do this better yet.
            result1.AddRange(result);


            //foreach (var ItemInfo in result)
            //{
            //    var htmlDocLink = htmlWeb.Load(ItemInfo);
            //    var ItemNode = htmlDocLink.DocumentNode.SelectNodes("//div[@class='bx-item-container']//ul[@class='bx-short-desc']");
        }


        foreach (var itemLink in result1)
        {
            var htmlDocLinks = htmlWeb.Load(itemLink);

            var nodeLinks = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']");

            foreach (var linksGPU in nodeLinks)
            {
                Console.WriteLine(linksGPU.InnerText.Trim());
            }
        }







        /*
        while (Loop == true)
        {

            var NextPageCheck = htmlDoc.DocumentNode.SelectNodes("//li[@class='bx-pag-next']/a").ToList();

            if (NextPageCheck.Count != 0)
            {
                string link = url + NextPageCheck[0].Attributes["href"].Value;

                var urlDecode = HttpUtility.HtmlDecode(link);
                htmlDoc = htmlWeb.Load(urlDecode);


                htmlDoc = htmlWeb.Load(link);

                node = htmlDoc.DocumentNode.SelectNodes(("//div[@class='bx-catalog-middle-part']//div[@class='bx_catalog_item_articul']"));

                foreach (var ProductsHtmlSeparate in node)
                {
                    File.AppendAllText(@"C:\Users\Sultan\Desktop\WriteLines.txt", ProductsHtmlSeparate.InnerText.Trim());

                }

            }
            else
            {
                Loop = false;
            }
        }
        */



    }
}
