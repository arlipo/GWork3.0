using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Quantity;
namespace Open.Domain.Quantity {

    public interface IRateRepository: IRepository<Rate, RateData> {

        Task AddRate(string currencyID, decimal rate, DateTime? date = null, string rateTypeID = null);

        Rate GetRate(string rateID);

        List<Rate> GetRates(Currency c);

    }
}