using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TorrentQueue.Models;

namespace TorrentQueue.Controllers
{
    [RoutePrefix("torrentqueue")]
    public class TorrentQueueController : ApiController
    {
        private static string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/list.txt");
        private static object accessObj = new object();

        private IHttpActionResult NoContent()
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
        private IHttpActionResult NoContent<T>(T value)
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent, value));
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            if (!File.Exists(FilePath))
                return NoContent(new object[0]);

            string[] links;
            lock (accessObj)
                links = File.ReadAllLines(FilePath);

            return Ok(links.Select(x => new { link = x }));
        }

        [HttpGet, Route("top")]
        public IHttpActionResult GetTop()
        {
            if (!File.Exists(FilePath))
                return NoContent(new { });

            string link;
            lock (accessObj)
            {
                string[] lines = File.ReadAllLines(FilePath);
                link = lines.Length > 0 ? lines[0] : null;
            }

            if (link == null)
                return NoContent(new { });
            else
                return Ok(new { link = link });
        }

        [HttpDelete, Route("top")]
        public IHttpActionResult DeleteTop()
        {
            if (!File.Exists(FilePath))
                return NoContent();

            bool any;
            lock (accessObj)
            {
                string[] lines = File.ReadAllLines(FilePath);
                any = lines.Length > 0;
                if (any)
                    File.WriteAllLines(FilePath, lines.Skip(1));
            }

            if (any)
                return Ok();
            else
                return NoContent();
        }

        [HttpPost, Route("bottom")]
        public IHttpActionResult PostBottom([FromBody]NewTorrent torrent)
        {
            if (torrent == null)
                return BadRequest();

            lock (accessObj)
            {
                string[] newData = new string[] { torrent.link };

                if (!File.Exists(FilePath))
                    File.WriteAllLines(FilePath, newData);
                else
                {
                    string[] lines = File.ReadAllLines(FilePath);
                    File.WriteAllLines(FilePath, lines.Concat(newData));
                }
            }

            return Ok();
        }
    }
}
