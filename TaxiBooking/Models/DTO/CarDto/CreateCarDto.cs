using System;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace TaxiBooking.Models.DTO.CarDto
{
    public class CreateCarDto
    {
        [Required]
        public int CarNo { get; set; }
        [Required]
        [MaxLength(256)]
        public string CarColor { get; set; }
        [Required]
        [MaxLength(256)]
        public string CarModel { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        [MaxLength(256)]
        public string OwnerName { get; set; }
        public HttpPostedFileBase Attachment { get; set; }

    }
}