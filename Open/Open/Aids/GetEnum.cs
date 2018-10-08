




using System;
namespace Open.Aids {

    public static class GetEnum {
        public static int Count<T>() {
            return Count(typeof(T));
        }

        public static T Value<T>(int i) {
            return Safe.Run(() => (T) Value(typeof(T), i), default(T));
        }

        public static int Count(Type type) {
            return Safe.Run(() => Enum.GetValues(type).Length, -1);
        }

        public static object Value(Type type, int i) {
            return Safe.Run(() => {
                var v = Enum.GetValues(type);
                return v.GetValue(i);
            }, null);
        }
    }
}



