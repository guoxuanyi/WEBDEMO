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
        bool AddOpportunity(Opportunity opp);
        bool UpdateOpportunity(string RC, string OppId);
        bool DeleteOpportunities(string OppId);
    }
}