using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ContactPartialModel
    {
        public int InBoxAmount { get; set; }
        public int SendBoxAmount { get; set; }
        public int ContactAmount { get; set; }
        public int UnReadAmount { get; set; }
        public int ReadAmount { get; set; }
        public int DraftAmount { get; set; }
        public int DeletedAmount { get; set; }
    }
}