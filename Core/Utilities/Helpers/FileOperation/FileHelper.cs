using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileOperation
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = NewPath(file);
            using (FileStream fileStream = new FileStream(result[0], FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return result[1];
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (FileStream fileStream = new FileStream(result[0], FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            File.Delete(sourcePath);
            return result[1];
        }
        public static void Delete(string Path)
        {
            try
            {
                File.Delete(Path);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public static string[] NewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string directory = "CarImages";
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot",directory);
            string newFileName = Guid.NewGuid().ToString() + fileExtension;
            var fullDirectory = Path.Combine(path, newFileName);
            var localDirectory = Path.Combine(directory, newFileName);
            string[] paths = { fullDirectory,localDirectory};
            return paths;
        }
    }
}
