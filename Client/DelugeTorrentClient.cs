using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class DelugeTorrentClient : ITorrentClient
    {

        public string dir { get; set; }
        public string executableName = "deluge-console.exe";
        private string daemon = "deluged.exe";

        public DelugeTorrentClient(string dir)
        {
            this.dir = dir;
            InitializeClient();
        }

        public void AddTorrent(string path)
        {
            string clientpath = dir + "\\" + executableName;
            string arguments = string.Format("add \" {0} \"", path);
                
                ;

            Process p = new Process();
            p.StartInfo.FileName = clientpath;
            p.StartInfo.Arguments = @arguments;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();

            var output = p.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }

        public void AddMagnet(string path)
        {
            throw new NotImplementedException();
        }

        public void InitializeClient()
        {
            
            Process.Start(dir + "\\" + daemon);
        }
    }
}
