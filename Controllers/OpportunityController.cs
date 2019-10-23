using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Service;
using Web_Api_Demo.Service.Interface;

namespace Web_Api_Demo.Controllers
{
    public class OpportunityController : ApiController
    {
        private IOoportunityService _OoportunityService;
        public OpportunityController()
        {
            OoportunityService ooportunityService = new OoportunityService();
            _OoportunityService = ooportunityService;
        }

        private const string getOoportunities = "api/Ooportunity/getOoportunities";
        [HttpGet]
        [Route(getOoportunities)]
        public List<OpportunityDTO> GetOoportunities()
        {
            return _OoportunityService.GetOpportunities();
        }

        private const string getOoportunityNm = "api/Ooportunity/getOoportunityNm";
        [HttpGet]
        [Route(getOoportunityNm)]
        public List<string> GetOoportunityNm(string OppId)
        {
            return _OoportunityService.GetOpportunityNm(OppId);
        }

        private const string addOoportunity = "api/Ooportunity/addOoportunity";
        [HttpPut]
        [Route(addOoportunity)]
        public bool AddOoportunity(OpportunityDTO opportunity)
        {
            return _OoportunityService.AddOpportunity(opportunity);
        }

        private const string deleteOoportunity = "api/Ooportunity/deleteOoportunity";
        [HttpDelete]
        [Route(deleteOoportunity)]
        public bool DeleteOoportunity(string OppId)
        {
            return _OoportunityService.DeleteOpportunities(OppId);
        }

        private const string updateOoportunity = "api/Ooportunity/updateOoportunity";
        [HttpPost]
        [Route(updateOoportunity)]
        public bool UpdateOoportunity(string ROCd, string OppId)
        {
            return _OoportunityService.UpdateOpportunity(ROCd, OppId);
        }
    }
}