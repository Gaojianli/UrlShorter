using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Math.EC;
using ShortUrl.DataAccess;
using ShortUrl.Entities;

namespace ShortUrl.Controllers
{
    [Route("/")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private IConfiguration Configuration;
        public UrlController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public void Get()
        {
            Response.Redirect(Configuration.GetSection("SiteSettings")["homePage"]);
        }

        [HttpGet("{shorten}")]
        public void Forward(string shorten, [FromServices] UrlContext dbContext)
        {
            var longUrl = from urls in dbContext.Urls
                          where urls.shortUrl == shorten
                          select urls.longUrl;
            if (longUrl.Count() == 0)
            {
                Response.Redirect(Configuration.GetSection("SiteSettings")["homePage"]);
            }
            else
            {
                Response.Redirect(longUrl.Single(),true);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PUT([FromServices] UrlContext dbContext)
        {
            var body = Request.Form;
            if (body != null || body.ContainsKey("urls"))
            {
                var newUrls = new Url
                {
                    longUrl = body["urls"]
                };
                dbContext.Urls.Add(newUrls);
                await dbContext.SaveChangesAsync();
                newUrls.shortUrl = Service.ShortUrl.getShorted(newUrls.id);
                newUrls.revokePassword = Service.ShortUrl.GenerateRevokePwd();
                await dbContext.SaveChangesAsync();
                Response.StatusCode = 201;
                return new JsonResult(new
                {
                    code = 201,
                    data = new
                    {
                        shortUrl = $"{Configuration.GetSection("SiteSettings")["prefix"]}/{newUrls.shortUrl}",
                        revokePwd = newUrls.revokePassword
                    }
                });

            }
            else
            {
                Response.StatusCode = 406;
                return new JsonResult(new
                {
                    code = 406,
                    msg = "Not Acceptable"
                });
            }

        }

        [HttpDelete("{shorten}")]
        public async Task<IActionResult> Delete(string shorten, [FromQuery] string revokePwd, [FromServices] UrlContext dbContext)
        {
            var query = from urls in dbContext.Urls
                        where urls.shortUrl == shorten
                        select urls;
            if (query.Count() == 0)
            {
                Response.StatusCode = 201;
                return new JsonResult(new
                {
                    code = 201,
                    msg = "Deleted"
                });
            }
            else
            {
                var target = query.Single();
                if (target.revokePassword == revokePwd)
                {
                    dbContext.Urls.Remove(target);
                    await dbContext.SaveChangesAsync();
                    Response.StatusCode = 201;
                    return new JsonResult(new
                    {
                        code = 201,
                        msg = "Deleted"
                    });
                }
                else
                {
                    Response.StatusCode = 401;
                    return new JsonResult(new
                    {
                        code = 401,
                        msg = "Invaild Revoke password"
                    });
                }
            }
        }
    }
}
