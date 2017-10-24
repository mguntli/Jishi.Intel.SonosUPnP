using Jishi.Intel.SonosUPnP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SonosUPnPConsole {
    class Program {
        static void Main(string[] args) {
            SonosDiscovery d = new SonosDiscovery();
            d.StartScan();
            // give it some time so that the results can arrive
            Thread.Sleep(10000);

            // favorites are global and not related to a specific zone
            SonosPlayer player = d.Players.First();
            IList<SonosItem> favorites = player.GetFavorites();
            int count = 0;
            foreach (SonosItem favorite in favorites) {
                count++;
                Console.WriteLine("Favorite[" + count + "]: ");
                Console.WriteLine("\t- Title = " + favorite.DIDL.Title);
                Console.WriteLine("\t- Uri = " + favorite.Track.Uri);
            }
        }
    }
}
