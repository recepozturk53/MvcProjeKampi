using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonalService
    {
        List<Personal> GetList();
        Personal GetByID(int id);
        void Add(Personal p);
        void Update(Personal p);
        void Delete(Personal p);
    }
}
