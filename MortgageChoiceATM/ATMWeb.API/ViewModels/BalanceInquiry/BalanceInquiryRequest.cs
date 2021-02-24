using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMWeb.API.ViewModels.BalanceInquiry
{
    public class BalanceInquiryRequest
    {
        public int AcctId { get; set; }        

        protected BalanceInquiryRequest()
        { 
        }

        public BalanceInquiryRequest(int acctId) : this()
        {
            AcctId = acctId;            
        }

    }
}
