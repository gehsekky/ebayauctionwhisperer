using System;
using System.Collections.Generic;
using System.Configuration;

namespace ebayauctionwhisperer
{
    class EbayAuctionWhisperer
    {
        public List<EbayAuctionWhispererItem> Items;
  
        public EbayAuctionWhisperer()
        {
            Console.WriteLine("EbayAuctionWhisperer Constructor");

            this.Items = new List<EbayAuctionWhispererItem>();
        }

        public void RunItems()
        {
            Console.WriteLine("EbayAuctionWhisperer.RunItems()");

            // run items
            Console.WriteLine("Initiating foreach loop for item threads");
            foreach (EbayAuctionWhispererItem item in this.Items)
            {
                item.Run();
            }
        }
    }
}
