using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace SimpleApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FileExtensionContentTypeProvider FileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider FileExtensionContentTypeProvider)
        {
            this.FileExtensionContentTypeProvider= FileExtensionContentTypeProvider;
        }


        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            string pathToFile = "TopLearn.txt";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!FileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));



        }
    }
}
