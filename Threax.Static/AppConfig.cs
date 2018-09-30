using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Static
{
    public class AppConfig
    {
        /// <summary>
        /// If the file is not a recognized content-type should it be served? Default: false.
        /// </summary>
        public bool ServeUnknownFileTypes { get; set; } = false;
    }
}
