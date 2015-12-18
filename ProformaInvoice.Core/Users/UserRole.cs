using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaInvoice.Users
{
    [Table("UserRole")]
    public class UserRole
    {
        #region Public Properties

        [Key]
        [Column("UserId", TypeName = "int")]
        public int userId { get; set; }

        [Key]
        [Column("RoleId", TypeName = "int")]
        public int roleId { get; set; }

        [Column("StartTime", TypeName = "datetime")]
        public DateTime? startTime { get; set; }

        [Column("EndTime", TypeName = "datetime")]
        public DateTime? endTime { get; set; }

        #endregion
    }

}
