using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
using Open.Infra;
using Open.Infra.Quantity;
namespace Open.Sentry.Controllers {
    public class CalculatorController : Controller {
        private readonly SentryDbContext db;
        private readonly ICurrencyRepository repository;
        private Currency currency;
        private Currency scoreCurrency;
        private const string properties = "Operation, Amount, CurrencyID, Score, ScoreCurrency, RoundingStrategy, RoundingStep, RoundingDecimals, RoundingDigit";
        public CalculatorController(SentryDbContext r, ICurrencyRepository c) {
            db = r;
            repository = c;
            ConvertMoney.rates = new RatesRepository(db);
        }

        public async Task<IActionResult> Index(MoneyCalculatorView e = null) {
            var currencies = await db.Currencies.ToListAsync();
            var view= e?? new MoneyCalculatorView();
            view.LoadCurrencies(currencies);
            return View(view);
        }

        [HttpPost] 
        public async Task<IActionResult> Index([Bind(properties)] MoneyCalculatorView e, string submit) {
            currency = await repository.GetObject(e.CurrencyID);
            scoreCurrency = await repository.GetObject(e.ScoreCurrency);
            e = submit == "+" ? add(e) :
                submit == "-" ? subtract(e) :
                submit == "*" ? multiply(e) :
                submit == "%" ? divide(e) :
                submit == "Convert" ? convert(e) :
                submit == "Round" ? round(e) :
                submit == "=" ? result(e) :
                new MoneyCalculatorView();
            var view = new MoneyCalculatorView();
            view.ScoreCurrency = e.ScoreCurrency;
            view.Score = e.Score;
            view.CurrencyID = e.CurrencyID;
            view.Amount = e.Amount;
            view.Operation = e.Operation;
            view.RoundingStep = e.RoundingStep;
            view.RoundingDigit = e.RoundingDigit;
            view.RoundingDecimals = e.RoundingDecimals;
            view.RoundingStrategy = e.RoundingStrategy;
            return RedirectToAction("Index", view);
        }
        private MoneyCalculatorView result(MoneyCalculatorView v) {
            var r = v.Operation== MoneyOperation.Round? performRound(v)
                : v.Operation == MoneyOperation.Convert? performConvert(v)
                : perform(v, v.Operation);
            r.Amount = 0;
            r.CurrencyID = null;
            r.Operation = MoneyOperation.Dummy;
            return r;
        }
        private MoneyCalculatorView performConvert(MoneyCalculatorView v) {
            var x = new Money(scoreCurrency, v.Score);
            var y = x.ConvertTo(currency);
            v.Score = y.Amount;
            v.ScoreCurrency = y.Currency.ID;
            return v;
        }
        private MoneyCalculatorView performRound(MoneyCalculatorView v) {
            var x = new Money(scoreCurrency, v.Score);
            var y = x.Round(new RoundingPolicy(v.RoundingStrategy, v.RoundingDecimals, v.RoundingDigit,
                v.RoundingStep));
            v.Score = y.Amount;
            v.ScoreCurrency = y.Currency.ID;
            return v;
        }
        private MoneyCalculatorView round(MoneyCalculatorView v) {
            v.Operation = MoneyOperation.Round;
            return v;
        }
        private MoneyCalculatorView convert(MoneyCalculatorView v) {
            v.Operation = MoneyOperation.Convert;
            return v;
        }
        private MoneyCalculatorView divide(MoneyCalculatorView v) {
            return perform(v, MoneyOperation.Divide);
        }
        private MoneyCalculatorView multiply(MoneyCalculatorView v) {
            return perform(v, MoneyOperation.Multiply);
        }
        private MoneyCalculatorView subtract(MoneyCalculatorView v) {
            return perform(v, MoneyOperation.Subtract);
        }
        private MoneyCalculatorView add(MoneyCalculatorView v) {
            return perform(v, MoneyOperation.Add);
        }
        private MoneyCalculatorView perform(MoneyCalculatorView v, MoneyOperation op) {
            var x = new Money(scoreCurrency, v.Score);
            var y = new Money(currency, v.Amount);
            var result = op == MoneyOperation.Add? x.Add(y) 
                : op==MoneyOperation.Subtract? x.Subtract(y)
                : op==MoneyOperation.Multiply? x.Multiply(y.Amount)
                : op==MoneyOperation.Divide? x.Divide(y.Amount)
                : x;
            v.Score = result.Amount;
            v.ScoreCurrency = result.Currency.ID;
            v.Operation = op;
            return v;
        }
    }
}