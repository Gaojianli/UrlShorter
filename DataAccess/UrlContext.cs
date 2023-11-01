using Microsoft.EntityFrameworkCore;
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
