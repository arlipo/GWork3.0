//
//
//    (c) Gunnar Piho
//
///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace Open.Aids {
    public static class GetClass {
        private const string g = "get_";
        private const string s = "set_";
        private const string a = "add_";
        private const string r = "remove_";
        private const string c = ".ctor";
        private const string v = "value__";
        private const string t = "+TestClass";
        public static string Namespace(Type type) {
            return type is null ? string.Empty : type.Namespace;
        }
        public static List<MemberInfo> Members(Type type,
            BindingFlags f = PublicBindingFlagsFor.AllMembers,
            bool clean = true) {
            if (type is null) return new List<MemberInfo>();
            var l = type.GetMembers(f).ToList();
            if (clean) removeSurrogates(l);
            return l;
        }
        public static List<PropertyInfo> Properties(Type type,
            BindingFlags f = PublicBindingFlagsFor.AllMembers) {
            return type?.GetProperties(f).ToList() ?? new List<PropertyInfo>();
        }
        public static PropertyInfo Property<T>(string name) {
            return Safe.Run(() => typeof(T).GetProperty(name), null);
        }
        private static void removeSurrogates(IList<MemberInfo> l) {
            for (var i = l.Count; i > 0; i--) {
                var m = l[i - 1];
                if (!isSurrogate(m)) continue;
                l.RemoveAt(i - 1);
            }
        }
        private static bool isSurrogate(MemberInfo m) {
            var n = m.Name;
            if (string.IsNullOrEmpty(n)) return false;
            if (n.Contains(g)) return true;
            if (n.Contains(s)) return true;
            if (n.Contains(a)) return true;
            if (n.Contains(r)) return true;
            if (n.Contains(v)) return true;
            return n.Contains(t) || n.Contains(c);
        }
        public static List<object> ReadWritePropertyValues(object obj) {
            var l = new List<object>();
            if (obj is null) return l;
            foreach (var p in Properties(obj.GetType())) {
                if (!p.CanWrite) continue;
                addValue(p, obj, l);
            }
            return l;
        }
        private static void addValue(PropertyInfo p, object o, List<object> l) {
            var indexer = p.GetIndexParameters();
            if (indexer.Length == 0 ) l.Add(p.GetValue(o));
            else {
                var i = 0;
                while (true) {
                    try {
                        l.Add(p.GetValue(o, new object[] {i++}));
                    }
                    catch {
                        l.Add(i);
                        return;
                    }
                }
            }
        }
    }
}





