using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Torrent
    {
        public string Link { get; set; }

        public Torrent()
        {

        }

        public Torrent(string link)
        {
            Link = link;
        }
    }
}
