namespace UIAPI.FileHelpers.Interface
{
    public interface IFileHelpers
    {

        bool DeleteFile(string ImageUrl);

        string UploadFile(IFormFile file);

        bool ApiDeleteFile(string ImageUrl);

    }
}
