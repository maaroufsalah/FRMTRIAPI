﻿using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Contexts
{
    public partial class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() { }

        public IdentityContext(DbContextOptions<IdentityContext> options) 
            : base(options)
        {
        }

    }
}
