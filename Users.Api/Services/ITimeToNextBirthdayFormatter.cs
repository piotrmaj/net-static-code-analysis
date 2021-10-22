using System;

namespace Users.Api.Services
{
    public interface ITimeToNextBirthdayFormatter
    {
        string Format(DateOnly birthDate);
    }
}
