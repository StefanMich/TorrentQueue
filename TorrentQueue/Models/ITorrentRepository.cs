using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentQueue.Models
{
    interface ITorrentRepository
    {
        Torrents GetAll();
        Torrent Add(Torrent t);
        Torrent PopNext();
        bool StackEmpty();
        int Count();
    }
}
