namespace TinyUrl.IService
{
    public interface IUrlItemService
    {
        string GetTinyCode(string url);
        string Redirect(string code);
    }
}