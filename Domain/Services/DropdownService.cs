using RapidFireLib.Lib.Core;
using RapidFireLib.Models.Api;
using RapidFireLib.View.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DropdownService
    {
        private readonly Db _db;
        private readonly IUserInfo _userInfo;
        public DropdownService() { }
        public DropdownService(Db db, IUserInfo userInfo)
        {
            _db = db;
            _userInfo = userInfo;
        }
        //public List<Country> GetCountryByUser()
        //{
        //    var data = _userInfo.Geo.List<Country>();
        //    //var data = _db.Get<CountryByUserView>(x => x.Id == _userInfo.User.Id).Select(x => new Country { RegionId = x.RegionId, CountryName = x.CountryName, 
        //    //    CountryCode = x.CountryCode, CountryId = x.CountryId, CurrencyId = x.CurrencyId, FlagUrlPath = x.FlagUrlPath, IsActive = x.IsActive, Language = x.Language }).ToList();
        //    return data;
        //}

        //public List<Region> GetRegionByUser()
        //{
        //    var data = _userInfo.Geo.List<Region>();
        //    return data;
        //}

        public List<SpinnerValue> GetStatusList()
        {
            var data = new List<SpinnerValue>
            {
                new SpinnerValue{DisplayText="Active", ValueText="1"},
                new SpinnerValue{DisplayText="Inactive", ValueText="0"},
            };
            return data;
        }
        public List<SpinnerValue> GetOfficeTypeList()
        {
            var data = new List<SpinnerValue>
            {
                new SpinnerValue{DisplayText="Country Office", ValueText="1"},
                new SpinnerValue{DisplayText="Field Office", ValueText="0"},
            };
            return data;
        }
        //public List<SpinnerValue> GetBudgetHolder(string userId)
        //{
        //    return _db.Get<GetBudgetHolders>().Select(x => new SpinnerValue { DisplayText = x.FullName, ValueText = x.UserId.ToString() }).ToList();
        //}
        //public async Task<List<SpinnerValue>> GetSupervisorData(int employeeId, string token)
        //{
        //    string getCharginURL = "https://fleetmsplusapi.scibd.info/api/Fetch/GetPacket";
        //    ApiService apiService = new();
        //    MakeObjHandler objHandler = new();
        //    var obj = objHandler.MakeObj("SupervisorInfo", $"EmployeeID={employeeId}", true);

        //    var response = await apiService.PostDataAsync(getCharginURL, obj, token);
        //    var result = await response.Content.ReadAsStringAsync();
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(result))
        //        {
        //            var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<Employee>>>(result);
        //            var employees = apiResponse?.ApiPacket?.Packet as List<Employee> ?? new List<Employee>();

        //            var supervisors = employees?.Select(e => new SpinnerValue
        //            {
        //                DisplayText = e.EmployeeName,
        //                ValueText = e.EmployeeID.ToString()
        //            }).ToList() ?? new();
        //            return supervisors;
        //        }
        //        else return new();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return new();
        //    }
        //}
    }
}
