using CloudinaryDotNet.Actions;

namespace ProductsApi.Services;

public class FileStorerService : IFileStorerService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public FileStorerService(CloudinaryDotNet.Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<string> UploadImage(ImageUploadParams imageUploadParams)
    {
        var result = await _cloudinary.UploadAsync(imageUploadParams);
        return result.Url.AbsoluteUri;
    }
}