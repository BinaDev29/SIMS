using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.Models
{
    public class Godown : BaseDomainEntity
    {
        public required string GodownName { get; set; }
        public required string Location { get; set; }
        public required string GodownManager { get; set; }
    }
}