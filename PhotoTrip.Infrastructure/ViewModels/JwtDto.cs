using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
