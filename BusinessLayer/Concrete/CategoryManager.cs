using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository _repo;

        public CategoryManager(EfCategoryRepository repo)
        {
            this._repo = repo;
        }

        public void Add(Category category)
        {
            _repo.Insert(category);
        }

        public void Delete(Category category)
        {
            _repo.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public Category GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Update(Category category)
        {
            _repo.Update(category);
        }
    }
}
