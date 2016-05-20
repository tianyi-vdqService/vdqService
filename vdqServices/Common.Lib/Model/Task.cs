using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class Task
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual int RunInterval { get; set; }
        public virtual int RunTimes { get; set; }
        public virtual int RunCount { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual int Flag { get; set; }
    }
}
