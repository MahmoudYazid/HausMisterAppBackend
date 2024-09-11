using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.Models
{
    public class ContractModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Flat_no { get; set; }
        public string details { get; set; }


            
        public DateTime  time_end_contract { get; set; }
        public DateTime  time_start_contract  { get; set; }
            

    }
}
