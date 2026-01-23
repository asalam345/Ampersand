using RapidFireLib.Lib.Core;

namespace Domain.Aggregates
{
    public class UserRoleInfo : IModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int RoleIndex { get; set; }
        public bool IsActive { get; set; }
    }
}
