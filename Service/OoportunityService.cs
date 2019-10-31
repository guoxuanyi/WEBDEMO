using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Xml.Linq;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Models.Model;
using Web_Api_Demo.Repositories;
using Web_Api_Demo.Repositories.DB;
using Web_Api_Demo.Repositories.Interface;
using Web_Api_Demo.Service.Interface;

namespace Web_Api_Demo.Service
{
    public class OoportunityService : IOoportunityService
    {
        private readonly IOpportunityRepositories _Repositories = new OpportunityRepositories();
        public bool AddOpportunity(OpportunityDTO opp)
        {
            Opportunity dbOpp = Mapper.Map<OpportunityDTO, Opportunity>(opp);
            return this._Repositories.AddOpportunity(dbOpp);
        }

        public bool DeleteOpportunities(string OppId)
        {
            return this._Repositories.DeleteOpportunities(OppId);
        }

        public List<OpportunityDTO> GetOpportunities()
        {
            var result = this._Repositories.GetOpportunities();
            var list = Mapper.Map<List<Opportunity>, List<OpportunityDTO>>(result);
            Tools.CreateXml(list);
            return list;
        }

        public List<OpportunityModel> GetOpportunityIdAndNm()
        {
            var list = this._Repositories.GetOpportunities()
                .Select(s => new OpportunityModel
                {
                    OpportunityId = s.OpportunityId,
                    OpportunityNm = s.OpportunityNm
                }).ToList();
            return list;
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
            return this._Repositories.UpdateOpportunity(ROCd, OppId);
        }
    }
}