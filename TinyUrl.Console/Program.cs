using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using System;
using TinyUrl.Common;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Extensions.Http;
namespace TinyUrl.Console
{
    class Program
    {
        static void Main(string[] args)
        {
           
           var url=$"http://localhost:5000/Url/GetUrl?url=https%3a%2f%2fwww.def{{0}}.com";
           Parallel.For(1,50,item=>{
               var wb=new WebClient();
               wb.DownloadString(string.Format(url,item));
           });
          
        }
    }
    public class  Model
    {
        public string Name{get;set;}
    }
    public interface ITest<T>
    {
        string Get();
        T GetModel();
    }
    public class  Test<T>:ITest<T>
    {
        public string Get()
        {
            return "Test";
        }
        public T GetModel()
        {
            return default(T);
        }

    }
    public interface IMyInterface:ITest<Model>
    {

    }
    public class  MyTest:Test<Model>,IMyInterface
    {
        
    }
}
