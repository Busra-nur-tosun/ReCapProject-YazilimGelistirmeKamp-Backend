using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.GuidHelperr;
using System.IO;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();  // Namespace düzeltildi
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(Path.Combine(root, filePath)))  // Dosya adı oluşturma düzeltildi
                {
                    file.CopyTo(fileStream);
                }

                return filePath;
            }
            return null;
        }
    }
}
