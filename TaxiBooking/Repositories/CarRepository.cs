using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TaxiBooking.Models.Entities;

namespace TaxiBooking.Repositories
{
    internal class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public bool Add(Car car)
        {
            _dbContext.Cars.Add(car);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(Car car)
        {
            _dbContext.Cars.Remove(car);
            return _dbContext.SaveChanges() > 0;
        }

        public Car GetById(Guid Id)
        {
            return _dbContext.Cars.Find(Id);
        }

        public List<Car> ListCar()
        {
            return _dbContext.Cars.ToList();
        }

        public bool Update(Car car)
        {
            _dbContext.Cars.AddOrUpdate(car);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
