

namespace Open.Aids {

    public static class SystemString {

        public static bool StartsWithLetter(string s) {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return char.IsLetter(s[0]);
        }

        public static string ToBackwards(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var x = s.Length - 1;
            var r = string.Empty;
            for (var i = x; i >= 0; i--) r += s[i];

            return r;
        }

    }

}












