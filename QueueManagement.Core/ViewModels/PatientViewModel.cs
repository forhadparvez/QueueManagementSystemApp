
using System.ComponentModel.DataAnnotations;

namespace QueueManagement.Core.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Insert Patient Name")]
        [MaxLength(255, ErrorMessage = "Patient Name Max Length 255")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Patient Phone No")]
        [MaxLength(20, ErrorMessage = "Patient Name Max Length 255")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please Insert Patient Age")]
        [MaxLength(3, ErrorMessage = "Patient Name Max Length 255")]
        public string Age { get; set; }
    }
}
