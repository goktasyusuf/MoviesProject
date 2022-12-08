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
	public class CommentManager : ICommentService
	{
		ICommentDal commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			this.commentDal = commentDal;
		}

		public IResult AddComment(Comment comment)
		{
			commentDal.Add(comment);
			return new SuccessResult("Yorum Eklendi");
		}

		public IDataResult<List<Comment>> GetComments(int id)
		{
			return new SuccessDataResult<List<Comment>>(commentDal.GetAll(c => c.MovieId == id),"İlgili filme ait yorumlar getirildi");
		}
	}
}
