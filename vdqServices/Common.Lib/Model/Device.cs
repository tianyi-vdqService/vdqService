using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class Device
    {
        public virtual int Id { get; set; }
        public virtual string PointId { get; set; }
        public virtual string PointNumber { get; set; }
        public virtual string PointName { get; set; }
        public virtual int AreaId { get; set; }
        public virtual string PoingNaming { get; set; }
        public virtual string Type { get; set; }
        public virtual string Address { get; set; }
        public virtual string IpAddress { get; set; }

    }
}
