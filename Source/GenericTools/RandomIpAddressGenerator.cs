using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTools
{
    using System.CodeDom.Compiler;

    public class RandomIpAddressGenerator
    {
        private const string subnet = "167.145.23.";

        private static Random random = new Random();

        public static string Generate()
        {
            return subnet + random.Next(1, 243);
        }
    }
}
