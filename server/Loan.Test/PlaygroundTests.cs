using Microsoft.VisualBasic;

namespace Loan.Test
{
    public class PlaygroundTests : IClassFixture<LoanSeedDataFixture>
    {
        [Fact]
        public void TestIPMT() {

            //Required.The interest rate per period.For example, if you get a car loan at an annual percentage rate(APR) of 10 percent and make monthly payments, the rate per period is 0.1 / 12, or 0.0083.
            double rate = (10d/100d)/12d;

            //Required.The payment period in the range 1 through NPer.
            double per = 10;

            //Required.The total number of payment periods in the annuity. For example, if you make monthly payments on a four-year car loan, your loan has a total of 4 x 12(or 48) payment periods.
            double nPer = 12;

            //Required.The present value, or value today, of a series of future payments or receipts. For example, when you borrow money to buy a ca
            double pv = 1000;

            double interest  = Financial.IPmt(rate, per, nPer, pv);
        }
    }
}
