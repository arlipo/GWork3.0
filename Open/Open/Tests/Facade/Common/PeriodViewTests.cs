using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;
namespace Open.Tests.Facade.Common {
    [TestClass] public class PeriodViewTests : ViewTests<PeriodView, Archetype> {
        class testClass : PeriodView { }
        protected override PeriodView getRandomObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod] public void ValidFromTest() {
            DateTime? rnd() => GetRandom.DateTime(null, obj.ValidTo?.AddYears(-1));
            canReadWrite(() => obj.ValidFrom, x => obj.ValidFrom = x, rnd);
        }
        [TestMethod] public void ValidToTest() {
            DateTime? rnd() => GetRandom.DateTime(obj.ValidFrom?.AddYears(1));
            canReadWrite(() => obj.ValidTo, x => obj.ValidTo = x, rnd);
        }
    }
}

