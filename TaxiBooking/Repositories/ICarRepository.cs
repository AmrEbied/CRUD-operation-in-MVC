using System;
using System.Collections.Generic;
using TaxiBooking.Models.Entities;

namespace TaxiBooking.Repositories
{
    public interface ICarRepository
    {
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        Car GetById(Guid Id);
        List<Car> ListCar();

    }
}
