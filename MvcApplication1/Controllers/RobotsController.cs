using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class RobotsController : Controller
    {
        public FileContentResult RobotsTextFile()
        {
            var content = "User-agent: *" + Environment.NewLine;

            if (string.Equals(ConfigurationManager.AppSettings["allow-robots"], "true", StringComparison.InvariantCultureIgnoreCase))
            {
                content += "Disallow: /Admin" + Environment.NewLine;
                content += "Sitemap: http://www.your-website-here.com/sitemap.xml" + Environment.NewLine;
            }
            else
            {
                content += "Disallow: /" + Environment.NewLine;
            }

            return File(Encoding.UTF8.GetBytes(content), "text/plain");
        }
    }
}
