using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ScrapKz
{
    class Motherboards
    {
            public static void shopkzMotherboard()
            {
                Console.OutputEncoding = Encoding.UTF8;

                bool Loop = true;

                var url = @"https://shop.kz";

                var htmlWeb = new HtmlWeb();

                var htmlDoc = htmlWeb.Load(url + "/materinskie-platy/filter/almaty-is-v_nalichii-or-ojidaem-or-dostavim/apply/?PAGEN_1=1");

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


                    //Socket
                    var mothboardSocket = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Сокет:')]");

                    foreach (var linksMB in mothboardSocket)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }



                    //Chipset
                    var mothboardChipset = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Чипсет')]");

                    foreach (var linksMB in mothboardChipset)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //Form factor
                    var mothboardFactor = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Форм-фактор')]");

                    foreach (var linksMB in mothboardFactor)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //Memory slots number
                    var mothboardMemorySlots = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество слотов памяти')]");

                    foreach (var linksMB in mothboardMemorySlots)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //SATA numbers
                    var mothboardSATA = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество разъемов')]");

                    foreach (var linksMB in mothboardSATA)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //PCI numbers
                    var mothboardPCI = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество слотов PCI')]");

                    foreach (var linksMB in mothboardPCI)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //Pins
                    var mothboardPins = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Коннекторы питания')]");

                    foreach (var linksMB in mothboardPins)
                    {
                        Console.WriteLine(linksMB.InnerText);
                    }

                    //Prices
                    var productPrices = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");

                    foreach (var linksMB in productPrices)
                    {
                        Console.WriteLine(linksMB.InnerText + "\n");
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

                        var nextPageNodeMB = htmlDoc.DocumentNode.SelectNodes("//div[@class='bx-catalog-middle-part']//div[@class='bx_catalog_item_title']//a[@href]");

                        List<string> nextPageListMBU = new List<string>();

                        foreach (var ProductsHtmlSeparate in nextPageNodeMB)
                        {
                            var ItemPage = ((url + ProductsHtmlSeparate.GetAttributeValue("href", null)));
                            List<string> nextPageMB = ItemPage.Split(new char[] { ',' }).ToList();
                            //This is bad and I don't like how this is done but I haven't found any way to do this better yet.
                            nextPageListMBU.AddRange(nextPageMB);
                        }

                        foreach (var itemLink in nextPageListMBU)
                        {
                            var htmlDocLinks = htmlWeb.Load(itemLink);


                            //Socket
                            var mothboardSocket = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Сокет:')]");

                            foreach (var linksMB in mothboardSocket)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }



                            //Chipset
                            var mothboardChipset = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Чипсет')]");

                            foreach (var linksMB in mothboardChipset)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //Form factor
                            var mothboardFactor = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Форм-фактор')]");

                            foreach (var linksMB in mothboardFactor)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //Memory slots number
                            var mothboardMemorySlots = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество слотов памяти')]");

                            foreach (var linksMB in mothboardMemorySlots)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //SATA numbers
                            var mothboardSATA = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество разъемов')]");

                            foreach (var linksMB in mothboardSATA)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //PCI numbers
                            var mothboardPCI = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Количество слотов PCI')]");

                            foreach (var linksMB in mothboardPCI)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //Pins
                            var mothboardPins = htmlDocLinks.DocumentNode.SelectNodes("//ul[@class='bx-short-desc']/li[contains(text(), 'Коннекторы питания')]");

                            foreach (var linksMB in mothboardPins)
                            {
                                Console.WriteLine(linksMB.InnerText);
                            }

                            //Prices
                            var productPrices = htmlDocLinks.DocumentNode.SelectNodes("//div[@title='Цена в интернет-магазине']");

                            foreach (var linksMB in productPrices)
                            {
                                Console.WriteLine(linksMB.InnerText + "\n");
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
