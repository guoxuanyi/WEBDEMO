using System.Collections.Generic;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Models.Model;

namespace Web_Api_Demo.Service.Interface
{
    public interface IOoportunityService
    {
        List<OpportunityDTO> GetOpportunities();
        List<string> GetOpportunityNm(string OppId);
        bool AddOpportunity(OpportunityDTO opp);
        bool UpdateOpportunity(string ROCd, string OppId);
        bool DeleteOpportunities(string OppId);
        List<OpportunityModel> GetOpportunityIdAndNm();
    }
}
