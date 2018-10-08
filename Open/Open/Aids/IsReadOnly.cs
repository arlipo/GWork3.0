namespace Open.Aids {
    public static class IsReadOnly {
        public static bool Field<T>(string name) {
            return typeof(T).GetField(name)?.IsInitOnly ?? false;
        }
        public static bool Property<T>(string name) {
            return !typeof(T).GetProperty(name)?.CanWrite ?? false;
        }
    }
}


