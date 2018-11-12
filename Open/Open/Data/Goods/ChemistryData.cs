namespace Open.Data.Goods
{
    public class ChemistryData: GoodsData {
        private string volume;

        public string Volume {
            get => getString(ref volume);
            set => volume = value;
        }
    }
}
