using Chords.Model;
using System;

namespace Chords
{
    public class SongHelper
    {
        private const string _fileName = "Test.html";
        private FileHelper _fileHelper = new FileHelper();

        /// <summary>
        /// Creates Test HTML page on disk
        /// </summary>
        /// <param name="song">Object of the song</param>
        /// <returns>Returns full path to created file</returns>
        public string CreatePage(Song song) 
        {
            var page = _fileHelper.ReadPage("TemplatePage.html");

            string versesBlocks = null;

            foreach (var verse in song.Verses) 
            {
                versesBlocks += $@"<div class=""{verse.VerseType.ToString().ToLower()}"">";

                //if verse contains chords, select them into the separate blocks (spans)
                if (verse.Text.Contains('[')) 
                {
                    versesBlocks += ParseChords(verse.Text);
                } 
                //if not, place block it as usual verse
                else
                {
                    versesBlocks += verse.Text;
                }
                versesBlocks += "</div>";
            }

            //look Templates/TemplatePage.html - code below will replace block on this page and creates new page with formatted text
            page = page.Replace("%songBody%", versesBlocks);
            _fileHelper.SavePage(_fileName, page);
            return $"{Environment.CurrentDirectory}/Templates/{_fileName}";
        }

        /// <summary>
        /// Processes verses with chords
        /// </summary>
        /// <param name="unparsedText">Awaits verse from song object</param>
        /// <returns>Returns formatted HTML with chords</returns>
        private string ParseChords(string unparsedText)
        {
            //take all blocks with chords
            string[] parts = unparsedText.Split('[');

            string verse = @"<p class=""block show-chords"">";
            
            //separate chords and text, and place them in other blocks
            foreach (var s in parts)
            {
                if (s.Length == 0)
                    continue;
                    
                string chord = s.Substring(0, s.IndexOf(']'));
                string text = s.Substring(s.IndexOf(']')+1);
                verse += @$"<span class=""chord"">{chord}</span>{text}";
            }
            verse += "</p>";

            return verse;
        }
    }
}
