using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorrentQueue.Models
{
    public class TorrentList
    {
        private List<string> torrents { get; set; }

        public TorrentList()
        {
            torrents = new List<string>();
        }
    }
}