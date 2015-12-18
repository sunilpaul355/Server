using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaInvoice.Users
{
    [Table("Role")]
    public class Role
    {
        #region Public Properties

        [Key]
        [Column("RoleId", TypeName = "int")]
        public int roleId { get; set; }

        [Column("RoleName", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string roleName { get; set; }

        [Column("Description", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string description { get; set; }

        #endregion
    }

}
