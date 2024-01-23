using System;

namespace TaxiBooking.Models.Entities
{
    public class Car:Entity
    {
        public int No { get; set; } 
        public string Color { get; set; } 
        public string Model { get; set; } 
        public DateTime ExpiryDate { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public string OwnerName { get; set; }
        public bool IsActive { get; set; }
        public string Attachment { get; set; }

        public Car(
            Guid id,
            int no,
            string color, 
            string model, 
            DateTime expiryDate, 
            DateTime createdAt, 
            string ownerName,
            bool isActive, 
            string attachment)
        {
            Id = id;
            No = no;
            Color = color;
            Model = model;
            ExpiryDate = expiryDate;
            CreatedAt = createdAt;
            OwnerName = ownerName;
            IsActive = isActive;
            Attachment = attachment;
        }

        public Car()
        {
        }
    }

}
