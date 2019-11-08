using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_Demo.Repositories.DB;

namespace Web_Api_Demo.Repositories.Interface
{
    public interface IOpportunityRepositories
    {
        List<string> GetOpportunityNm(string OppId);
        List<Opportunity> GetOpportunities();
        List<Opportunity> GetOpportunityByNm(string OppNm);
        bool AddOpportunity(Opportunity opp);
        bool UpdateOpportunity(Opportunity opp);
        bool DeleteOpportunities(string OppId);
        List<Opportunity> GetNewAddOpportunity();
    }
}