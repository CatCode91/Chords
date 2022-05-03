using Newtonsoft.Json;
using System;
using System.IO;

namespace Chords
{
    //Don't pay much attention to this class, it for service purposes, to save/read files from disk

    public class FileHelper
    {
        private FileInfo _fileInfo;

        public T ReadJsonFrom<T>(string filename)
        {
            T t = default(T);
            string file = $"{Environment.CurrentDirectory}/{filename}";
            string dir = $"{Path.GetDirectoryName(file)}/";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(file))
                return t;

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

        public void SaveJsonToFile<T>(string filename, T data)
        {
            string file = $"{Environment.CurrentDirectory}/{filename}";
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            _fileInfo = new FileInfo(file);
            if (!_fileInfo.Directory.Exists)
                Directory.CreateDirectory(_fileInfo.Directory.FullName);
            File.WriteAllText(file, json);
        }

        public void SavePage(string filename, string text)
        {
            string file = $"{Environment.CurrentDirectory}/Templates/{filename}";
            _fileInfo = new FileInfo(file);
            if (!_fileInfo.Directory.Exists)
                Directory.CreateDirectory(_fileInfo.Directory.FullName);
            File.WriteAllText(file, text);
        }

        public string ReadPage(string filename)
        {
            string file = $"{Environment.CurrentDirectory}/Templates/{filename}";
            _fileInfo = new FileInfo(file);
            if (!_fileInfo.Directory.Exists)
                Directory.CreateDirectory(_fileInfo.Directory.FullName);
            return File.ReadAllText(file);
        }
    }
}
