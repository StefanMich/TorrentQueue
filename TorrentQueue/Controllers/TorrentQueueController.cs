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
    }
}
