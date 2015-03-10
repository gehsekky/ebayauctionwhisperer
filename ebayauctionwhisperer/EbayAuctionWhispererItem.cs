using System;
using System.Configuration;
using System.Threading;

namespace ebayauctionwhisperer
{
    class EbayAuctionWhispererItem
    {
        string ItemId;
        double MaxPrice;

        public EbayAuctionWhispererItem(string itemId, string maxPrice)
        {
            this.ItemId = itemId;
            double tempMax;
            if (!double.TryParse(maxPrice, out tempMax))
            {
                throw new Exception(string.Format("Could not parse valid double from maxPrice = {0}", maxPrice));
            }
            this.MaxPrice = tempMax;
        }

        public void Run()
        {
            Console.WriteLine("EbayAuctionWhispererItem.Run({0})", this.ItemId);

            Thread thread = new Thread(() => BeginMainLoop(this.ItemId, this.MaxPrice));
            thread.Start();
        }

        static void BeginMainLoop(string itemId, double maxPrice)
        {
            Console.WriteLine("EbayAuctionWhispererItem.BeginMainLoop({0})", itemId);

            // get seconds from end to start doing stuff
            int activeWindowInterval;
            if (!int.TryParse(ConfigurationManager.AppSettings["Item.ActiveWindowInterval"], out activeWindowInterval))
            {
                throw new Exception("Could not parse valid int from Item.ActiveWindowInterval");
            }

            // get seconds between calls in non active window
            int iterationIntervalInNonActiveWindow;
            if (!int.TryParse(ConfigurationManager.AppSettings["Item.IterationIntervalInNonActiveWindow"], out iterationIntervalInNonActiveWindow))
            {
                throw new Exception("Could not parse valid int from Item.IterationIntervalInNonActiveWindow");
            }

            // get seconds between calls in active window
            int iterationIntervalInActiveWindow;
            if (!int.TryParse(ConfigurationManager.AppSettings["Item.IterationIntervalInActiveWindow"], out iterationIntervalInActiveWindow))
            {
                throw new Exception("Could not parse valid int from Item.IterationIntervalInActiveWindow");
            }

            // set up loop-specific vars
            DateTime? lastTimeChecked = null;

            // execute main loop
            while (true)
            {
                // if we are not within auction action window, do nothing and sleep for a sec

                // update auction data

                // check if there is already a bid

                // check if we are the current high bidder

                // if not, bid on item

                // update loop vars
                lastTimeChecked = DateTime.Now;
            }
        }
    }
}
