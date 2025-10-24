using Week3Task1.Exceptions;

namespace Week3Task1.Helpers;

public static class ValidationHelper
{
    public static void CheckId(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("ID must be a positive integer");
        }
    }
}