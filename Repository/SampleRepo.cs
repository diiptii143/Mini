using practice2.Models;
using practice2.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice2.Repository
{
    public class SampleRepo
    {
        //Declaration
        SqlConnection conn;
        // Create the connection.
        //Initialize
        public SampleRepo()
        {
            // Create the connection.
            //Initialize
            conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ConnSample"].ConnectionString);

        }



        public int AddProject(practice pm)
        {
            // Create the command.
            SqlCommand cmd = new SqlCommand("AddEditProject_Deepti_Training", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerName", pm.CustomerName);
            cmd.Parameters.AddWithValue("@ProjectName", pm.ProjectName);
            cmd.Parameters.AddWithValue("@ProjectId", pm.ProjectId);
            cmd.Parameters.AddWithValue("@StartDate", pm.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", pm.EndDate);
            cmd.Parameters.AddWithValue("@ProjectStatus", pm.ProjectStatus);
            cmd.Parameters.AddWithValue("@LocationGroup", pm.LocationGroup);
            cmd.Parameters.AddWithValue("@PayRollState", pm.PayRollState);
            cmd.Parameters.AddWithValue("@SalesPerson", pm.SalesPerson);
            cmd.Parameters.AddWithValue("@ProjectCategory", pm.ProjectCategory);
            cmd.Parameters.AddWithValue("@ProjectType", pm.ProjectType);
            cmd.Parameters.AddWithValue("@EngagementType", pm.EngagementType);
            cmd.Parameters.AddWithValue("@TimesheetRepNames", pm.TimesheetRepNames);
            cmd.Parameters.AddWithValue("@SubDomain", pm.SubDomain);
            cmd.Parameters.AddWithValue("@ClientInvGrp", pm.ClientInvGrp);
            cmd.Parameters.AddWithValue("@TimesheetTypes", pm.TimesheetTypes);
            cmd.Parameters.AddWithValue("@IsVmsSheet", pm.IsVmsSheet);
            cmd.Parameters.AddWithValue("@PracticeType", pm.PracticeType);
            cmd.Parameters.AddWithValue("@RecruiterNames", pm.RecruiterNames);
            cmd.Parameters.AddWithValue("@Id", pm.Id);


            // Open the connection and create the DataReader.
            conn.Open();

            int retVal = cmd.ExecuteNonQuery();

            conn.Close();

            return retVal;
        }

        public int UpdateProject(practice pmr)
        {
            // Create the command.
            SqlCommand cmd = new SqlCommand("UpdateProjectDetail_Training_deepti", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prID", pmr.ProjectId);
            cmd.Parameters.AddWithValue("@CustomerName", pmr.CustomerName);
            cmd.Parameters.AddWithValue("@ProjectName", pmr.ProjectName);
            cmd.Parameters.AddWithValue("@ProjectId", pmr.ProjectId);
            cmd.Parameters.AddWithValue("@StartDate", pmr.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", pmr.EndDate);
            cmd.Parameters.AddWithValue("@ProjectStatus", pmr.ProjectStatus);
            cmd.Parameters.AddWithValue("@LocationGroup", pmr.LocationGroup);
            cmd.Parameters.AddWithValue("@PayRollState", pmr.PayRollState);
            cmd.Parameters.AddWithValue("@SalesPerson", pmr.SalesPerson);
            cmd.Parameters.AddWithValue("@ProjectCategory", pmr.ProjectCategory);
            cmd.Parameters.AddWithValue("@ProjectType", pmr.ProjectType);
            cmd.Parameters.AddWithValue("@EngagementType", pmr.EngagementType);
            cmd.Parameters.AddWithValue("@TimesheetRepNames", pmr.TimesheetRepNames);
            cmd.Parameters.AddWithValue("@SubDomain", pmr.SubDomain);
            cmd.Parameters.AddWithValue("@ClientInvGrp", pmr.ClientInvGrp);
            cmd.Parameters.AddWithValue("@TimesheetTypes", pmr.TimesheetTypes);
            cmd.Parameters.AddWithValue("@IsVmsSheet", pmr.IsVmsSheet);
            cmd.Parameters.AddWithValue("@PracticeType", pmr.PracticeType);
            cmd.Parameters.AddWithValue("@RecruiterNames", pmr.RecruiterNames);


            // Open the connection and create the DataReader.
            conn.Open();

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            return result;
        }


        public List<PracticeListViewModel> GetProjectData()
        {
            var prlist = new List<PracticeListViewModel>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetAllProject_Deepti_Training", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                var prj = new practice();
                var prjs = new PracticeListViewModel
                {
                    practice = prj
                };


                prjs.practice.Id = Convert.ToInt32(reader["PrID"]);
                prjs.practice.CustomerName = reader["CustomerName"].ToString();
                prjs.practice.ProjectName = reader["ProjectName"].ToString();
                prjs.practice.ProjectId = reader["ProjectId"].ToString();
                //prjs.practice.StartDate = Convert.ToDateTime(reader["StartDate"]);
                //if(reader["EndDate"] != DBNull.Value)
                //prjs.practice.EndDate =  Convert.ToDateTime(reader["EndDate"]);
                prjs.StartDateShow = reader["StartDate"].ToString();
                if (reader["EndDate"] != DBNull.Value)
                    prjs.EndDateShow = reader["EndDate"].ToString();

                prjs.Status = reader["Status"].ToString();
                prjs.Location_NAME = reader["Location_NAME"].ToString();
                prjs.SalesPersonName = reader["SalesPersonName"].ToString();
                prjs.Category = reader["Category"].ToString();
                prjs.PRojectsTypes = reader["PRojectsTypes"].ToString();
                prjs.Engagement_type = reader["Engagement_type"].ToString();
                prjs.TimesheetReprName = reader["TimesheetReprName"].ToString();
                prjs.SubDomains = reader["SubDomains"].ToString();
                prjs.ClientInvoiceGrp = reader["ClientInvoiceGrp"].ToString();
                prjs.TimeSheet_Type = reader["TimeSheet_Type"].ToString();
                prjs.IsVmsSheets = reader["IsVmsSheets"].ToString();
                prjs.Practice_type = reader["Practice_type"].ToString();
                prjs.RecruitersName = reader["RecruitersName"].ToString();

                prlist.Add(prjs);
            }
            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();
            return prlist;
        }

        public List<SelectListItem> GetAppRefData(int parentId)
        {
            List<SelectListItem> appRefDataList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetAppRefData_Deepti", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@parentId", SqlDbType.Int);

            // Set the input parameter value.
            cmd.Parameters["@ParentId"].Value = parentId;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                appRefDataList.Add(new SelectListItem { Value = reader["ID"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return appRefDataList;
        }

        public List<SelectListItem> GetLocationGroups()
        {
            List<SelectListItem> LocationGroupList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetAllLocationGroup", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                LocationGroupList.Add(new SelectListItem { Value = reader["Id"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return LocationGroupList;
        }

        public List<SelectListItem> GetAllPayRollState()
        {
            List<SelectListItem> payRollStateList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("PayRollStateList", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                payRollStateList.Add(new SelectListItem { Value = reader["Id"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return payRollStateList;
        }

        public List<SelectListItem> GetSalePersonName()
        {
            List<SelectListItem> SalespersonList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetProjectInhouse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@dptType", SqlDbType.VarChar);

            // Set the input parameter value.
            cmd.Parameters["@dptType"].Value = "Sales";

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                SalespersonList.Add(new SelectListItem { Value = reader["Id"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return SalespersonList;
        }
        public List<SelectListItem> GetTimesheetRepNames()
        {
            List<SelectListItem> TimesheetReprList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetProjectInhouse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@dptType", SqlDbType.VarChar);

            // Set the input parameter value.
            cmd.Parameters["@dptType"].Value = "Timesheet";

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                TimesheetReprList.Add(new SelectListItem { Value = reader["Id"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return TimesheetReprList;
        }
        public List<SelectListItem> GetRecruiterList()
        {
            List<SelectListItem> RecruiterList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetProjectInhouse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@dptType", SqlDbType.VarChar);

            // Set the input parameter value.
            cmd.Parameters["@dptType"].Value = "Recruiter";

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                RecruiterList.Add(new SelectListItem { Value = reader["Id"].ToString(), Text = Convert.ToString(reader["Name"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return RecruiterList;
        }
        public List<SelectListItem> GetAppRefChildSubDomain(int parentId)
        {
            List<SelectListItem> SubDomainList = new List<SelectListItem>();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetSubDomain", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@parentId", SqlDbType.Int);

            // Set the input parameter value.
            cmd.Parameters["@parentId"].Value = parentId;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                // Code to process result set in DataReader.
                SubDomainList.Add(new SelectListItem { Value = reader["keyId"].ToString(), Text = Convert.ToString(reader["KeyName"]) });
            }

            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();

            return SubDomainList;
        }

        public practice GetProjectDetailById(int prjID)
        {
            var prj = new practice();

            // Create the command.
            SqlCommand cmd = new SqlCommand("GetProjectDetailsById", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define the input parameter for the command.
            cmd.Parameters.Add("@projectId", SqlDbType.VarChar);

            // Set the input parameter value.
            cmd.Parameters["@projectId"].Value = prjID;

            // Open the connection and create the DataReader.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate over the records for the DataReader.
            while (reader.Read())
            {
                prj.Id = Convert.ToInt32(reader["PrID"]);
                prj.CustomerName = reader["CustomerName"].ToString();
                prj.ProjectName = reader["ProjectName"].ToString();
                prj.ProjectId = reader["ProjectId"].ToString();
                prj.StartDate = Convert.ToDateTime(reader["StartDate"]);
                if (reader["EndDate"] != DBNull.Value)
                    prj.EndDate = Convert.ToDateTime(reader["EndDate"]);
                //prj.StartDateShow = reader["StartDate"].ToString();
                //if (reader["EndDate"] != DBNull.Value)
                //    prj.EndDateShow = reader["EndDate"].ToString();

                prj.ProjectStatus = Convert.ToInt32(reader["ProjectStatus"] );
                prj.LocationGroup = Convert.ToInt32(reader["LocationGroup"]);
                prj.PayRollState = Convert.ToInt32(reader["PayRollState"]);
                prj.SalesPerson = Convert.ToInt32(reader["SalesPerson"]);
                prj.ProjectCategory = Convert.ToInt32(reader["ProjectCategory"]);
                prj.ProjectType = Convert.ToInt32(reader["ProjectType"]);
                prj.EngagementType = Convert.ToInt32(reader["EngagementType"]);
                prj.TimesheetRepNames = Convert.ToInt32(reader["TimesheetRepNames"]);
                prj.SubDomain = Convert.ToInt32(reader["SubDomain"]);
                prj.ClientInvGrp = Convert.ToInt32(reader["ClientInvGrp"]);
                prj.TimesheetTypes = Convert.ToInt32(reader["TimesheetTypes"]);
                prj.IsVmsSheet = Convert.ToInt32(reader["IsVmsSheet"]);
                prj.PracticeType = Convert.ToInt32(reader["PracticeType"]);
                prj.RecruiterNames = Convert.ToInt32(reader["RecruiterNames"]);

            }
            // Close the DataReader.
            reader.Close();
            // Close the connection.
            conn.Close();
            return prj;
        }


    }
}