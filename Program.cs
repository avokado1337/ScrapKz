using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        }

        foreach (var itemLink in result1)
        {
            var htmlDocLinks = htmlWeb.Load(itemLink);


            //Model names of GPU
            var gpuModelName = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Модель')]");

            foreach (var linksGPU in gpuModelName)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

           

            //Frequency of GPUs
            var gpuVideoFrequency = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Частота видеопроцессора')]");

            foreach (var linksGPU in gpuVideoFrequency)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Memory Frequency of GPUs
            var gpuMemoryFrequency = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Частота видеопамяти')]");

            foreach (var linksGPU in gpuMemoryFrequency)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Video Memory type
            var gpuMemoryType = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Тип видеопамяти')]");

            foreach (var linksGPU in gpuMemoryType)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Video Memory size
            var gpuMemorySize = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Объем видеопамяти')]");

            foreach (var linksGPU in gpuMemorySize)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Video Memory type
            var gpuMemoryWidth = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Разрядность шины видеопамяти')]");

            foreach (var linksGPU in gpuMemoryWidth)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Universal processor count
            var gpuProcessorCount = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество универсальных')]");

            foreach (var linksGPU in gpuProcessorCount)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Connection type
            var gpuConnectionType = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Разъемы')]");

            foreach (var linksGPU in gpuConnectionType)
            {
                Console.WriteLine(linksGPU.InnerText);
            }

            //Prices
            var productPrices = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");

            foreach (var linksGPU in productPrices)
            {
                Console.WriteLine(linksGPU.InnerText + "\n");
            }

        }








        //while (Loop == true)
        //{

        //    var NextPageCheck = htmlDoc.DocumentNode.SelectNodes("//li[@class='bx-pag-next']/a").ToList();

        //    if (NextPageCheck.Count != 0)
        //    {
        //        string link = url + NextPageCheck[0].Attributes["href"].Value;

        //        var urlDecode = HttpUtility.HtmlDecode(link);
        //        htmlDoc = htmlWeb.Load(urlDecode);


        //        htmlDoc = htmlWeb.Load(link);

        //        foreach (var itemLink in result1)
        //        {
        //            var htmlDocLinks = htmlWeb.Load(itemLink);

        //            var nodeLinks = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li");

        //            var priceLinks = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");




        //            foreach (var linksGPU in nodeLinks)
        //            {
        //                Console.WriteLine(linksGPU.InnerText.Trim());
        //            }
        //            foreach (var priceGPU in priceLinks)
        //            {
        //                Console.WriteLine(priceGPU.InnerText + "\n");
        //            }

        //        }
        //    }
        //    else
        //    {
        //        Loop = false;
        //    }
        //    }




        }
    }
