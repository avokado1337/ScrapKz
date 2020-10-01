using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Web;

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

        //Getting product name and title

        var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='bx-catalog-middle-part']//div[@class='bx_catalog_item_articul']");

        foreach (var ProductsHtmlSeparate in node)
        {
            Console.WriteLine(ProductsHtmlSeparate.InnerText.Trim('\r', '\n', '\t'));

            Console.WriteLine();
        }

        


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
                    Console.WriteLine(ProductsHtmlSeparate.InnerText.Trim('\r', '\n', '\t'));

                    Console.WriteLine();
                }

            }
            else
            {
                Loop = false;
            }
        }




    }
}
