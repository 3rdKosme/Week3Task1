namespace Week3Task1.Helpers;

public static class ValidationHelper
{
    public static void CheckId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID must be a positive integer");
        }
    }
}