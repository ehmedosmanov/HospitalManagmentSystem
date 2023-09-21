using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace HospitalFinalProject.Helpers
{
    public static class Extentions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsOlder1MB(this IFormFile file)
        {
            return file.Length / 1024 > 1024;
        }

        public async static Task<string> SaveFileAsync(this IFormFile file, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folder, fileName);

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
