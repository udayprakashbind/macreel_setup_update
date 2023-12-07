using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_leave
    {
        public int id { get; set; }
        public string Employeeid { get; set; }
        public string EmployeeType { get; set; }
        public string Department { get; set; }
        public int EarnedOrPrivilegeLeave { get; set; }
        public int EarnedOrPrivilegeLeaveUsed { get; set; }
        public int CasualLeave { get; set; }
        public int CasualLeaveUsed { get; set; }
        public int SickOrMedicalLeave { get; set; }
        public int SickOrMedicalLeaveUsed { get; set; }
        public int MaternityLeave { get; set; }
        public int MaternityLeaveUsed { get; set; }
        public int QuarantineLeave { get; set; }
        public int QuarantineLeaveUsed { get; set; }
        public DateTime SessionStartFrom { get; set; }
        public DateTime SessionEndTo { get; set; }
        public string Status { get; set; }
    }
}