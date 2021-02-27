
﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccess.Abstract
{

    public interface ICarDal : IEntityRepository<Car>
    {


        List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null);







    }
}