using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.Model.Client
{
    public sealed class EmptyClientDto: ClientDto 
    {      
        private static readonly EmptyClientDto instance = new EmptyClientDto();
        static EmptyClientDto()
        {
        }
        private EmptyClientDto()
        {
            this.FirstName = String.Empty;
            this.LastName = String.Empty;
        }
        public static EmptyClientDto Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
