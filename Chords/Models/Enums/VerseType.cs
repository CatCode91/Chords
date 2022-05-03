using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Chords.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerseType
    {
        Verse,
        Chorus,
    }
}
