using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace WebApiEcommerce.Services
{
    public class ImagenService
    {
        private readonly Cloudinary _cloudinary;

        public ImagenService(CloudinaryService cloudinaryService)
        {
            _cloudinary = cloudinaryService.Cloudinary;
        }

        public async Task<string> SubirImagenAsync(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return null;

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(archivo.FileName, archivo.OpenReadStream())
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl?.ToString();
        }
    }
}
