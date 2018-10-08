//TODO
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class UnitViewTests : ClassTests<UnitView> {

        //private Unit obj;

        //[ClassInitialize] public static void ClassInitailize(TestContext t) {
        //    Units.Instance.Clear();
        //    Measures.Instance.Clear();
        //    Distance.Initialize();
        //    MassUNitsinitializer.Initialize();
        //    Time.Initialize();
        //    Counter.Initialize();
        //    ManHour.Initialize();
        //    Temperature.Initialize();
        //    Percentage.Initialize();
        //    Area.Initialize();
        //    Volume.Initialize();
        //}

        //[ClassCleanup] public static void ClassCleanup() { }

        //[TestInitialize] public override void TestInitialize() {
        //    base.TestInitialize();
        //    obj = Unit.Random();
        //}

        //[TestMethod] public void DivideTest() {
        //    Assert.AreEqual(Unit.Empty, Time.Seconds.Divide(null));
        //    Assert.AreEqual(Unit.Empty, Time.Seconds.Divide(Time.Seconds));
        //    Assert.AreEqual(Unit.Empty, Area.Acres.Divide(Area.Acres));
        //    Assert.AreEqual(Unit.Empty, Temperature.Rankine.Divide(Temperature.Rankine));
        //    Assert.AreEqual("°R^-1*m^3", Volume.CubicMeters.Divide(Temperature.Rankine).Formula());
        //}

        //[TestMethod] public void MultiplyTest() {
        //    Assert.AreEqual(Unit.Empty, Distance.Meters.Multiply(null));
        //    Assert.AreEqual(Area.SquareMeters, Distance.Meters.Multiply(Distance.Meters));
        //    Assert.AreEqual(Volume.CubicMeters, Distance.Meters.Multiply(Area.SquareMeters));
        //    Assert.AreEqual(Volume.CubicMeters, Area.SquareMeters.Multiply(Distance.Meters));
        //    Assert.AreEqual("m^5", Area.SquareMeters.Multiply(Volume.CubicMeters).Formula());
        //    var u1 = Area.SquareMeters.Multiply(Volume.CubicCentimeters);
        //    var u2 = Volume.CubicCentimeters.Multiply(Area.SquareMeters);
        //    Assert.AreEqual("cm^3*m^2", u1.Formula());
        //    Assert.AreEqual("cm^3*m^2", u2.Formula());
        //    var u3 = u2.Multiply(u1).Multiply(MassUNitsinitializer.Grams).Multiply(Temperature.Fahrenheit);
        //    Assert.AreEqual("°F*cm^6*g*m^4", u3.Formula());
        //}

        //[TestMethod] public void PowerTest() {
        //    Assert.AreEqual(Unit.Empty, Distance.Centimeters.Power(0));
        //    Assert.AreEqual(Distance.Centimeters, Distance.Centimeters.Power(1));
        //    Assert.AreEqual(Area.SquareCentimeters, Distance.Centimeters.Power(2));
        //    Assert.AreEqual(Volume.CubicCentimeters, Distance.Centimeters.Power(3));
        //    var power = GetRandom.UInt8(4);
        //    Assert.AreEqual($"cm^{power}", Distance.Centimeters.Power(power).Formula());
        //    Assert.AreEqual($"cm^-{power}", Distance.Centimeters.Power(-power).Formula());
        //    Assert.AreEqual($"cm^{3 * power}", Volume.CubicCentimeters.Power(power).Formula());
        //    Assert.AreEqual($"cm^-{3 * power}", Volume.CubicCentimeters.Power(-power).Formula());
        //    Assert.AreEqual($"°C^{power}", Temperature.Celsius.Power(power).Formula());
        //    Assert.AreEqual($"°C^-{power}", Temperature.Celsius.Power(-power).Formula());
        //}

        //[TestMethod] public void InverseTest() {
        //    Assert.AreEqual("m^-1", Distance.Meters.Inverse().Formula());
        //    Assert.AreEqual("cm^-1", Distance.Centimeters.Inverse().Formula());
        //    Assert.AreEqual("cm^-2", Area.SquareCentimeters.Inverse().Formula());
        //    Assert.AreEqual("cm^-3", Volume.CubicCentimeters.Inverse().Formula());
        //    Assert.AreEqual("dm^-3", Volume.Liters.Inverse().Formula());
        //    Assert.AreEqual("°C^-1", Temperature.Celsius.Inverse().Formula());
        //}

        //[TestMethod] public void FromBaseTest() {
        //    var i = CultureInfo.InvariantCulture;

        //    var u1 = Volume.CubicCentimeters.Multiply(MassUNitsinitializer.Grams);
        //    var u2 = Volume.CubicCentimeters.Divide(MassUNitsinitializer.Grams);
        //    var u3 = u1.Multiply(u2);
        //    var u4 = u1.Divide(u2);

        //    Assert.AreEqual(2000, Volume.CubicCentimeters.FromBase(0.002));
        //    Assert.AreEqual(3000, MassUNitsinitializer.Grams.FromBase(3));
        //    Assert.AreEqual(2000 * 3000, u1.FromBase(0.002 * 3));
        //    Assert.AreEqual((2000.0 / 3000).ToString(i), u2.FromBase(0.002 / 3).ToString(i));
        //    Assert.AreEqual((2000.0 * 2000).ToString(i), u3.FromBase(0.002 * 0.002).ToString(i));
        //    Assert.AreEqual((3000.0 * 3000).ToString(i), u4.FromBase(3 * 3).ToString(i));
        //}

        //[TestMethod] public void FromBaseWithUnitFunctionedTest() {

        //    var u1 = Volume.CubicMeters.Multiply(Temperature.Kelvin);
        //    var u2 = Volume.CubicCentimeters.Multiply(Temperature.Kelvin);
        //    var u3 = Volume.CubicMeters.Multiply(Temperature.Celsius);
        //    var u4 = Volume.CubicCentimeters.Multiply(Temperature.Celsius);
        //    var u5 = Volume.CubicCentimeters.Divide(Temperature.Celsius);
        //    Assert.AreEqual(-273.15, Temperature.Celsius.FromBase(0));
        //    Assert.AreEqual(1, u1.FromBase(1));
        //    Assert.AreEqual(5500000, u2.FromBase(5.5));
        //    Assert.AreEqual(1 - 273.15, u3.FromBase(1));
        //    Assert.AreEqual(5.5 * (1 - 273.15), u3.FromBase(5.5));
        //    Assert.AreEqual(5500000 * (1 - 273.15), u4.FromBase(5.5));
        //    Assert.AreEqual(5500000 / (1 - 273.15), u5.FromBase(5.5));
        //}

        //[TestMethod] public void IsEmptyTest() {
        //    Assert.IsTrue(Unit.Empty.IsEmpty());
        //    Assert.IsFalse(Unit.Random().IsEmpty());
        //}

        //[TestMethod] public void RandomTest() {
        //    var u1 = Unit.Random();
        //    var u2 = Unit.Random();
        //    Assert.AreNotEqual("", u1.ToString());
        //    Assert.AreNotEqual(u1.ToString(), u2.ToString());
        //}

        //[TestMethod] public void ToBaseTest() {
        //    var i = CultureInfo.InvariantCulture;

        //    var u1 = Volume.CubicCentimeters.Multiply(MassUNitsinitializer.Grams);
        //    var u2 = Volume.CubicCentimeters.Divide(MassUNitsinitializer.Grams);
        //    var u3 = u1.Multiply(u2);
        //    var u4 = u1.Divide(u2);

        //    Assert.AreEqual(0.002, Volume.CubicCentimeters.ToBase(2000));
        //    Assert.AreEqual(3, MassUNitsinitializer.Grams.ToBase(3000));
        //    Assert.AreEqual(0.002 * 3, u1.ToBase(2000 * 3000));
        //    Assert.AreEqual((0.002 / 3).ToString(i), u2.ToBase(2000.0 / 3000).ToString(i));
        //    Assert.AreEqual((0.002 * 0.002).ToString(i), u3.ToBase(2000.0 * 2000).ToString(i));
        //    Assert.AreEqual((3 * 3).ToString(i), u4.ToBase(3000.0 * 3000).ToString(i));
        //}

        //[TestMethod] public void ToBaseWithFunctionedUnitTest() {
        //    Assert.AreEqual(373.15, Temperature.Celsius.ToBase(100));
        //    Assert.AreEqual(274.15, Temperature.Celsius.ToBase(1));
        //    Assert.AreEqual(10273.15, Temperature.Celsius.ToBase(10000));
        //    Assert.AreEqual(10000.0 * 274.15 * 274.15,
        //        Temperature.Celsius.Multiply(Temperature.Celsius).ToBase(10000));
        //    Assert.AreEqual(10000.0 / 274.15 / 274.15,
        //        Temperature.Celsius.Inverse().Divide(Temperature.Celsius).ToBase(10000));
        //}

        //[TestMethod] public void EmptyTest() { testSingleton(() => Unit.Empty); }

        //[TestMethod] public void GetMeasureTest() {
        //    var m1 = Measure.Random();
        //    var m2 = Measure.Random();
        //    Measures.Instance.Add(m2);
        //    obj.Measure = m1.Name;
        //    Assert.AreEqual(Measure.Empty, obj.GetMeasure());
        //    Measures.Instance.Add(m1);
        //    Assert.AreEqual(m1, obj.GetMeasure());
        //}

        //[TestMethod] public void GetSystemOfUnitsTest() {
        //    var s1 = SystemOfUnits.Random();
        //    var s2 = SystemOfUnits.Random();
        //    obj.SystemOfUnits = s1.Name;
        //    SystemsOfUnits.Instance.Add(s2);
        //    Assert.AreEqual(SystemOfUnits.Empty, obj.GetSystemOfUnits);
        //    SystemsOfUnits.Instance.Add(s1);
        //    Assert.AreEqual(s1, obj.GetSystemOfUnits);
        //}

        //[TestMethod] public void MeasureTest() {
        //    testProperty(() => obj.Measure, x => obj.Measure = x);
        //}

        //[TestMethod] public void SystemOfUnitsTest() {
        //    testProperty(() => obj.SystemOfUnits, x => obj.SystemOfUnits = x);
        //}

    }
}
