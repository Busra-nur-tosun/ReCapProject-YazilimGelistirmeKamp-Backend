using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
     public interface ICarService
    {
		 IDataResult <List<Car> >GetAll();
		 IResult GetById(int carId);
		 IResult GetCarsByBrandId(int brandId);
		 IResult GetCarsByColorId(int colorId);
		IDataResult<List<Car>> Add(Car car);
		IDataResult<List<Car>> Update(Car car);
		IDataResult<List<Car> >Delete(Car car);
		IDataResult<List<CarDetailDto>>GetCarDetailDtos();
	}
}
