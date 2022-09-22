using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankOfSuccess.Entities
{
    public class FundTransfer
    {
        //PassBook details............
        public Account sender { get; set; }
        public Account receiver;
        public double amount;
        public DateTime timeOfTransfer;
        public TransferMode modeOfTransfer;
        
    }

    //Mode of Transfer...........
    public enum TransferMode
    {
        invallid=0,IMPS=1, RTGS=2, NEFT=3
    }
}


