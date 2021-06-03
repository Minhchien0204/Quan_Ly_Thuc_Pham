using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
    }
}
