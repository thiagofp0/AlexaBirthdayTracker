using AlexaBirthdayTracker.Models;

namespace AlexaBirthdayTracker.Interfaces
{
    public interface IBirthdayDataProvider
    {
        public void Init();
        public Birthday GetNextBirthday(string userId);
        public Birthday GetBirthday(string name, string userId);
        public bool AddBirthday(Birthday birthday);
    }
}