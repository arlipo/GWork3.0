using System;
using System.Linq;
using Open.Core;
using Open.Data.Goods;
namespace Open.Infra.Goods {
    public static class GoodsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            goodsList(c);
            c.SaveChanges();

        }
        private static void goodsList(SentryDbContext c)
        {
            add(c, new ChemistryData
            {
                Name = "Antifreeze + coolant LONG LIFE",
                Code = "12345",
                Type = GoodTypes.Chemistry,
                Description =
                    "Organic Acid Technology (OAT) coolant technology that is compatible" +
                    " for use in all automobiles and light-duty trucks, regardless of make, " +
                    "model, year or original antifreeze color.",
                Volume = "2l",
                Price = "8,99"
            });
            add(c, new SparePartsData
            {
                Name = "RIDEX Brake Disc Rear Axle",
                Code = "123",
                Description = "TopBrakes supplies and manufactures aftermarket " +
                              "brake components for domestics and import vehicles. " +
                              "All of our performance brake products features O.E." +
                              " (Original Equipment) specifications and are manufactured " +
                              "for direct replacement.",
                Type = GoodTypes.SpareParts,
                Price = "14,99"
            });
            add(c, new AccessoriesData
            {
                Name = "EXTREME Mobile phone holders",
                Code = "1234",
                Description =
                    "Universal Phone Holder The Silicone mount holds your device in a" +
                    " secure position anywhere Can be used on any surface Leaves no " +
                    "residue Cable management access ports for charging your device USB " +
                    "charging cable not included.",
                Type = GoodTypes.Accessories,
                Price = "6,99"
            });
            add(c, new SparePartsData
            {
                Name = "3 Button Remote Key",
                Code = "543",
                Description = "AUDI 3 button remote key fob case FULL service repair kit.",
                Type = GoodTypes.SpareParts,
                Price = "9,99"
            });
            add(c, new AccessoriesData
            {
                Name = "36CM UNIVERSAL CAR AUTO SAFETY SEAT BELT",
                Code = "54321",
                Description =
                    "Increases the size and improves comfort of your existing seat belt." +
                    "It is a perfect accessory for your safety, comfort and" +
                    " ideal for use with baby and infant car seats.",
                Type = GoodTypes.Accessories,
                ID = "5",
                Price = "7,99"
            });
            add(c, new AccessoriesData
            {
                Name = "GENUINE BLACK LEATHER CAR/VAN STEERING WHEEL COVER GLOVE",
                Code = "999",
                Description =
                    "Black Leather Steering Wheel Cover. Genuine leather. Suitable for" +
                    " steering wheels with an exterior diameter of 37 - 39cm.Simply stretches over the existing steering wheel",
                Type = GoodTypes.Accessories,
                Price = "9,99"
            });
            add(c, new AccessoriesData
            {
                Name = "5 Bar Checker Patterned Rubber Flooring Matting",
                Code = "987",
                Description =
                    "Natural rubber matting provides years of trouble-free service. Our matting provides excellent insulation" +
                    " from the cold. ",
                Type = GoodTypes.Accessories,
                Price = "15,99"
            });
            add(c, new AccessoriesData()
            {
                Name = "Cup Holder",
                Code = "98765",
                Description =
                    "This cup/can holder has a designated space for cans/cups anda space for coins and other small items.",
                Type = GoodTypes.Accessories,
                Price = "10,99"
            });

            add(c, new ChemistryData()
            {
                Name = "Antifreeze",
                Code = "98765",
                Type = GoodTypes.Chemistry,
                Volume = "3l",
                Price = "19,99"
            });

        }
        private static void add(SentryDbContext c, GoodsData goods) {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
        }
    }
}