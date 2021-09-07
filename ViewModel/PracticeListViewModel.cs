using practice2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practice2.ViewModel
{
    public class PracticeListViewModel
    {

        public practice practice { get; set; }

        public string Status { get; set; }
        public string Location_NAME { get; set; }
        public string SalesPersonName { get; set; }
        public string Category { get; set; }
        public string PRojectsTypes { get; set; }
        public string Engagement_type { get; set; }

        public string TimesheetReprName { get; set; }
        public string SubDomains { get; set; }
        public string ClientInvoiceGrp { get; set; }
        public string TimeSheet_Type { get; set; }
        public string IsVmsSheets { get; set; }
        public string Practice_type { get; set; }
        public string RecruitersName { get; set; }
       
        public string StartDateShow { get; set; }
        public string EndDateShow { get; set; }
    }
}