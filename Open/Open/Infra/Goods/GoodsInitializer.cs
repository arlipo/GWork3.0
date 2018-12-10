using System;
using System.Linq;
using Open.Aids;
using Open.Core;
using Open.Data.Goods;
namespace Open.Infra.Goods {
    public static class GoodsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            initializeGoods(c);
            c.SaveChanges();

        }
        private static void initializeGoods(SentryDbContext c)
        {
            add(c, new GoodsData()
            {
                Name = "Antifreeze + coolant LONG LIFE",
                Code = GetRandom.Code(),
                Type = GoodTypes.Chemistry,
                Description =
                    "Organic Acid Technology (OAT) coolant technology that is compatible" +
                    " for use in all automobiles and light-duty trucks, regardless of make, " +
                    "model, year or original antifreeze color.",
                Price = "8.99",
                Quantity = 10
            });
            add(c, new GoodsData
            {
                Name = "RIDEX Brake Disc Rear Axle",
                Code = GetRandom.Code(),
                Description = "TopBrakes supplies and manufactures aftermarket " +
                              "brake components for domestics and import vehicles. " +
                              "All of our performance brake products features O.E." +
                              " (Original Equipment) specifications and are manufactured " +
                              "for direct replacement.",
                Type = GoodTypes.SpareParts,
                Price = "14.99",
                Quantity = 9
            });
            add(c, new GoodsData
            {
                Name = "EXTREME Mobile phone holders",
                Code = GetRandom.Code(),
                Description =
                    "Universal Phone Holder The Silicone mount holds your device in a" +
                    " secure position anywhere Can be used on any surface Leaves no " +
                    "residue Cable management access ports for charging your device USB " +
                    "charging cable not included.",
                Type = GoodTypes.Accessories,
                Price = "6.99",
                Quantity = 12
            });
            add(c, new GoodsData
            {
                Name = "3 Button Remote Key",
                Code = GetRandom.Code(),
                Description = "AUDI 3 button remote key fob case FULL service repair kit.",
                Type = GoodTypes.SpareParts,
                Price = "9.99",
                Quantity = 8
            });
            add(c, new GoodsData
            {
                Name = "36CM UNIVERSAL CAR AUTO SAFETY SEAT BELT",
                Code = GetRandom.Code(),
                Description =
                    "Increases the size and improves comfort of your existing seat belt." +
                    "It is a perfect accessory for your safety, comfort and" +
                    " ideal for use with baby and infant car seats.",
                Type = GoodTypes.Accessories,
                ID = "5",
                Price = "7.99",
                Quantity = 7
            });
            add(c, new GoodsData
            {
                Name = "GENUINE BLACK LEATHER CAR/VAN STEERING WHEEL COVER GLOVE",
                Code = GetRandom.Code(),
                Description =
                    "Black Leather Steering Wheel Cover. Genuine leather. Suitable for" +
                    " steering wheels with an exterior diameter of 37 - 39cm.Simply stretches over the existing steering wheel",
                Type = GoodTypes.Accessories,
                Price = "9.99",
                Quantity = 2
            });
            add(c, new GoodsData
            {
                Name = "5 Bar Checker Patterned Rubber Flooring Matting",
                Code = GetRandom.Code(),
                Description =
                    "Natural rubber matting provides years of trouble-free service. Our matting provides excellent insulation" +
                    " from the cold. ",
                Type = GoodTypes.Accessories,
                Price = "15,99",
                Quantity= 4
           
            });
            add(c, new GoodsData
            {
                Name = "Cup Holder",
                Code = GetRandom.Code(),
                Description =
                    "This cup/can holder has a designated space for cans/cups anda space for coins and other small items.",
                Type = GoodTypes.Accessories,
                Price = "10.99",
                Quantity = 3
            });

            add(c, new GoodsData
            {
                Name = "'Chemical Guys' Premium Air Freshener",
                Code = GetRandom.Code(),
                Description = "Premium air freshener formulated with unique fragrances " +
                              "engineered to smell just like a new car.\r\n" +
                              "One spray is all you need for a full size vehicle",
                Type= GoodTypes.Chemistry,
                Price = "9.99",
                Quantity = 2
            });
            add(c, new GoodsData
            {
                Name = "Engine Oil TOTAL QUARTZ 9000 ",
                Code = GetRandom.Code(),
                Description = "Suitable For: BMW\r\nSuitable For: Citroen\r\nSuitable For: Fiat\r\nSuitable For: Mercedes-Benz\r\nSuitable For: Peugeot\r\n" +
                              "Suitable For: Porsche\r\nSuitable For: Renault\r\nSuitable For: Seat\r\nSuitable For: Skoda\r\nSuitable For: Vauxhall / Opel\r\n" +
                              "Suitable For: Volkswagen",
                Type = GoodTypes.Chemistry,
                Price = "14.49",
                Quantity =3
            });
            add(c, new GoodsData()
            {
                Name = "Mobil Super Motor Oil 5L",
                Code = GetRandom.Code(),
                Description = "Mobil Super 3000 X1 Formula FE 5W-30 is a high performance" +
                              " motor oil designed for use in petrol and diesel engines that " +
                              "are specifically designed to use a low viscosity (HTHS) motor oil. ",
                Type = GoodTypes.Chemistry,
                Price = "20.49",
                Quantity = 1
            });
            add(c, new GoodsData()
            {
                Name = "Power Steering Fluid for Honda",
                Code = GetRandom.Code(),
                Description = " This listing is for a set of two power steering pump " +
                              "o-rings and one bottle of Honda Genuine power steering fluid.",
                Type = GoodTypes.Chemistry,
                Price = "23.49",
                Quantity =4
            });
            add(c, new GoodsData()
            {
                Name = "Genuine Ford Antifreeze",
                Code = GetRandom.Code(),
                Description = "Genuine Ford Antifreeze Antifreeze Super plus Premium 4 Liter",
                Type = GoodTypes.Chemistry,
                Price = "10.99",
                Quantity = 4
            });
            add(c, new GoodsData()
            {
                Name = "Genuine Wurth Brake Cleaner Plus Aerosol",
                Code = GetRandom.Code(),
                Description = "Suitable for brake cleaner and other de-greaser products, Motorcycle Motorbike",
                Type = GoodTypes.Chemistry,
                Price = "7.49",
                Quantity = 5
            });
            add(c, new GoodsData()
            {
                Name = "Red Penguin Auto Shampoo",
                Code = GetRandom.Code(),
                Description = "Removes gently and effectively all kinds of dirt on the body (dirt, dust, oil, salt - and insect remains, poplar buds and leaves tree secretions.",
                Type = GoodTypes.Chemistry,
                Price = "20.99",
                Quantity =5
            });
            add(c, new GoodsData()
            {
                Name = "Kim Tec Auto Shampoo and Wax",
                Code = GetRandom.Code(),
                Description = "KIM TEC car shampoo + wax is a two in one -" +
                              " product in a concentrated form.\r\nThrough regular use, " +
                              "the vehicle is intensely cleaned surface and brought to shine over the waxes contained in the product. ",
                Type = GoodTypes.Chemistry,
                Price = "20.99",
                Quantity = 3
            });
        }
        private static void add(SentryDbContext c, GoodsData goods) {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
        }
    }
}