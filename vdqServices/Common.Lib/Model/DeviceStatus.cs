using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class DeviceStatus
    {
        public virtual int Id { get; set; }
        public virtual int DeviceId { get; set; }
        public virtual int NetWork { get; set; }
        public virtual int Stream { get; set; }
        public virtual int Noise { get; set; }
        public virtual int Sign { get; set; }
        public virtual int Color { get; set; }
        public virtual int Frozen { get; set; }
        public virtual int Shade { get; set; }
        public virtual int Fuzzy { get; set; }
        public virtual int Displaced { get; set; }
        public virtual int Strip { get; set; }
        public virtual int Colorcase { get; set; }
        public virtual int Exception { get; set; }
        public virtual DateTime RecordTime { get; set; }
        public virtual DateTime CreateTime { get; set; } 
    }
}
