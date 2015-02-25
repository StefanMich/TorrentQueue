using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorrentQueue.Models;

namespace TorrentQueue.Controllers
{
    public class TorrentsController : ApiController
    {
        static readonly ITorrentRepository repository = new TorrentRepository();

        public Torrents GetAllTorrents()
        {
            return repository.GetAll();
        }


        public HttpResponseMessage PostTorrent(Torrent t)
        {
            if (t.link == null)
                throw new HttpResponseException(HttpStatusCode.Conflict);
            repository.Add(t);

            var response = Request.CreateResponse<Torrent>(HttpStatusCode.Created, t);
            return response;
        }

        public HttpResponseMessage PutTorrent()
        {
            HttpResponseMessage response;

            if (repository.StackEmpty())
                response = Request.CreateResponse(HttpStatusCode.Gone);
            else
            {
                response = Request.CreateResponse<Torrent>(repository.PopNext());

            }

            return response;
        }

    }
}
