using System;
using System.Web.Http;

namespace TorrentQueue.Models
{
    public class NewTorrent
    {
        private string _link;
        public string link
        {
            get { return _link; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                // Handle formatting checks

                this._link = value;
            }
        }
    }
}