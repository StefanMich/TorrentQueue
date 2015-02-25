using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface ITorrentClient
    {
        void InitializeClient();
        void AddTorrent(string path);
        void AddMagnet(string path);
    }
}
