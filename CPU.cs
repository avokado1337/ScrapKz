using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ScrapKz
{
    class CPU
    {
        public static void shopkzCPU()
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool Loop = true;

            var url = @"https://shop.kz";

            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url + "/protsessory/filter/almaty-is-v_nalichii-or-ojidaem-or-dostavim/apply/?PAGEN_1=1");

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


                //The type of the CPU
                var cpuType = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Тип процессора:')]");

                foreach (var linksCPU in cpuType)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }



                //Number of sockets
                var cpuSocket = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Сокет')]");

                foreach (var linksCPU in cpuSocket)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Number of cores
                var cpuCores = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество ядер')]");

                foreach (var linksCPU in cpuCores)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //CPU threads number
                var cpuThreads = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество потоков')]");

                foreach (var linksCPU in cpuThreads)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //CPU frequency
                var cpuFrequency = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Тактовая частота')]");

                foreach (var linksCPU in cpuFrequency)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //CPU microarchitecture
                var cpuArchitecture = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Микроархитектура')]");

                foreach (var linksCPU in cpuArchitecture)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Cache size
                var cpuCache = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Объем кэша')]");

                foreach (var linksCPU in cpuCache)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Integrated graph system
                var cpuIGS = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Интегрированная графическая система')]");

                foreach (var linksCPU in cpuIGS)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Techprocess
                var cpuTechprocess = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Техпроцесс')]");

                foreach (var linksCPU in cpuTechprocess)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Estimated power
                var cpuPower = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Расчетная мощность')]");

                foreach (var linksCPU in cpuPower)
                {
                    Console.WriteLine(linksCPU.InnerText);
                }

                //Prices
                var productPrices = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");

                foreach (var linksCPU in productPrices)
                {
                    Console.WriteLine(linksCPU.InnerText + "\n");
                }

            }







            //Getting all of that from next pages 
            while (Loop == true)
            {

                var NextPageCheck = htmlDoc.DocumentNode.SelectNodes("//li[@class='bx-pag-next']/a").ToList();

                if (NextPageCheck.Count != 0)
                {
                    string link = url + NextPageCheck[0].Attributes["href"].Value;

                    var urlDecode = HttpUtility.HtmlDecode(link);
                    htmlDoc = htmlWeb.Load(urlDecode);


                    htmlDoc = htmlWeb.Load(link);

                    var nextPageNodeCPU = htmlDoc.DocumentNode.SelectNodes("//div[@class='bx-catalog-middle-part']//div[@class='bx_catalog_item_title']//a[@href]");

                    List<string> nextPageListCPU = new List<string>();

                    foreach (var ProductsHtmlSeparate in nextPageNodeCPU)
                    {
                        var ItemPage = ((url + ProductsHtmlSeparate.GetAttributeValue("href", null)));
                        List<string> nextPageCPU = ItemPage.Split(new char[] { ',' }).ToList();
                        //This is bad and I don't like how this is done but I haven't found any way to do this better yet.
                        nextPageListCPU.AddRange(nextPageCPU);
                    }

                    foreach (var itemLink in nextPageListCPU)
                    {
                        var htmlDocLinks = htmlWeb.Load(itemLink);


                        //The type of the CPU
                        var cpuType = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Тип процессора:')]");

                        foreach (var linksCPU in cpuType)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }



                        //Number of sockets
                        var cpuSocket = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Сокет')]");

                        foreach (var linksCPU in cpuSocket)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Number of cores
                        var cpuCores = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество ядер')]");

                        foreach (var linksCPU in cpuCores)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //CPU threads number
                        var cpuThreads = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество потоков')]");

                        foreach (var linksCPU in cpuThreads)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //CPU frequency
                        var cpuFrequency = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Тактовая частота')]");

                        foreach (var linksCPU in cpuFrequency)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //CPU microarchitecture
                        var cpuArchitecture = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Микроархитектура')]");

                        foreach (var linksCPU in cpuArchitecture)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Cache size
                        var cpuCache = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Объем кэша')]");

                        foreach (var linksCPU in cpuCache)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Integrated graph system
                        var cpuIGS = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Интегрированная графическая система')]");

                        foreach (var linksCPU in cpuIGS)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Techprocess
                        var cpuTechprocess = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Техпроцесс')]");

                        foreach (var linksCPU in cpuTechprocess)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Estimated power
                        var cpuPower = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Расчетная мощность')]");

                        foreach (var linksCPU in cpuPower)
                        {
                            Console.WriteLine(linksCPU.InnerText);
                        }

                        //Prices
                        var productPrices = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");

                        foreach (var linksCPU in productPrices)
                        {
                            Console.WriteLine(linksCPU.InnerText + "\n");
                        }

                    }
                }
                else
                {
                    Loop = false;
                }
            }

        }
    }
}
