using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public class TaskItem
    {
        public virtual int Id { get; set; }
        public virtual int TaskId { get; set; }
        public virtual int ItemTypeId { get; set; }

    }
}
