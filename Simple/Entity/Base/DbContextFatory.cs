using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity.Base
{
    public class DbContextFatory
    {
        private static BaseDbContext _baseDbContext;

        public static  BaseDbContext Create()
        {
            if (_baseDbContext == null)
            {
                _baseDbContext = new BaseDbContext();
            }
            return _baseDbContext;
        }

       
    }

    
}
