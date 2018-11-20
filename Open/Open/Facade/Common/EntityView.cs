namespace Open.Facade.Common
{
    public class EntityView : PeriodView
    {
        private string id;
        public string ID {
            get => getString(ref id);
            set => id = value;
        }
    }
}

