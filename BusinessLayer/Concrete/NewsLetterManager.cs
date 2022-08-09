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

        public void Delete(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLetter entity)
        {
            throw new NotImplementedException();
        }
    }
}
