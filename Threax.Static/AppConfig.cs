using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Static
{
    public class AppConfig
    {
        /// <summary>
        /// The base path the app lives on. Used for cookie paths and to enforce the url spelling.
        /// Can be null to live on the root path.
        /// </summary>
        public string PathBase { get; set; }

        /// <summary>
        /// If the file is not a recognized content-type should it be served? Default: false.
        /// </summary>
        public bool ServeUnknownFileTypes { get; set; } = false;
    }
}
