﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorrentQueue.Library;

namespace TorrentQueue.Models
{
    public class Torrent
    {
        public string link { get; set; }

        public Torrent()
        {

        }

        public Torrent(string link)
        {
            this.link = link;
        }

       

    }
}