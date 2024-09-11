using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dataAccessLayer.Models
{
    public class announcementModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int publicherId{ get; set; }
        [JsonIgnore]
        public UsersModel Users { get; set; } 
        public string Details { get; set; }
    }
}
