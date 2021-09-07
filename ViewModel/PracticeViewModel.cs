  using practice2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice2.ViewModel
{
    public class PracticeViewModel
    {

        public practice Practice { get; set; }

        public List<SelectListItem> ProjectTypeList { get; set; }

        public List<SelectListItem> ProjectStatusList { get; set; }
        public List<SelectListItem> ProjectCategoryList { get; set; }
        public List<SelectListItem> EngagementTypeList { get;  set; }
        public List<SelectListItem> ClientInvoiceGroupList { get; set; }
        public List<SelectListItem> SubDomainList { get; set; }

        public List<SelectListItem> IsVmsTimeSheet { get; set; }
        public List<SelectListItem> SalespersonList { get; set; }
        public List<SelectListItem> LocationGroupList { get; set; }
        public List<SelectListItem> TimesheetTypeList { get; set; }
        public List<SelectListItem> TimesheetReprList { get; set; }
        public List<SelectListItem> PracticeTypeList { get; set; }
        public List<SelectListItem> payRollStateList { get; set; }
        public List<SelectListItem> RecruiterList { get; set; }
    }
}