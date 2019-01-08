
namespace Open.Aids {
    public static class RegularExpressionFor {
        public const string EnglishCapitalsOnly = @"^[A-Z]+[A-Z]*$";
        public const string EnglishTextOnly = @"^[A-Z]+[a-z]*$";
        public const string NumericOnly = @"^\d+$";
        public const string Price = @"^(?!0*\.0+$)\d*(?:\.\d+)?$";
    }
}

