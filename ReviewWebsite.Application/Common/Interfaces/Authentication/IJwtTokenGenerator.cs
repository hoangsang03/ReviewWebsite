﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewWebsite.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName);
    }
}
