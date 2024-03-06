using System.ComponentModel.DataAnnotations;

namespace UploadFiles.Models
{
    public class SingleFileModel : ReponseModel
    {
        [Required(ErrorMessage = "Please enter file name")]
        public string FileName { get; set; } = null!;
        [Required(ErrorMessage = "Please select file")]
        public IFormFile File { get; set; } = null!;
    }
}
