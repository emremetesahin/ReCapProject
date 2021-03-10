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
            using (FileStream fileStream = new FileStream(result, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return result;
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (FileStream fileStream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            File.Delete(sourcePath);
            return result;
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
        public static string NewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Path.Combine(Environment.CurrentDirectory, "Images", "CarImages");
            string newPath = Guid.NewGuid().ToString() + fileExtension;
            var result = Path.Combine(path, newPath);
            return result;
        }
    }
}
