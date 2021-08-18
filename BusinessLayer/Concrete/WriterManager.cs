using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x=>x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }
        public List<Writer> GetFilteredList(List<Writer> filtered)
        {
            return filtered.Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).ToList();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);

        }
    }
}
