using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [SugarTable("UserInfo")]
    public class UserInfo
    {
        public UserInfo() { }

        [SugarColumn(IsPrimaryKey = true)]
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
    }
}
