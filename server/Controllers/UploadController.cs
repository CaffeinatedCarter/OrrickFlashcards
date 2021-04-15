using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using flashcardgenerator.Data;

namespace flashcardgenerator.Controllers
{
    [Route("upload")]
    public partial class UploadController : Controller
    {

        private readonly IWebHostEnvironment _environment;


        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public ActionResult Post(IFormFile file)
        {
            try
            {
                _ = UploadFile(file);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadPath = _environment.WebRootPath + "/temp";
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fullPath = Path.Combine(uploadPath, file.FileName);

                using(FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write)){
                    await file.CopyToAsync(fs);
                }


                cGlobals.lastUploadDir = fullPath;

            }


        }

        public static class cGlobals
        {
            // global int
            public static string lastUploadDir;

           
            }
        }

    }

