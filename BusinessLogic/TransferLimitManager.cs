using BankOfSuccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.BusinessLogic
{
    class TransferLimitManager
    {
        // Dictionary List of Privilege and there Limit..........
        private static Dictionary<Privilege, double> TransferLimit = new Dictionary<Privilege, double>();

        static TransferLimitManager()
        {
            TransferLimit.Add(Privilege.SILVER, 25000.00);
            TransferLimit.Add(Privilege.GOLD, 50000.00);
            TransferLimit.Add(Privilege.PREMIUM, 100000.00);
      
        }
        //Givs the transfer limits for perticular Privilege........
        public static double GetTransferLimit(Privilege privilege)
        {
            return TransferLimit[privilege];
        }
    }
}
