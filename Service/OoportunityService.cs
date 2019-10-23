using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Repositories;
using Web_Api_Demo.Repositories.Interface;
using Web_Api_Demo.Service.Interface;

namespace Web_Api_Demo.Service
{
    public class OoportunityService : IOoportunityService
    {
        private readonly IOpportunityRepositories _Repositories;
        public OoportunityService()
        {
            OpportunityRepositories repositories = new OpportunityRepositories();
            _Repositories = repositories;
        }
        public bool AddOpportunity(OpportunityDTO opp)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOpportunities(string OppId)
        {
            return this._Repositories.DeleteOpportunities(OppId);
        }

        public List<OpportunityDTO> GetOpportunities()
        {
            var result = this._Repositories.GetOpportunities();
            return (from item in result
                    select new OpportunityDTO
                    {
                        OpportunityId = item.OpportunityId,
                        OpportunityNm = item.OpportunityNm,
                        SubCSGNm = item.SubCSGNm,
                        ROStageCd = item.ROStageCd,
                        UpdateDttm = item.UpdateDttm,
                    }).ToList();
        }

        public List<string> GetOpportunityNm(string OppId)
        {
            var result = this._Repositories.GetOpportunityNm(OppId);
            return (from item in result
                    orderby item
                    select item.ToUpper()).ToList(); 
        }

        public bool UpdateOpportunity(string ROCd, string OppId)
        {
            return this._Repositories.UpdateOpportunity(ROCd,OppId);
        }
    }
}