using Data;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Timers;

namespace HD
{
    [Table("UserInfo")]
    public class UserInfo : IEntity, IEntityTypeBuilder<UserInfo>
    {
        public UserInfo()
        {
            UserId = "";
            RoleId = "";
            UserName = "";
            UserNumber = "";
            Name = "";
            Sex = "";
            Phone = "";
            Email = "";
            Address = "";
            Description = "";
            LastLoginTime = DateTime.Now;
            StateCode = 0;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;

        }

        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime LastLoginTime { get; set; }
        public byte StateCode { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public void Configure(EntityTypeBuilder<UserInfo> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(u => u.UserId);
        }
    }
}
