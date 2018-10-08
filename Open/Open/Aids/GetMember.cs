using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
namespace Open.Aids {
    public class GetMember {
        public static string Name<T>(Expression<Func<T, object>> ex) {
            return Safe.Run(()=>name(ex.Body), string.Empty);
        }
        public static string Name<T, TResult>(Expression<Func<T, TResult>> ex)
        {
            return Safe.Run(() => name(ex.Body), string.Empty);
        }

        public static string Name<T>(Expression<Action<T>> ex) {
            return Safe.Run(() => name(ex.Body), string.Empty);
        }
        public static string DisplayName<T>(Expression<Func<T, object>> ex) {
            return Safe.Run(() => {
                var name = Name(ex);
                var p = GetClass.Property<T>(name);
                var list = p?.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (list is null || list.Length < 1) return name;
                var a = list.Cast<DisplayNameAttribute>().Single();
                return a?.DisplayName ?? name;
            }, string.Empty);
        }

        private static string name(Expression ex) {
            var member = ex as MemberExpression;
            var method = ex as MethodCallExpression;
            var operand = ex as UnaryExpression;
            if (!(member is null)) return name(member);
            if (!(method is null)) return name(method);
            if (!(operand is null)) return name(operand);
            return string.Empty;
        }

        private static string name(MemberExpression ex) { return ex?.Member.Name ?? string.Empty; }

        private static string name(MethodCallExpression ex) {
            return ex?.Method.Name ?? string.Empty;
        }
        private static string name(UnaryExpression ex) {
            var member = ex?.Operand as MemberExpression;
            var method = ex?.Operand as MethodCallExpression;
            if (!(member is null)) return name(member);
            if (!(method is null)) return name(method);
            return string.Empty;
        }
    }
}




