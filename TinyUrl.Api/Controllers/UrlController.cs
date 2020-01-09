using Microsoft.AspNetCore.Mvc;
using System;
using TinyUrl.IService;

namespace TinyUrl.Api.Controllers
{

  

  [ApiController]
  [Route("[controller]/[action]")]
    public class UrlController:ControllerBase
    {
        private readonly IUrlItemService _urlItemService;
        public UrlController(IUrlItemService _urlItemService)
        {
            this._urlItemService=_urlItemService;
        }
        [HttpGet]
        public IActionResult GetUrl(string url)
        {
           var code= _urlItemService.GetTinyCode(url);
           return new JsonResult(new {code=code});
        }
        [HttpGet]
        public IActionResult GetSrcUrl(string code)
        {
           var url= _urlItemService.Redirect(code);
           return new JsonResult(new {url=url});
        }
    }
}