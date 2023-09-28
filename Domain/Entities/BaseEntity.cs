﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId? id { get; set; }
    }
}
