using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities
{
    public class Token
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public String TokenString { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public virtual User User { set; get; }

    }
}
