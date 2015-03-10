using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace ebayauctionwhisperer
{
    class Program
    {
        /// <summary>
        /// application driver function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // initialize main manager class
            EbayAuctionWhisperer eaw = new EbayAuctionWhisperer();

            // read xml file
            XDocument doc = XDocument.Load(ConfigurationManager.AppSettings["Manager.NameOfItemsConfigFile"]);
            var items = (from n in doc.Root.Elements()
                         where n.Name.LocalName == "item"
                         select new
                         {
                             Id = n.Elements("id").Single().Value,
                             Max = n.Elements("max").Single().Value
                         });

            // create whisperer items
            foreach (var item in items)
            {
                EbayAuctionWhispererItem wItem = new EbayAuctionWhispererItem(item.Id, item.Max);
                eaw.Items.Add(wItem);
            }
            Console.WriteLine("items list has {0} entries", items.Count());

            // start item threads
            eaw.RunItems();

            // end program
            Console.WriteLine("Main program thread is terminating");
            Console.ReadKey();
        }
    }
}
