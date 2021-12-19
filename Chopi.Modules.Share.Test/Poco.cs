using System.Collections.Generic;

namespace Chopi.Modules.Share.Test
{
    class Poco
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<NotPoco> NotPocos { get; set; }
    }

    class NotPoco 
    {
        public string NotName { get; set; }
    }
}
