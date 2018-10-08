
namespace Open.Core {
    public interface ITerm {

        int Power { get; }

        string Formula(bool longFormula = false);
    }
}
