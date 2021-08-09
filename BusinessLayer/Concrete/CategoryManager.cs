using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.Repositories;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using DataAccess.Abstract;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {

            _categoryDal.Insert(category);
            
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get( x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            
            return _categoryDal.List();
        }

        public List<Category> GetFilteredList(List<Category> filtered)
        {
            return filtered.Where(x => x.CategoryStatus == true).ToList();
        }
    }
}
