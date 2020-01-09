using System;
namespace TinyUrl.Model
{
    public class UrlItem:Entity
    {

        public string SrcUrl{ get;set;}
        public string Code{get;set;}
        public long Salt{get;set;}
        public int TD_VALID {get;set;}
        public DateTime CreateTime{get;set;}
    
    }
}