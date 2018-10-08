namespace Open.Data.Common {
    public abstract class NamedData : IdentifiedData {
        private string code;
        private string name;

        public string Code {
            get => getString(ref code);
            set => setValue(ref code, value);
        }

        public string Name {
            get => getString(ref name, Code);
            set => setValue(ref name, value);
        }

        public override string ID {
            get => getString(ref id, Name);
            set => setValue(ref id, value);
        }
    }
}


