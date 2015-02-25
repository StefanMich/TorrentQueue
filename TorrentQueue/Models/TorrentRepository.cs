using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorrentQueue.Models
{
    public class TorrentRepository : ITorrentRepository
    {
        Torrents torrents;

        public TorrentRepository()
        {
            torrents = new Torrents();

        }

        public bool StackEmpty()
        {
            if (torrents.count == 0)
                return true;
            else return false;
        }

        public Torrents GetAll()
        {
            return torrents;
        }

        public Torrent Add(Torrent t)
        {   
            torrents.Push(t);
            return t;
        }

        public Torrent PopNext()
        {
            return torrents.Pop();
        }


        public int Count()
        {
            return torrents.count;
        }
    }
}