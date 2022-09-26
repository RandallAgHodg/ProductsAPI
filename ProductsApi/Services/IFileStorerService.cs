using CloudinaryDotNet.Actions;

namespace ProductsApi.Services;

public interface IFileStorerService
{
    Task<string> UploadImage(ImageUploadParams imageUploadParams);
}