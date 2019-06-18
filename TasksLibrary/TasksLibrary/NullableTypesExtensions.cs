namespace TasksLibrary
{
    public static class NullableTypesExtensions
    {
        public static bool IsNull<T>(this T? input) where T : struct
        {
            return input == null;
        }

        public static bool IsNull<T>(this T input) where T : class
        {
            return input == null;
        }
    }
}
