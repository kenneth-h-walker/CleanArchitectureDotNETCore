using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BookstoreIoC
{
    public class GlobalVars
    {
        private static readonly GlobalVars mInstance = new GlobalVars();
        private GlobalVars() { }
        public static GlobalVars Instance {get{return mInstance;}}

        public IConfiguration Configuration { get; set; }
    }
}
