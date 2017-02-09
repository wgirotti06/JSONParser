using JSONParser.Data;
using JSONParser.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSONParser.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly JPService _jpService = new JPService();
         
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Results(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && file.FileName.Contains(".json"))
            {
                List<container> containers;

                using (var sr = new StreamReader(file.InputStream))
                {
                    var json = sr.ReadToEnd();
                    containers = JsonConvert.DeserializeObject<List<container>>(json);
                }

                containers.ForEach(_jpService.SumLabeledIds);

                return View(containers);
            }
            throw new HttpException(); 
        }
    }
}