using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.sealedModel
{
    public sealed class Roles
    {
        public string Manager { get; set; } = "Manager";
        public string Student { get; set; } = "Student";
        public string Worker { get; set; } = "Worker";


    }
}
