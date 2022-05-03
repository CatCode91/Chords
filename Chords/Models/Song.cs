using System.Collections.Generic;

namespace Chords.Model
{
    public class Song
    {
        public string Title { get; set; }
        public string KeyChords { get; set; }
        public List<Verse> Verses {get;set;}
    }
}
