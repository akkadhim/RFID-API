using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidServer.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string Rfid { get; set; }
        public bool IsAllowed { get; set; }
        public long RequestNo { get; set; }
    }
}