using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Entities;

namespace ShortUrl.DataAccess
{
    public class UrlContext:DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options):base(options)
        {  }
        public DbSet<Url> Urls { get; set; }
    }
}
