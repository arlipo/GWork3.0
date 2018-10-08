using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests {

    public class AssemblyTests {
        private static string isNotTested => "<{0}> is not tested";
        private static string noClassesInAssembly =>
            "No classes found in assembly {0}";
        private static string noClassesInNamespace =>
            "No classes found in namespace {0}";
        private static string testAssembly => "Open.Tests";
        private static string assembly => "Open";
        private static char genericsChar => '`';
        private static char internalClass => '+';
        private static string displayClass => "<>";
        private static string shell32 => "Shell32.";
        private List<string> list;

        [TestInitialize] public void CreateList() { list = new List<string>(); }

        protected virtual string Namespace(string name) {
            return $"{assembly}.{name}";
        }

        protected void isAllTested(string assemblyName,
            string namesapecName = null) {
            var l = getAssemblyClasses(assemblyName);
            removeInterfacs(l);
            list = toClassNamesList(l);
            removeNotInNamespace(namesapecName);
            removeSurrogateClasses();
            removeTested();
            if (list.Count == 0) return;

            report(isNotTested, list[0]);
        }

        private static void report(string message, params object[] parameters) {
            Assert.Fail(message, parameters);
        }

        private static List<Type> getAssemblyClasses(string assemblyName) {
            var l = GetSolution.TypesForAssembly(assemblyName);
            if (l.Count == 0) report(noClassesInAssembly, assemblyName);
            return l;
        }

        private static void removeInterfacs(IList<Type> types) {
            for (var i = types.Count; i > 0; i--) {
                var e = types[i - 1];
                if (!e.IsInterface) continue;

                types.Remove(e);
            }
        }

        private static List<string> toClassNamesList(List<Type> l) {
            return l.Select(o => o.FullName).ToList();
        }

        private void removeNotInNamespace(string namespaceName) {
            if (string.IsNullOrEmpty(namespaceName)) return;

            list.RemoveAll(o => !o.StartsWith(namespaceName));
            if (list.Count > 0) return;

            report(noClassesInNamespace, namespaceName);
        }

        private void removeSurrogateClasses() {
            list.RemoveAll(o => o.Contains(shell32));
            list.RemoveAll(o => o.Contains(internalClass));
            list.RemoveAll(o => o.Contains(displayClass));
            list.RemoveAll(o => o.Contains("<"));
            list.RemoveAll(o => o.Contains(">"));
            list.RemoveAll(o => o.Contains("Migrations"));
        }

        private void removeTested() {
            var tests = getTestClasses();
            for (var i = list.Count; i > 0; i--) {
                var className = list[i - 1];
                var testName = toTestName(className);
                var t = tests.Find(o => o.EndsWith(testName));
                if (ReferenceEquals(null, t)) continue;

                list.RemoveAt(i - 1);
            }
        }
        private List<string> getTestClasses() {
            var l = new List<string>();
            var tests = GetSolution.TypeNamesForAssembly(testAssembly);
            foreach (var t in tests) {
                var n = removeGenericsChars(t);
                l.Add(n);
            }
            return l;
        }
        private static string toTestName(string className) {
            className = removeAssemblyName(className);
            className = removeGenericsChars(className);
            return className + "Tests";
        }

        private static string removeGenericsChars(string className) {
            var idx = className.IndexOf(genericsChar);
            if (idx > 0) className = className.Substring(0, idx);
            return className;
        }

        private static string removeAssemblyName(string className) {
            return className.Substring(assembly.Length);
        }
    }

}
