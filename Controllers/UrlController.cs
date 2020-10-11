using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.DataAccess;

namespace ShortUrl.Controllers
{
    [Route("/")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlContext dbContext;
        [HttpGet("{shorten}")]
        public void Get(string shorten)
        {
            var longUrl = from urls in dbContext.Urls
                          where urls.shortUrl == shorten
                          select urls.longUrl;
            if (longUrl.Count() == 0)
            {
                Response.Redirect("/");
            }
            else
            {
                Response.Redirect(longUrl.Single());
            }
        }
    }
}
