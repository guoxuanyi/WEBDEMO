using System.Collections.Generic;
using System.Web.Http;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Models.Model;
using Web_Api_Demo.Service;
using Web_Api_Demo.Service.Interface;

namespace Web_Api_Demo.Controllers
{
    public class OpportunityController : ApiController
    {
        private readonly IOoportunityService _OoportunityService = new OoportunityService();

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
        public List<string> GetOoportunityNm([FromUri]string OppId)
        {
            return _OoportunityService.GetOpportunityNm(OppId);
        }

        private const string addOoportunity = "api/Ooportunity/addOoportunity";
        [HttpPut]
        [Route(addOoportunity)]
        public bool AddOoportunity([FromBody]OpportunityDTO opportunity)
        {
            return _OoportunityService.AddOpportunity(opportunity);
        }

        private const string deleteOoportunity = "api/Ooportunity/deleteOoportunity";
        [HttpDelete]
        [Route(deleteOoportunity)]
        public bool DeleteOoportunity([FromUri]string OppId)
        {
            return _OoportunityService.DeleteOpportunities(OppId);
        }

        private const string updateOoportunity = "api/Ooportunity/updateOoportunity";
        [HttpPost]
        [Route(updateOoportunity)]
        public bool UpdateOoportunity([FromBody]OpportunityDTO uOpp)
        {
            return _OoportunityService.UpdateOpportunity(uOpp);
        }

        private const string getOpportunityIdAndNm = "api/Ooportunity/getOpportunityIdAndNm";
        [HttpGet]
        [Route(getOpportunityIdAndNm)]
        public List<OpportunityModel> GetOpportunityIdAndNm()
        {
            return _OoportunityService.GetOpportunityIdAndNm();
        }

        private const string getNewAddOpportunity = "api/Ooportunity/getNewAddOpportunity";
        [HttpGet]
        [Route(getNewAddOpportunity)]
        public List<OpportunityDTO> GetNewAddOpportunity()
        {
            return _OoportunityService.GetNewAddOpportunity();
        }
    }
}