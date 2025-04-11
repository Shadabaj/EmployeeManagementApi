using UIAPI.FileHelpers.Interface;

namespace UIAPI.FileHelpers.Implementations
{
    public class FileHelpers : IFileHelpers
    {
        private readonly IWebHostEnvironment _webHost;

        public FileHelpers(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public bool ApiDeleteFile(string ImageUrl)
        {
            if (File.Exists(ImageUrl))
            {
                File.Delete(ImageUrl);
                return true;
            }
            return false;
        }

        public bool DeleteFile(string ImageUrl)
        {
            if (File.Exists(_webHost.WebRootPath + ImageUrl))
            {
                File.Delete(_webHost.WebRootPath + ImageUrl);
                return true;

            }
            return false;
        }

        public string UploadFile(IFormFile file)
        {
            var uploads = Path.Combine(_webHost.WebRootPath, "images");
            bool exists = Directory.Exists(uploads);
            if (!exists)
            {
                Directory.CreateDirectory(uploads);
            }
            var filename = GenerateFileName(file.FileName);

            var filePath = Path.Combine(uploads, filename);
            //var filestream = new FileStream(Path.Combine(uploads, filename), FileMode.Create);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                 file.CopyToAsync(filestream);
            }
            //file.CopyToAsync(filestream);

            return "/images/" + filename;
        }


        private string GenerateFileName(string filename)
        {
            string[] strName = filename.Split(".");

            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];

            return strFileName;
        }

    }
}
