using practice2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practice2.Controllers.Api
{
    public class MasterController : ApiController
    {


        [Route("Master/GetAppRefData")]
        public IHttpActionResult GetAppRefData(int parentId)
        {
            var appRefDataList = new SampleRepo().GetAppRefData(parentId);
            return Ok(appRefDataList);
        }

        [Route("Master/GetAppRefChildData")]
        public IHttpActionResult GetAppRefChildData(int parentId)
        {
            var appRefDataList = new SampleRepo().GetAppRefChildSubDomain(parentId);
            return Ok(appRefDataList);
        }

        [Route("Master/GetLocationGroups")]
        public IHttpActionResult GetLocationGroups()
        {
            var list = new SampleRepo().GetLocationGroups();
            return Ok(list);
        }

        [Route("Master/GetRecruiterSalePerson")]
        public IHttpActionResult GetRecruiterSalePerson()
        {
            var list = new SampleRepo().GetRecruiterList();
            return Ok(list);
        }
        [Route("Master/GetTimesheetRep")]
        public IHttpActionResult GetTimesheetRepNames()
        {
            var list = new SampleRepo().GetTimesheetRepNames();
            return Ok(list);
        }
        [Route("Master/GetPayrollState")]
        public IHttpActionResult GetAllPayRollState()
        {
            var list = new SampleRepo().GetAllPayRollState();
            return Ok(list);
        }
       

    }
}
