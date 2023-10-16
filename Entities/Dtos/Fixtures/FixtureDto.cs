using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Fixtures
{
    public class FixtureDto: IDto
    {
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Quantity { get; set; }
        public int Status { get; set; }
    }
}
