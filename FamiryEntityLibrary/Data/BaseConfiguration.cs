using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FamiryEntityLibrary.Data
{
    public abstract class BaseConfiguration
    {
        internal abstract string DateTimeType { get; }

        internal abstract string DateTimeValueCurrent { get; }

        public abstract void ConfigureContext(DbContextOptionsBuilder optionsBuilder);
    }
}
