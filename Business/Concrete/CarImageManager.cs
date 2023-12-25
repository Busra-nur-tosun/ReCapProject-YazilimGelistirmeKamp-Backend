using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CarImages carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Update(CarImages carImage, IFormFile file)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }



        public IResult Delete(CarImages carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
   
        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImage = new List<CarImages>();
            carImage.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        public IDataResult<List<CarImages>> GetByCarImageId(int imageId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            throw new NotImplementedException();
        }
    }
}