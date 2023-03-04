namespace AssetManagementTestProject.TestData
{
    public class CreateNewCategory
    {
        public string? ValidCategoryName;
        public string? ValidCategoryPrefix;
        public string? InvalidCategoryname;
        public string? InvalidCategoryPrefix;
        private static Random random = new Random();
        public string CreateNewValidCategoryName(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }   

            var finalString = new String(stringChars);
            return finalString;
        }
        public string CreateNewValidCategoryPrefix(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }   

            var finalString = new String(stringChars);
            return finalString;
        }
        public string CreateInvalidCategoryPrefix(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }   

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
