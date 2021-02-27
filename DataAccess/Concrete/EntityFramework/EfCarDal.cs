using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepository<Car, RentalCarContext>, ICarDal
    {


        public List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             select new CarDetailDTO
                             {
                                 CarId = p.CarId,
                                 BrandId = p.BrandId,
                                 ColorId = p.ColorId,
                                 DailyPrice = p.DailyPrice



                             };

                return result.ToList();


            }
        }
    }
}
    

