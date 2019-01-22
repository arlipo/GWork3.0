using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
using Open.Data.ShoppingCart;
using Open.Domain.ShoppingCart;

namespace Open.Tests.Domain.ShoppingCart
{
    [TestClass]
    public class CartTests : ObjectTests<Cart>
    {
        [TestMethod]
        public void AddItemTest()
        {
            obj.RemoveAllItems();
            var r = GetRandom.Object<CartData>();
            r.Quantity = 1;
            obj.AddItem(r);
            obj.AddItem(r);
            Assert.IsTrue(obj.Count == 1);
            Assert.IsTrue(obj[0].Data.Quantity == 2);
            Assert.IsTrue(obj[0].Data == r);

            do { r = GetRandom.Object<CartData>(); r.Quantity = 1;} 
            while (obj.Contains(new CartItem(r)));
            obj.AddItem(r);
            Assert.IsTrue(obj.Count == 2);
            Assert.IsTrue(obj[1].Data.Quantity == 1);
            Assert.IsTrue(obj[1].Data == r);
        }

        [TestMethod]
        public void RemoveItemTest()
        {
            obj[0].Data.Quantity = 1;
            var d = obj[0].Data;
            obj.RemoveItem(d);
            Assert.IsFalse(obj.Contains(new CartItem(d)));

            obj[0].Data.Quantity = 2;
            d = obj[0].Data;
            obj.RemoveItem(d);
            Assert.IsTrue(obj.Any(x => x.Data.ID == d.ID));
            Assert.IsTrue(obj[0].Data.Quantity == 1);
        }

        [TestMethod]
        public void GetSubTotalTest()
        {
            obj.RemoveAllItems();
            var listOfObj = new List<CartData>
            {
                GetRandom.Object<CartData>(),
                GetRandom.Object<CartData>(),
                GetRandom.Object<CartData>()
            };
            var listOfPrices = new List<decimal>
            {
                GetRandom.Decimal(0, 100),
                GetRandom.Decimal(0, 100),
                GetRandom.Decimal(0, 100)
            };
            var listOfQuantities = new List<int>
            {
                GetRandom.UInt8(),
                GetRandom.UInt8(),
                GetRandom.UInt8()
            };
            decimal result = 0;
            for (var i = 0; i < 3; i++)
            {
                listOfObj[i].GoodsData.Price = listOfPrices[i].ToString();
                listOfObj[i].Quantity = listOfQuantities[i];
                obj.Add(new CartItem(listOfObj[i]));
                result += listOfPrices[i] * listOfQuantities[i];
            }
            Assert.AreEqual(result, obj.GetSubTotal());
        }

        [TestMethod]
        public void GetCartItemByIDTest()
        {
            var o = GetRandom.Object<CartItem>();
            obj.Add(o);
            var actual = obj.GetCartItemByID(o.Data.ID);
            Assert.AreEqual(o, actual);
        }

        [TestMethod]
        public void RemoveAllItemsTest()
        {
            Assert.IsTrue(obj.Count != 0);
            obj.RemoveAllItems();
            Assert.IsTrue(obj.Count == 0);
        }
    }
}