using System;
using System.IO;
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
        private static void initializeGoods(SentryDbContext c) {
            add(c, new GoodsData() {
                Name = "Antifreeze + coolant LONG LIFE",
                Code = GetRandom.Code(),
                Type = GoodTypes.Chemistry,
                Description =
                    "Organic Acid Technology (OAT) coolant technology that is compatible" +
                    " for use in all automobiles and light-duty trucks, regardless of make, " +
                    "model, year or original antifreeze color.",
                Price = "8.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\1.jpg")
            });
            add(c, new GoodsData {
                Name = "RIDEX Brake Disc Rear Axle",
                Code = GetRandom.Code(),
                Description = "TopBrakes supplies and manufactures aftermarket " +
                              "brake components for domestics and import vehicles. " +
                              "All of our performance brake products features O.E." +
                              " (Original Equipment) specifications and are manufactured " +
                              "for direct replacement.",
                Type = GoodTypes.SpareParts,
                Price = "14.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\2.jpg")

            });
            add(c, new GoodsData {
                Name = "EXTREME Mobile phone holders",
                Code = GetRandom.Code(),
                Description =
                    "Universal Phone Holder The Silicone mount holds your device in a" +
                    " secure position anywhere Can be used on any surface Leaves no " +
                    "residue Cable management access ports for charging your device USB " +
                    "charging cable not included.",
                Type = GoodTypes.Accessories,
                Price = "6.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\3.jpg")
            });
            add(c, new GoodsData {
                Name = "3 Button Remote Key",
                Code = GetRandom.Code(),
                Description = "AUDI 3 button remote key fob case FULL service repair kit.",
                Type = GoodTypes.SpareParts,
                Price = "9.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\4.jpg")

            });
            add(c, new GoodsData {
                Name = "36CM UNIVERSAL CAR AUTO SAFETY SEAT BELT",
                Code = GetRandom.Code(),
                Description =
                    "Increases the size and improves comfort of your existing seat belt." +
                    "It is a perfect accessory for your safety, comfort and" +
                    " ideal for use with baby and infant car seats.",
                Type = GoodTypes.Accessories,
                ID = "5",
                Price = "7.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\5.jpg")
            });
            add(c, new GoodsData {
                Name = "GENUINE BLACK LEATHER CAR/VAN STEERING WHEEL COVER GLOVE",
                Code = GetRandom.Code(),
                Description =
                    "Black Leather Steering Wheel Cover. Genuine leather. Suitable for" +
                    " steering wheels with an exterior diameter of 37 - 39cm.Simply stretches over the existing steering wheel",
                Type = GoodTypes.Accessories,
                Price = "9.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\6.jpg")
            });
            add(c, new GoodsData {
                Name = "5 Bar Checker Patterned Rubber Flooring Matting",
                Code = GetRandom.Code(),
                Description =
                    "Natural rubber matting provides years of trouble-free service. Our matting provides excellent insulation" +
                    " from the cold. ",
                Type = GoodTypes.Accessories,
                Price = "15.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\7.jpg")

            });
            add(c, new GoodsData {
                Name = "Cup Holder",
                Code = GetRandom.Code(),
                Description =
                    "This cup/can holder has a designated space for cans/cups anda space for coins and other small items.",
                Type = GoodTypes.Accessories,
                Price = "10.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\8.jpg")
            });

            add(c, new GoodsData {
                Name = "'Chemical Guys' Premium Air Freshener",
                Code = GetRandom.Code(),
                Description = "Premium air freshener formulated with unique fragrances " +
                              "engineered to smell just like a new car.\r\n" +
                              "One spray is all you need for a full size vehicle",
                Type = GoodTypes.Chemistry,
                Price = "9.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\9.jpg")
            });
            add(c, new GoodsData {
                Name = "Engine Oil TOTAL QUARTZ 9000 ",
                Code = GetRandom.Code(),
                Description =
                    "Suitable For: BMW\r\nSuitable For: Citroen\r\nSuitable For: Fiat\r\nSuitable For: Mercedes-Benz\r\nSuitable For: Peugeot\r\n" +
                    "Suitable For: Porsche\r\nSuitable For: Renault\r\nSuitable For: Seat\r\nSuitable For: Skoda\r\nSuitable For: Vauxhall / Opel\r\n" +
                    "Suitable For: Volkswagen",
                Type = GoodTypes.Chemistry,
                Price = "14.49",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\10.jpg")
            });
            add(c, new GoodsData() {
                Name = "Mobil Super Motor Oil 5L",
                Code = GetRandom.Code(),
                Description = "Mobil Super 3000 X1 Formula FE 5W-30 is a high performance" +
                              " motor oil designed for use in petrol and diesel engines that " +
                              "are specifically designed to use a low viscosity (HTHS) motor oil. ",
                Type = GoodTypes.Chemistry,
                Price = "20.49",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\11.jpg")
            });
            add(c, new GoodsData() {
                Name = "Power Steering Fluid for Honda",
                Code = GetRandom.Code(),
                Description = " This listing is for a set of two power steering pump " +
                              "o-rings and one bottle of Honda Genuine power steering fluid.",
                Type = GoodTypes.Chemistry,
                Price = "23.49",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\12.jpg")
            });
            add(c, new GoodsData() {
                Name = "Genuine Ford Antifreeze",
                Code = GetRandom.Code(),
                Description = "Genuine Ford Antifreeze Antifreeze Super plus Premium 4 Liter",
                Type = GoodTypes.Chemistry,
                Price = "10.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\13.jpg")
            });
            add(c, new GoodsData() {
                Name = "Genuine Wurth Brake Cleaner Plus Aerosol",
                Code = GetRandom.Code(),
                Description =
                    "Suitable for brake cleaner and other de-greaser products, Motorcycle Motorbike",
                Type = GoodTypes.Chemistry,
                Price = "7.49",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\14.jpg")
            });
            add(c, new GoodsData() {
                Name = "Red Penguin Auto Shampoo",
                Code = GetRandom.Code(),
                Description =
                    "Removes gently and effectively all kinds of dirt on the body (dirt, dust, oil, salt - and insect remains, poplar buds and leaves tree secretions.",
                Type = GoodTypes.Chemistry,
                Price = "20.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\15.jpg")
            });
            add(c, new GoodsData() {
                Name = "Kim Tec Auto Shampoo and Wax",
                Code = GetRandom.Code(),
                Description = "KIM TEC car shampoo + wax is a two in one -" +
                              " product in a concentrated form.\r\nThrough regular use, " +
                              "the vehicle is intensely cleaned surface and brought to shine over the waxes contained in the product. ",
                Type = GoodTypes.Chemistry,
                Price = "20.99",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\16.jpg")
            });
            add(c, new GoodsData {
                Name = "TEMPERATURE SWITCH, AIR CONDITIONING FAN",
                Code = GetRandom.Code(),
                Description = "Temperature switch, Weight [kg] - 0,010, 2 connectors",
                Type = GoodTypes.SpareParts,
                Price = "6.80",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\17.jpg")
            });
            add(c, new GoodsData {
                Name = "BRAKE PEDAL PAD; CLUTCH PEDAL PAD",
                Code = GetRandom.Code(),
                Description = "Brake pedal, Weight [kg] - 0,06",
                Type = GoodTypes.SpareParts,
                Price = "4",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\18.jpg")
            });
            add(c, new GoodsData {
                Name = "SAFETY BELT",
                Code = GetRandom.Code(),
                Description =
                    "A seat belt is a vehicle safety device designed to secure the occupant" +
                    " of a vehicle against harmful movement that may result during a collision or" +
                    " a sudden stop.",
                Type = GoodTypes.SpareParts,
                Price = "3.6",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\19.jpg")
            });
            add(c, new GoodsData {
                Name = "Timing Belt Set Teeth Quant.: 127 FEBI ",
                Code = GetRandom.Code(),
                Type = GoodTypes.SpareParts,
                Price = "10.9",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\20.jpg")
            });
            add(c, new GoodsData {
                Name = "Motorad MGC-837 Fuel Cap",
                Code = GetRandom.Code(),
                Description = "Passes all state and federal emissions tests\r\nManufactured" +
                              " from durable, long-life materials\r\nReduces air pollution with proper" +
                              " sealing and venting",
                Type = GoodTypes.SpareParts,
                Price = "7.49",
                ImgData = File.ReadAllBytes(@"C:\Users\Porokhnya\source\repos\GWork3.0\Open\Open\Sentry\wwwroot\images\Parts\21.jpg")
            });
        }
        private static void add(SentryDbContext c, GoodsData goods) {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
        }
    }
}