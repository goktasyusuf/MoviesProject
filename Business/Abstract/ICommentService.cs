using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICommentService
	{

        IDataResult<List<Comment>> GetComments(int id);
        IResult AddComment(Comment comment);
    }
}
