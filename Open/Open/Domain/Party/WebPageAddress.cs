using Open.Data.Party;
namespace Open.Domain.Party {
    public sealed class WebPageAddress : Address<WebPageAddressData> {
        public WebPageAddress(WebPageAddressData r) : base(r ?? new WebPageAddressData()) { }
    }

}



