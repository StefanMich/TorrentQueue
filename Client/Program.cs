using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public const int INTERVAL = 10; //repeat interval in minutes
        public const int SECONDSPERMUNUTE = 60;
        public const int MILLISECONDSPERSECOND = 1000;

        static ITorrentClient torrentClient;
        static Session session;

        static void Main(string[] args)
        {

            WebClient client = new WebClient() { Credentials = new NetworkCredential("admin", "admin") };
            StreamReader Reader = new StreamReader(client.OpenRead("http://localhost:" + 8080 + "/gui/token.html"));
            string token = Reader.ReadToEnd();
            token = token.Split('>')[2].Split('<')[0];


            return;


            torrentClient = new DelugeTorrentClient(@"C:\Program Files (x86)\Deluge");
            session = new Session("http://localhost:9132/api/");


            System.Timers.Timer timer = new System.Timers.Timer(10*MILLISECONDSPERSECOND);
            timer.Elapsed += timer_fetch;

            timer.Start();
            timer_fetch(null, null); // run initial fetch

            ConsoleKeyInfo key;
            while ((key = Console.ReadKey()).Key != ConsoleKey.Q)
            {
                FetchAndAdd();
                Console.WriteLine("\nforced fetch done");
            }
        }

        static void timer_fetch(object sender, System.Timers.ElapsedEventArgs e)
        {
            FetchAndAdd();
            Console.WriteLine("done");
        }

        private static void FetchAndAdd()
        {
            var list = session.FetchTorrents();
            AddTorrents(torrentClient, list);
        }

        private static void AddTorrents(ITorrentClient torrentClient, List<Torrent> list)
        {
            WebClient web = new WebClient();

            foreach (var torrent in list)
            {
                string temppath = @"C:\Users\Stefan Micheelsen\test.html";

                web.DownloadFile(torrent.Link, temppath);

                torrentClient.AddTorrent(temppath);
            }
        }
    }
}
