using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            //koşullar 
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IResult GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            var cars = _carDal.GetAll(p => p.BrandId== id).Select(car => new CarDetailDto()).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            var cars = _carDal.GetAll(p => p.ColorId== id).Select(car => new CarDetailDto()).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        public IResult Update(Car car)
        {
            if (car.CarName.Length <= 2 && car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        IDataResult<List<Car>> ICarService.Add(Car car)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Car>> ICarService.Delete(Car car)
        {
            throw new NotImplementedException();
        }

        IResult ICarService.GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        IResult ICarService.GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Car>> ICarService.Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
