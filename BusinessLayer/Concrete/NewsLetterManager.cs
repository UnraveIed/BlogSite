using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _letterDal;

        public NewsLetterManager(INewsLetterDal letterDal)
        {
            _letterDal = letterDal;
        }

        public void Add(NewsLetter entity)
        {
            _letterDal.Insert(entity);
        }
    }
}
