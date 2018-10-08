using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass]
    public class RoundingPolicyTests : ObjectTests<RoundingPolicy> {
        protected override RoundingPolicy getRandomObject() {
            return GetRandom.Object<RoundingPolicy>();
        }

        [TestMethod]
        public void StrategyTest() {
            canReadWrite(() => obj.Strategy, x => obj.Strategy = x);
        }

        [TestMethod]
        public void StepTest() {
            canReadWrite(() => obj.Step, x => obj.Step = x,
            ()=>GetRandom.Double(0.0, 0.1));
        }

        [TestMethod]
        public void DecimalsTest() {
            canReadWrite(()=>obj.Decimals, x => obj.Decimals = x, 
            ()=>GetRandom.Int8(-10, 10));
        }

        [TestMethod]
        public void DigitTest() {
            canReadWrite(()=>obj.Digit, x => obj.Digit = x, 
            () => GetRandom.UInt8(1, 9));
        }
    }
}