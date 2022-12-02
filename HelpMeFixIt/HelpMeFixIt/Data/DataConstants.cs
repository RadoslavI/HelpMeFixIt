namespace HelpMeFixIt.Data
{
    public static class DataConstants
    {
        public static class Announcement
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 6;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 20;
        }

        public static class Category
        {
            public const int NameMaxLength = 25;
            public const int NameMinLength = 3;
        }

        public static class Comment
        {
            public const int TextMaxLength = 250;
            public const int TextMinLength = 5;
        }

        public static class Fixer
        {
            public const int PhoneMaxLength = 15;
            public const int PhoneMinLength = 3;
        }

        public static class Opinion
        {
            public const int TextMaxLength = 250;
            public const int TextMinLength = 10;
        }
    }
}
