using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using practice2.Models;
using practice2.Repository;
using practice2.ViewModel;

namespace practice2.Controllers.Api
{
    public class ProjectApiController : ApiController
    {
        [Route("Practice/GetProjectsAddED")]
        public IHttpActionResult Getprojects()
        {
            var pl = new SampleRepo().GetProjectData();
            return Ok(pl);
        }


        [Route("Practice/AddProjectDetail")]
        public IHttpActionResult AddProjectDetail(practice pm)
        {
            var pl = new SampleRepo().AddProject(pm);
            return Ok(pl);
           

        }

        [Route("Practice/GetProject")]
        public IHttpActionResult GetProjectDetail(int id)
        {
            var pld = new SampleRepo().GetProjectDetailById(id);
            return Ok(pld);


        }


    }
}
