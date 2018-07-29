using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Data.Model
{
    public class EmployeeCharacteristic
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }

        public bool IsPublic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
