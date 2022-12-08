using Business.Abstract;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class WriterManager : IWriterService
	{

		IWriterDal movieWriterDal;

		public WriterManager(IWriterDal movieWriterDal)
		{
			this.movieWriterDal = movieWriterDal;
		}

		public IResult AddMovieWriter(Writer movieWriter)
		{
			movieWriterDal.Add(movieWriter);
			return new SuccessResult("Yazar Eklendi");
		}

		public IDataResult<List<Writer>> GetWriterByWriterId(int id)
		{
			return new SuccessDataResult<List<Writer>>(movieWriterDal.GetAll(x => x.WriterId == id));
		}

		public Writer GetWriterByWriterId2(int id)
		{
			return movieWriterDal.Get(x => x.WriterId == id);
		}

		public void UpdateWriter(Writer writer)
		{
			movieWriterDal.Update(writer);
		}
	}
}
