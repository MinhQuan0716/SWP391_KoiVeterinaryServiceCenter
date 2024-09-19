﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class AppConfiguration
    {
        public string DatabaseConnection {  get; set; }
        public string JwtSecretKey { get; set; }
    }
}
