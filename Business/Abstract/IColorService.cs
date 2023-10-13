using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
     public interface IColorService
    {
        IDataResult<List<Color> >GetAll();
        IResult GetById(int colorId);
        IDataResult<List<Color>> Add(Color color);
        IDataResult<List<Color>> Update(Color color);
        IDataResult<List<Color>> Delete(Color color);

    }
}
