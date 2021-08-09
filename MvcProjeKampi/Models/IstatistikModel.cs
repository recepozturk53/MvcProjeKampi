using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class IstatistikModel
    {
        public int CategoryCount { get; set; }
        public int SwareHeadCount { get; set; }
        public int WriterCount { get; set; }
        public string MostHeadingCat { get; set; }
        public int DifBtwnTF { get; set; }
    }
}