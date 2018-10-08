using System.Reflection;
namespace Open.Aids {

    public static class PublicBindingFlagsFor {
        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        public const BindingFlags AllMembers = p | i | s;
        public const BindingFlags InstanceMembers = p | i;
        public const BindingFlags StaticMembers = p | s;
        public const BindingFlags DeclaredMembers = p | d | i | s;
    }

}




