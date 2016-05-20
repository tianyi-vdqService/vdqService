using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class Param
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual string KeyValue { get; set; }
    }
}
