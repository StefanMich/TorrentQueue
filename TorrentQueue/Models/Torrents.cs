using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorrentQueue.Models
{
    public class Torrents
    {
        private Stack<Torrent> torrentStack;

        public Torrents()
        {
            torrentStack = new Stack<Torrent>();

            torrentStack.Push(new Torrent("http://www.torlock.com/tor/3736191.torrent"));
        }
        public int count
        {
            get { return torrentStack.Count; }
            set { }
        }

        public Stack<Torrent> torrents { get { return torrentStack; } set { } }

        public Torrent Pop()
        {
            return torrentStack.Pop();
        }

        public void Push(Torrent t)
        {
            torrentStack.Push(t);
        }
    }
}