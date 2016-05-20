using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class Log
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual int TypeId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual string Description { get; set; }
    }
}
