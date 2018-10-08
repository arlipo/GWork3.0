using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;
namespace Open.Tests.Domain {
    public abstract class ListBaseTests<TObject, TElement> : ObjectTests<TObject> {
        protected TObject createWithNullArgs;
        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(createWithNullArgs);
        }
        [TestMethod] public void IsPaginatedListTest() {
            Assert.IsInstanceOfType(obj, typeof(PaginatedList<TElement>));
        }
    }
}


