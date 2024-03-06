using System.ComponentModel.DataAnnotations;

namespace UploadFiles.Models
{
    public class ConvertFileModel : ReponseModel
    {
        public string FileName { get; set; } = null!;

        [Required(ErrorMessage = "Please select file")]
        public IFormFile File { get; set; } = null!;
    }
}
