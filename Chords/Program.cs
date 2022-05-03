using Chords.Model;
using System.Diagnostics;

namespace Chords
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileHelper fileHelper = new FileHelper();
            SongHelper songHelper = new SongHelper();
            
            var song = fileHelper.ReadJsonFrom<Song>("song.json");
            var htmlFile = songHelper.CreatePage(song);

            OpenFile(htmlFile);
        }

        private static void OpenFile(string htmlFile)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(htmlFile)
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}
