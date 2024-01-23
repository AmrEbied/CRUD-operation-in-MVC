using System;

namespace TaxiBooking.Models.DTO.CarDto
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public int CarNo { get; set; }
        public string CarColor { get; set; }
        public string CarModel { get; set; }
        public string ExpiryDate { get; set; }
        public string CreatedAt { get; set; }
        public string OwnerName { get; set; }
        public string Attachment { get; set; }
    }
}