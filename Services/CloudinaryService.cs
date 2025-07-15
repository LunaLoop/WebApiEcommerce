using CloudinaryDotNet;

namespace WebApiEcommerce.Services
{
    public class CloudinaryService
    {
        public Cloudinary Cloudinary { get; }

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );

            Cloudinary = new Cloudinary(account);
        }
    }
}
