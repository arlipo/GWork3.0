using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Infra.Quantity {

    public class RatesRepository : Repository<Rate, RateData>, IRateRepository {

        public RatesRepository(SentryDbContext c) : base(c?.Rates, c) { }

        public async Task AddRate(string currencyID, decimal rate, DateTime? date = null,
            string rateTypeID = null) {
            var r = RateFactory.Create(currencyID, rate, date ?? DateTime.Today,
                rateTypeID ?? RateFactory.EuroRate);
            await AddObject(r);
        }

        public Rate GetRate(string rateID) {
            var r = dbSet.Find(rateID);
            return createObject(r);
        }

        public List<Rate> GetRates(Currency c) {
            var rates = getSorted()
                .Where(s => s.CurrencyID == c.ID)
                .AsNoTracking();
            var l = rates.ToList();
            var list = new List<Rate>();
            foreach (var r in l) list.Add(createObject(r));
            return list;
        }

        protected internal override Rate createObject(RateData r) {
            return new Rate(r);
        }

        protected internal override PaginatedList<Rate> createList(List<RateData> l,
            RepositoryPage p) {
            return new RatesList(l, p);
        }

        protected internal override async Task<RateData> getObject(string id) {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        private IQueryable<RateData> getSet() {
            return from s in dbSet select s;
        }

        private IQueryable<RateData> getSorted() {
            return getSet()
                .OrderBy(x => x.ValidFrom);
        }
    }
}
