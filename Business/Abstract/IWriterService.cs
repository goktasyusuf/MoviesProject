using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IWriterService
	{
		IResult AddMovieWriter(Writer writer);
		IDataResult<List<Writer>> GetWriterByWriterId(int id);
        Writer GetWriterByWriterId2(int id);
		void UpdateWriter(Writer writer);
    }
}
