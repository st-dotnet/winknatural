using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinkNaturals.Models
{
    public class GetProductImageResponse
    {
        public byte[] ImageInByte { get; set; }
        public string contentType { get; set; }
    }
}
