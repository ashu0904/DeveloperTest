
namespace ThirdPartyTools.Interface
{
    public interface IFileDetails
    {
        string Version(string filePath);

        int Size(string filePath);
    }
}
