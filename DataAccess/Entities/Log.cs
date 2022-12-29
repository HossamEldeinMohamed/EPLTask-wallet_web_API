using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Log : Entity
    {
        public string TransformerUser { get; set; }
        public string TransferredTo { get; set; }
        public DateTime Date { get; set; }
        public double Balance { get; set; }
    }
}
