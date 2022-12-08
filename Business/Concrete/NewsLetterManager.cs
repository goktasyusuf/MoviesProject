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
	public class NewsLetterManager : INewsLetterService
	{
        INewsLetterDal LetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            this.LetterDal = newsLetterDal;
        }


        public IResult AddNewsLetter(NewsLetter newsLetter)
        {
            LetterDal.Add(newsLetter);
            return new SuccessResult("Başarıyla Eklendi");
        }
    }
}
