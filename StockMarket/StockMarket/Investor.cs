using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        // geters and seters
        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }

            // constructor
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }


                    // methods:
        //•	Getter Count - returns the count of the currently owned stocks.
        public int Count
        {
            get => this.portfolio.Count; 
        }

        //•	Method void BuyStock(Stock stock) – add a single stock of the given company if the stock’s market capitalization is bigger than $10000 and the investor has enough money. Then reduce the MoneyToInvest by the price of the stock. If a stock cannot be bought the method should not do anything.
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && moneyToInvest>=stock.PricePerShare)
            {
                this.portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        //•	Method string SellStock(string companyName, decimal sellPrice) - sell a Stock from the portfolio
        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (Stock item in this.portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    if (sellPrice<item.PricePerShare)
                    {
                        return "Cannot sell " + companyName + ".";
                    }
                    else
                    {
                        this.portfolio.Remove(item);
                        MoneyToInvest += sellPrice;
                        return companyName + " was sold.";
                    }
                }
            }
            return companyName + " does not exist.";
        }

        //•	Method Stock FindStock(string companyName) - returns a Stock with the given company name. If it doesn't exist, return null.
        public Stock FindStock(string companyName)
        {
            foreach (Stock item in this.portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    return item;
                }
            }
            return null;
        }
        //•	Method Stock FindBiggestCompany() – returns the Stock with the biggest market capitalization. If there are no stocks in the portfolio, the method should return null. 
        public Stock FindBiggestCompany()
        {
            if (this.portfolio.Count == 0)
            {
                return null;
            }
            return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            //Stock stock = null;
            //decimal maxValue = 0;
            //foreach (var item in this.portfolio)
            //{
            //    if (item.MarketCapitalization > maxValue)
            //    {
            //        maxValue = item.MarketCapitalization;
            //        stock = item;
            //    }
            //}
            //return stock;
        }

        //•	Method string InvestorInformation() - returns information about the Investor and his portfolio
        public string InvestorInformation()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"The investor " + FullName + " with a broker " + BrokerName + " has stocks:");
            foreach (Stock stock in this.portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString();
        }
    }
}
