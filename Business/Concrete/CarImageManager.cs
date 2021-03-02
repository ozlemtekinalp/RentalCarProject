using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carimagedal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carimagedal = carImageDal;
        }


        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.CarImageDate = DateTime.Now;

            _carimagedal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
            
            
        }

        public IResult Delete(CarImage carimage)
        {
            _carimagedal.Delete(carimage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carimagedal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
        }
            

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _carimagedal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        private IResult CheckCarImageLimit(CarImage carImage)
        {
            if (_carimagedal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.FailedCarImageAdd);
            }

            return new SuccessResult();
        }
    }
}
