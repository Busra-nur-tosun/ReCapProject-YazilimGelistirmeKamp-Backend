using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public  interface IBrandService
    {
         IDataResult<List<Brand>> GetAll();
        IResult GetById(int brandId);
        IDataResult<List<Brand>> Add(Brand brand);
        IDataResult<List<Brand> >Update (Brand brand);
        IDataResult<List<Brand>> Delete(Brand brand);

    }
}
