// Domain/Models/Godown.cs
using Domain.Common;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Godown : BaseDomainEntity
    {
        public required string GodownName { get; set; }
        public required string Location { get; set; }
        public required string GodownManager { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}