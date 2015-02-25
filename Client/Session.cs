using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentQueue.Library;

namespace Client
{
    public class Session
    {
        private JsonRequestHandler jsonreq;

        public Session(string domain)
        {
            jsonreq = new JsonRequestHandler(domain);
        }

        public bool TorrentsAvailable()
        {
            var json = jsonreq.Request("/torrents/", RequestMethods.GET);

            int count = json.Value<int>("count");

            if (count == 0)
                return false;
            else return true;
        }


        public Torrent FetchTorrent()
        {
            var json = jsonreq.Request("/torrents/", RequestMethods.PUT);


            string link = json.Value<string>("link");

            return new Torrent(link);
        }

        public List<Torrent> FetchTorrents()
        {
            List<Torrent> list = new List<Torrent>();

            while (TorrentsAvailable())
                list.Add(FetchTorrent());

            return list;
        }
    }
}
