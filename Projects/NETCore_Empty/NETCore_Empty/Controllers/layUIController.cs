using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCore_Empty.Controllers
{
    public class layUIController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Slist> l = new List<Slist>();
            Slist a = new Slist() {title= "item 1" , id= "aaa" };

            ViewBag.List = @"[{title: 'item 1' ,id: 'aaa' }, {title: 'item 2',id: 'bbb' }]";
            return View();
        }
        public class Slist {
            public string title { set; get; }
            public string id { set; get; }
        }
    }
}
