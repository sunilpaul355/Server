using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaInvoice.Users
{
      [Table("User")]
      public class User
      {
          #region Public Properties

          [Key]
          [Column("UserId", TypeName = "int")]
          public int userId { get; set; }

          [Column("Username", TypeName = "nvarchar")]
          [MaxLength(50)]
          public string username { get; set; }

          [Column("Password", TypeName = "nvarchar")]
          [MaxLength(255)]
          public string password { get; set; }

          [Column("PasswordSalt", TypeName = "nvarchar")]
          [MaxLength(255)]
          public string passwordSalt { get; set; }

          [Column("Email", TypeName = "nvarchar")]
          [MaxLength(255)]
          public string email { get; set; }

          [Column("Approved", TypeName = "bit")]
          public bool approved { get; set; }

          [Column("CreatedTime", TypeName = "datetime")]
          public DateTime createdTime { get; set; }

          [Column("UpdatedTime", TypeName = "datetime")]
          public DateTime updatedTime { get; set; }

          [Column("LastLoginTime", TypeName = "datetime")]
          public DateTime? lastLoginTime { get; set; }

          [Column("ActivityStatus", TypeName = "tinyint")]
          public byte activityStatus { get; set; }

          [Column("LastActivityTime", TypeName = "datetime")]
          public DateTime? lastActivityTime { get; set; }

          [Column("LastPasswordChangedTime", TypeName = "datetime")]
          public DateTime? lastPasswordChangedTime { get; set; }

          [Column("IsLockedOut", TypeName = "bit")]
          public bool isLockedOut { get; set; }

          [Column("LastLockoutTime", TypeName = "datetime")]
          public DateTime? lastLockoutTime { get; set; }

          [Column("LastPasswordFailureTime", TypeName = "datetime")]
          public DateTime? lastPasswordFailureTime { get; set; }

          [Column("PasswordFailuresSinceLastSuccess", TypeName = "int")]
          public int passwordFailuresSinceLastSuccess { get; set; }

          [Column("PasswordVerificationToken", TypeName = "nvarchar")]
          [MaxLength(128)]
          public string passwordVerificationToken { get; set; }

          [Column("PasswordVerificationTokenExpirationTime", TypeName = "datetime")]
          public DateTime? passwordVerificationTokenExpirationTime { get; set; }

          #endregion
      }


}
