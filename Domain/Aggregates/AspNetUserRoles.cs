using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class AspNetUserRoles : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int AppUserId { get; set; }
    }
    public class LogHandler : IDbHandler
    {
        public object Handle(DbProcessMode modePrePost, DbProcessType processType, object model)
        {
            throw new NotImplementedException();
        }

        public void Process(object model, int result)
        {
            Console.WriteLine($"Saved {result} rows");
        }
    }
}
