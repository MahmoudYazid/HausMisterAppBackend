using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.DTO
{
    public class ContractDto
    {
       
        public int Flat_no { get; set; }
        public string details { get; set; }

        public int StudentId {  get; set; }

        public DateTime time_end_contract { get; set; }
        public DateTime time_start_contract { get; set; }
    }
}
