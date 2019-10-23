using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Web_Api_Demo.Repositories.DB;
using Web_Api_Demo.Repositories.Interface;

namespace Web_Api_Demo.Repositories
{
    public class OpportunityRepositories : IOpportunityRepositories
    {
        private Entities1 context = new Entities1();
        public bool AddOpportunity(DB.Opportunity opp)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOpportunities(string OppId)
        {
            StringBuilder sb = new StringBuilder(@"delete from ro.Opportunity 
                                                   where OpportunityId = @OpportunityId");
            StringBuilder sb1 = new StringBuilder(@"select count(1) from ro.Opportunity
                                                    where OpportunityId = @OpportunityId");
            SqlParameter sqlParameter = new SqlParameter("@OpportunityId", OppId);
            int count = Convert.ToInt32(context.Database.SqlQuery<int>(sb1.ToString(), sqlParameter));
            if (count != 0)
            {
                context.Database.ExecuteSqlCommand(sb.ToString(), sqlParameter);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DB.Opportunity> GetOpportunities()
        {
            StringBuilder sb = new StringBuilder("SELECT * FROM [ro].[Opportunity]");
            var result = context.Database.SqlQuery<DB.Opportunity>(sb.ToString()).ToList();
            return result;
        }

        public List<string> GetOpportunityNm(string OppId)
        {
            StringBuilder sb = new StringBuilder(@"SELECT [OpportunityNm] 
                                                   FROM [ro].[Opportunity] 
                                                   WHERE [OpportunityId] = @OpportunityId");
            return context.Database.SqlQuery<string>(sb.ToString(),
                new SqlParameter("@OpportunityId", OppId)).ToList();
        }

        public bool UpdateOpportunity(string ROCd, string OppId)
        {
            StringBuilder sb = new StringBuilder(@"select count(*) from ro.Opportunity
                                                    where OpportunityId= @OpportunityId
                                                    and ROStageCd = @ROStageCd");

            StringBuilder sb1 = new StringBuilder(@"update ro.Opportunity set ROStageCd = @ROStageCd 
                                                   where OpportunityId= @OpportunityId");

            SqlParameter sqlParameter1 = new SqlParameter("@ROStageCd", ROCd);
            SqlParameter sqlParameter2 = new SqlParameter("@OpportunityId", OppId);
            int count = Convert.ToInt32(context.Database.SqlQuery<int>(sb.ToString(), sqlParameter1, sqlParameter2));
            if (count != 0)
            {
                context.Database.ExecuteSqlCommand(sb1.ToString(), sqlParameter1, sqlParameter2);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}