﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Data.Entities
{
    public class EmployeeInterest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int InterestId { get; set; }
    }
}
