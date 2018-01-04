﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
