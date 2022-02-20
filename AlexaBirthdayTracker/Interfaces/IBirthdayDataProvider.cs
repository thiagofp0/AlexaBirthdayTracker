using AlexaBirthdayTracker.Models;

namespace AlexaBirthdayTracker.Interfaces
{
    public interface IBirthdayDataProvider
    {
        public void Init();
        public Birthday GetNextBirthday();
    }
}