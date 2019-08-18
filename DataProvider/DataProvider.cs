using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataProvider
{
    public class UnderlyingGenerator
    {
        public static int counter = 0;


        public Underlying GetUnderlying()
        {

            Random rnd = new Random();

            

            var path = $"ToRemove{rnd.Next(1, 5)};\\Level{rnd.Next(1, 32000)}\\Some{rnd.Next(1, 5)}\\cat{rnd.Next(1, 5)}\\dog{rnd.Next(1, 5)}\\underlyingName{counter}";
            var id = $"MyUniqueId={counter}";

            counter++;

            Thread.Sleep(100);

            return new Underlying(path, id);
        }
    }
}
