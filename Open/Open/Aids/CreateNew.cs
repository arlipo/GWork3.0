using System;
using System.Collections.Generic;
using System.Reflection;
namespace Open.Aids {


    public static class CreateNew {
        public static T Instance<T>() {
            T function() {
                var type = typeof(T);
                var instance = Instance(type);
                var value = (T) instance;
                return value;
            }
            var def = default(T);
            var result = Safe.Run(function, def);
            return result;
        }
        public static object Instance(Type t) {
            return Safe.Run(() => {
                var constructor = getFirstOrDefaultConstructorInfo(t);
                var parameters = constructor.GetParameters();
                var values = setRandomParameterValues(parameters);
                return invokeConstructor(constructor, values);
            }, null);
        }
        private static object invokeConstructor(ConstructorInfo ci, object[] values) {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }
        private static object[] setRandomParameterValues(ParameterInfo[] parameters) {
            var values = new List<object>();
            foreach (var p in parameters) {
                var t = p.ParameterType;
                var value = GetRandom.Value(t);
                values.Add(value);
            }
            return values.ToArray();
        }
        private static ConstructorInfo getFirstOrDefaultConstructorInfo(Type t) {
            var constructors = t.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}



