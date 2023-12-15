using ClothingStore.Application.Interfaces;

namespace ClothingStore.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}