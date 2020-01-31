using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Controllers
{
    [Route("api/mybook")]

    //自己实现的api，注意，类必须是public，否则，在swagger中看不到！！
    public class MybookController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            return new JsonResult(new {Status = 0, Message = "Hello World!"});
        }
    }
}
