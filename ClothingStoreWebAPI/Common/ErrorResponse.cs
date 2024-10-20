using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ClothingStoreWebAPI.Common
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string StatusPhase { get; set; } 
        public List<string> Errors { get; set; } = new List<string>();
        public DateTime TimeStamp { get; set; }

    }
}
