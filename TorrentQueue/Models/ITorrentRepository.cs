using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentQueue.Models
{
    interface ITorrentRepository
    {
        IEnumerable<Torrent> GetAll();
        Torrent Add(Torrent t);
        bool Update();
    }
}
