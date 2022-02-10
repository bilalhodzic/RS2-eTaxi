using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Model.Others
{
    public class Helper
    {
        public static string GenerateLink(string Name)
        {
            var regex = @"\s+";
            Name = Name.Trim().ToLower();
            Name = Regex.Replace(Name, regex, "-");
            Name = Uri.EscapeUriString(Name);

            return Name;
        }

        public static T UploadImage<T>(IFormFile file, string ImagePath) where T : new()
        {
            if (file != null)
            {
                string uploadFolder = "Resources/";
                var guid = Guid.NewGuid().ToString();
                string uploadFileName = guid + "_" + file.FileName;
                string filePath = uploadFolder + uploadFileName;
                string dbPathName = guid + "_" + Uri.EscapeDataString(file.FileName);
                string dbPath = ImagePath + dbPathName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //if (file.FileName.Contains(".jpg") || file.FileName.Contains(".png") || file.FileName.Contains(".jfif"))
                    //{
                    //    using var image = Image.Load(file.OpenReadStream());
                    //    ////100: height
                    //    ////100: width
                    //    //image.Mutate(x => x.Resize(650, 500));
                    //    //var encoder = new JpegEncoder()
                    //    //{
                    //    //    Quality = 40 //Use variable to set between 5-30 based on your requirements
                    //    //};
                    //    image.SaveAsPng(stream);
                    //}
                    //else
                        file.CopyTo(stream);
                }

                dynamic result = new T();
                result.FileName = uploadFileName;
                result.OriginalName = file.FileName;
                result.Url = dbPath;

                return result;
            }
            return default;
        }

        public static void RemoveImage(string name, string url)
        {
            if (url.Contains("/Resources/"))
            {
                try
                {
                    File.Delete(@"Resources/" + name);
                    Console.WriteLine($"[BRISANJE] Slika {name} uspješno obrisana. ");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
