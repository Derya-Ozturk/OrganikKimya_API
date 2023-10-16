using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ResponseResultDto: IDto
    {
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
