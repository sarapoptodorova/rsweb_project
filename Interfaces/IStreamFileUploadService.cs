using Microsoft.AspNetCore.WebUtilities;

namespace RSWEBBookShop.Interfaces
{
    public interface IStreamFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
    }
}
