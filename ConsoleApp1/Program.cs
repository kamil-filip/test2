using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            UnderlyingGenerator dp = new UnderlyingGenerator();

            while (UnderlyingGenerator.counter < 32000)
            {

                var und = dp.GetUnderlying();

                Console.WriteLine($"Path is: {und.Path}, Id is: {und.Id}");
            }
            //while(dp.counter < 3200)


                //Console.WriteLine()
            }
    }
}
