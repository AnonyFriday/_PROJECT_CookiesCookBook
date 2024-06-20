using _03_CookiesCookbook_Practise.FileAccess;

namespace _03_CookiesCookbook_Practise
{
    public class FileMetaData
    {
        public string FileName { get; set; }

        public FileFormat Format { get; set; }

        public FileMetaData(string fileName, FileFormat format)
        {
            FileName = fileName;
            Format = format;
        }

        public string ToPath() => $"{FileName}.{Format.AsFileExtension()}";
    }
}


