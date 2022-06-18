using PublicHolidays.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicHolidays.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidaysAsync(string countryCode, int year);
    }
}
