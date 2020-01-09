using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using TinyUrl.Common;
using TinyUrl.IDal;
using TinyUrl.IService;
using TinyUrl.Model;
namespace TinyUrl.Service
{

    public class UrlItemService : IUrlItemService
    {
        //private static readonly string salt="salt";
        private IUrlItemDal _urlItemDal;
        public UrlItemService (IUrlItemDal _urlItemDal)
        {
            this._urlItemDal = _urlItemDal;
        }
        public string GetTinyCode (string url)
        {
            if (string.IsNullOrEmpty (url) || url.Length > 2000)
            {
                throw new ArgumentException ("url error");
            }

            var hashurl = url;
            var bytes = HashHelper.GetMurmurHashBytes (hashurl);
            var code = StringHelper.ConvertTo62 (bytes);
            var item = _urlItemDal.Query (x => x.Code == code).FirstOrDefault ();
            if (item != null && item.ID > 0)
            {
                if (item.SrcUrl == url)
                {
                    return item.Code;
                }
                else
                {
                    var salt = DateTimeOffset.Now.ToUnixTimeMilliseconds ();
                    code=GetNextCode(url,salt);
                }
            }
            var model = new UrlItem ();
            model.SrcUrl = url;
            model.Code = code;
            model.CreateTime = DateTime.Now;
            model.TD_VALID = 1;
            var flag = false;
            while (!flag)
            {
                try
                {
                    flag = _urlItemDal.Add (model);
                }
                catch
                {
                    var salt = DateTimeOffset.Now.ToUnixTimeMilliseconds ();
                    code=GetNextCode(url,salt);
                    model.Code = code;
                }
            }

            return code;
        }

        public string Redirect (string code)
        {
            if (string.IsNullOrEmpty (code))
            {
                throw new ArgumentNullException ("code is not null");
            }
            var model = _urlItemDal.Query (x => x.Code == code).FirstOrDefault ();
            if (model == null || model.ID == 0)
            {
                throw new ArgumentException ("code is error");
            }
            return model.SrcUrl;
        }
        public static string GetNextCode (string url,long salt)
        {
           
            var hashurl = url + salt;
            var bytes = HashHelper.GetMurmurHashBytes (hashurl);
            var code = StringHelper.ConvertTo62 (bytes);
            return code;
        }
    }
}