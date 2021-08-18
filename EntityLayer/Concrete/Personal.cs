using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Personal
    {
        [Key]
        public int PersonalID { get; set; }
        [StringLength(50)]
        public string PersonalName { get; set; }
        [StringLength(50)]
        public string PersonalSurname { get; set; }
        [StringLength(50)]
        public string PersonalJob { get; set; }
        public int Sikill1 { get; set; }
        public int Sikill2 { get; set; }
        public int Sikill3 { get; set; }
        public int Sikill4 { get; set; }
        public int Sikill5 { get; set; }
        public int Sikill6 { get; set; }
        public int Sikill7 { get; set; }
        public int Sikill8 { get; set; }
        public int Sikill9 { get; set; }
        public int Sikill10 { get; set; }
    }
}
