using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practice2.Models
{
    public class practice
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }


        [Display(Name = "start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int ProjectStatus { get; set; }

        public int LocationGroup { get; set; }

        public int PayRollState { get; set; }

        public int SalesPerson { get; set; }

        public int ProjectCategory { get; set; }

        public int ProjectType { get; set; }
        public int EngagementType { get; set; }

        public int TimesheetRepNames { get; set; }
        public int SubDomain { get; set; }

        public int ClientInvGrp { get; set; }

        public int TimesheetTypes { get; set; }

        public int IsVmsSheet { get; set; }

        public int PracticeType { get; set; }

        public int RecruiterNames { get; set; }

     


    }
}