﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Dtos.Common
{
    public class LoginResult : ResponseBase
    {
        public string? Token { get; set; }
    }
}