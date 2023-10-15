using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId

                             join use in context.Users
                             on cus.UserId equals use.UsersId

                             join c in context.Cars
                             on r.CarId equals c.Id

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             select new RentalDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 FirstName = use.FirstName +" " + use.LastName,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();




            }
       
        }

        private void GetRentalDetaiDto()
        {
            throw new NotImplementedException();
        }
    }
}
