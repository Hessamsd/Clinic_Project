using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Clinic_Project
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _Webenvironment;

      public FileUploader(IWebHostEnvironment webenvironment)
      {
          _Webenvironment = webenvironment;
      }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_Webenvironment.WebRootPath}//DoctorPictures//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);



            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";




            try
            {
                using var output = File.Create(filePath);
                file.CopyTo(output);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading file: {ex.Message}", ex);
            }


            return Path.Combine(path, fileName).Replace("\\", "/");

        }
    }
}
