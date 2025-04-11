using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UIAPI.FileHelpers.Interface;

namespace UIAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileHelpers _fileHelpers;

        private readonly AppDbContext _Db;

        public FileController(IFileHelpers fileHelpers,AppDbContext Db)
        {
            _fileHelpers = fileHelpers;
            _Db = Db;
        }

        [HttpPost("Uploads"),DisableRequestSizeLimit]
        public IActionResult Uploads(IFormFile file)
        {
            try
            {
                /*  var FormCollection = Request.ReadFormAsync().Result;
                  var file = FormCollection.Files.First();

                  var dbpath = _fileHelpers.UploadFile(file);
                  return Ok(new { dbpath });*/

                var uploadpath = _fileHelpers.UploadFile(file);

                return Ok(new { uploadpath });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                return StatusCode(500, $"Internal Server Error : {ex}");
            }

        }


        [HttpDelete("DeleteFile")]
        public IActionResult DeleteFile(string imageUrl)
        {
            _fileHelpers.DeleteFile(imageUrl);

            return Ok();
        }


        //[HttpGet("Garbage")]
        //public ActionResult Garbage()
        //{
        //    var lists = _Db.EmployeeMasters.Select(s => s.ProfileImage).ToList();

        //    foreach (var item in ModelState)
        //    {


        //    }

        //    return Ok(lists);
        //}

        [HttpGet("GarbageImage")]
        public ActionResult GarbageImage()
        {

            try
            {
                var imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");


                if (!Directory.Exists(imagesFolderPath))
                {
                    return NotFound("Image folder not found");
                }

                var lists = _Db.EmployeeMasters.Select(s => s.ProfileImage).ToList();

                var imageFiles = Directory.GetFiles(imagesFolderPath, "*.*")
                                          .Select(file => "/images/" + Path.GetFileName(file)) // Get the file names with the relative path
                                          .ToList();

                var filesToDelete = imageFiles.Except(lists).ToList();

               // if (filesToDelete.Any())
               // {
                    foreach (var item in filesToDelete)
                    {
                        var fileName = item.Replace("/images/", ""); // Remove "/images/" to get the file name
                        var filePath = Path.Combine(imagesFolderPath, fileName); // Get the full file path

                        try
                        {
                            _fileHelpers.ApiDeleteFile(filePath);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"Error deleting file {item}: {ex.Message}");
                        }
                    }
              //  }

                return Ok(imageFiles);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }



        }



    }
}


// Get all image files from the directory (e.g., *.jpg, *.png, *.jpeg)
//var imageFiles = Directory.GetFiles(imagesFolderPath, "*.*")
//                         .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg"))
//                         .Select(Path.GetFileName) // Get only the file names (not the full path)
//                         .ToList();
