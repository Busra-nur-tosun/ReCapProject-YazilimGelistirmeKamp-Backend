using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(object p)
        {
            throw new NotImplementedException();
        }

        List<CarDetailDto> GetCarDetails()
        {

            using (RentACarContext context = new RentACarContext())
            {
                var result = from a in context.Cars
                             join c in context.Colors
                             on a.ColorId equals c.ColorId
                             select new CarDetailDto
                             {
                                 CarID = a.Id,
                                 CarName = a.CarName,
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName,
                                 DailyPrice = a.DailyPrice,
                             };
                return result.ToList();
            }
        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
