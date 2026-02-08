
namespace KidsBirthdayPlanner.Common
{
    public class EntityConstants
    {
        public class Event
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int DescriptionMaxLength = 300;

            public const int MinGuestsValue = 1;
            public const int MaxGuestsValue = 30;

            public const int MinDuration = 1;
            public const int MaxDuration = 6;
        }
        public static class PackageParty
        {
            public const int NameMaxLength = 50;
        }
        public static class Guest
        {
            public const int NameMaxLength = 50;
        }


    }
}
