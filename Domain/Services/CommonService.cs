using Domain.Aggregates;
using Domain.Handlers;
using RapidFireLib.Lib.Core;
using RapidFireLib.Models.Api;
using RapidFireLib.View.UserInfo;
using RapidFireUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CommonService
    {
        private readonly Db _db;
        private readonly RF _rf;
        private readonly IUserInfo _userInfo;
        public CommonService(Db db, RF rf, IUserInfo userInfo)
        {
            _db = db;
            _rf = rf;
            _userInfo = userInfo;
        }

        
        public UserRoleInfo GetUserRoleInfo()
        {
            UserRoleInfo userRoleInfo = new();
            userRoleInfo = _db.Get<UserRoleInfo>($"EXEC GetUserRoleInfo '{_userInfo.User.Id}'")?.FirstOrDefault()!;
            return userRoleInfo;
        }
        
        public async Task Back()
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(2000);
                _rf.UI.Events.Back();

            });
        }
        public async Task GetSupervisor(string where)
        {
            string sqlQuery = string.Empty;
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlQuery = string.Format(@"SELECT DISTINCT CAST(StaffID AS INT) EmployeeID, FullName + ', ' + Designation AS EmployeeName, Email 
FROM [BDCOMIS].PowerPayment.dbo.viewSODNew  s
left join ChargingDetails cd on  cd.SOF=s.SOF
Where " + where + " GROUP BY s.StaffID, s.FullName, s.Designation, s.Email, s.Limit HAVING s.Limit >= SUM(ISNULL(cd.Amount, 0))");

            }
            else
                sqlQuery = string.Format(@"SELECT CAST([BDCOMIS].PowerPayment.dbo.BudgetHolders.StaffID AS INT) AS EmployeeID, 
HRGW.dbo.EmployeeInfo.FullName + ', ' + HRGW.dbo.EmployeeInfo.Designation AS EmployeeName, Email  
FROM [BDCOMIS].PowerPayment.dbo.BudgetHolders 
INNER JOIN HRGW.dbo.EmployeeInfo 
ON CAST([BDCOMIS].PowerPayment.dbo.BudgetHolders.StaffID AS INT) =  HRGW.dbo.EmployeeInfo.EmployeeID 
WHERE ([BDCOMIS].PowerPayment.dbo.BudgetHolders.IsActive = 1) 
ORDER BY HRGW.dbo.EmployeeInfo.FullName ASC");

        }
    }
}
