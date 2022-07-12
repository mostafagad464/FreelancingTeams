using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Models
{
    [Table("UserConnection")]
    public partial class UserConnection
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        [StringLength(250)]
        [Unicode(false)]
        public string ConnectionId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserConnections")]
        public virtual Account User { get; set; }
    }
}
