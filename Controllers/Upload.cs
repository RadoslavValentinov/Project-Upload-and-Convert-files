using Microsoft.AspNetCore.Mvc;
using UploadFiles.Models;
using IronOcr;


namespace UploadFiles.Controllers
{
    public class Upload : Controller
    {
        private IWebHostEnvironment env { get; }

        public Upload(IWebHostEnvironment env) => this.env = env;

        public IActionResult Index()
        {
            SingleFileModel model = new SingleFileModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Uploads(SingleFileModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsResponse = true;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(model.File.FileName);
                string fileName = model.FileName + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
                model.IsSuccess = true;
                model.Message = "File upload successfully";
            }
            return View("Index", model);

        }

        [HttpGet]
        public IActionResult ConvertToPdf()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ConvertToPdf(ConvertFileModel model)
        {

            if (!ModelState.IsValid)
            {

            }

            return View();
        }


        [HttpGet]
        public IActionResult ConvertToWord()
        {
            ConvertFileModel model = new ConvertFileModel();

            return View(model);
        }


        [HttpPost]
        public IActionResult ConvertToWord(ConvertFileModel model)
        {
            SautinSoft.PdfFocus set = new SautinSoft.PdfFocus();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension

            FileInfo fileInfo = new FileInfo(model.File.FileName);

            string fileNameWithPath = Path.Combine(path, fileInfo.Name);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }

            set.OpenPdf(fileNameWithPath);

            if (set.PageCount > 0)
            {
                set.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                set.ToWord("C:\\Users\\Radko\\source\\repos\\UploadFiles\\UploadFiles\\wwwroot\\convert.dox");
            }
            var convertedFile = "convert.dox";

            return DownloadFile(convertedFile);
        }



        public IActionResult DownloadFile(string converted) // can also be IActionResult
        {
            string file = System.IO.Path.Combine(env.WebRootPath, converted);
            return File(new FileStream(file, FileMode.Open), "text/plain", "dolwloadFile.dox");
        }


        [HttpGet]
        public ActionResult GetFoto()
        {
            return View();
        }



        [HttpPost]
        public ActionResult GetFoto(IFormFile file)
        {          
            if (file != null)
            {
                 string fileName = file.FileName;
                var path = Path.Combine(env.WebRootPath, fileName);

                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);

                var ocr = new IronTesseract();
                using (var input = new OcrInput(Path.Combine(env.WebRootPath, fileName)))
                {
                    var result = ocr.Read(input);
                    result.SaveAsTextFile(Path.Combine(env.WebRootPath, "text.txt"));
                    ViewBag.Message = ocr.Read(input).Text;

                    var text = ocr.Read(input).Text;
                }

            }

            return View();
        }

        public IActionResult DownloadFileFoto() 
        {
            string file = @"D:\Нова папка\wwwroot\text.txt";
            return File(new FileStream(file, FileMode.Open), "text/plain", "YourText.txt");
        }
    }
}
