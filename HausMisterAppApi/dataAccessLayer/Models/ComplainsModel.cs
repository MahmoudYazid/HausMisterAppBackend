using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.Models
{
    public class ComplainsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string response { get; set; }
        public string status { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("answeredBy")]
        public int? ManagerId{ get; set; }
        public UsersModel Student{ get; set; }
        public UsersModel? answeredBy { get; set; }
        public String Details { get; set; }

    }
}
