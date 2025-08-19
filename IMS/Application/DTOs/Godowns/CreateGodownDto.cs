using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Godowns
{
    public class CreateGodownDto
    {
        public required string GodownName { get; set; }
        public required string Location { get; set; }
        public required string GodownManager { get; set; }
    }
}