using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TorrentQueue.Controllers
{
    [RoutePrefix("torrentqueue")]
    public class TorrentQueueController : ApiController
    {
        private static string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/list.txt");
        private static object accessObj = new object();

        [HttpGet, Route("top")]
        public IHttpActionResult GetTop()
        {
            if (!File.Exists(FilePath))
                return NotFound();

            string link;
            lock (accessObj)
            {
                string[] lines = File.ReadAllLines(FilePath);
                link = lines.Length > 0 ? lines[0] : null;
            }

            if (link == null)
                return NotFound();
            else
                return Ok(new { link = link });
        }
    }
}
