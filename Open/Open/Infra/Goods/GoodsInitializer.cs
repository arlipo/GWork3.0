using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Goods;
using Open.Domain.Goods;
namespace Open.Infra.Goods {
    public static class GoodsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            goodsList(c);
            gGoodsList(c);
            c.SaveChanges();
        }
        private static void gGoodsList(SentryDbContext c) {
            GoodsData data = new GoodsData{Code = "23123", Description = "HUY", FileLocation = "Doma", ID = "10"};
            var e = GoodFactory.Create(data);
            c.Goods.Add(e.Data);
        }
        private static List<string> goodsList(SentryDbContext c) {
            var l = new List<string> {
                add(c, new GoodsData {
                    Name = "Antifreeze + coolant LONG LIFE",
                    Code = "12345",
                    Description =
                        "Organic Acid Technology (OAT) coolant technology that is compatible" +
                        " for use in all automobiles and light-duty trucks, regardless of make, " +
                        "model, year or original antifreeze color.",
                    FileLocation = "hz",
                    ID = "3",
                    ImageType = "png",
                    Price = "8,99"
                }),
                add(c, new GoodsData{
                    Name = "RIDEX Brake Disc Rear Axle",
                    Code = "123",
                    Description = "TopBrakes supplies and manufactures aftermarket " +
                                  "brake components for domestics and import vehicles. " +
                                  "All of our performance brake products features O.E." +
                                  " (Original Equipment) specifications and are manufactured " +
                                  "for direct replacement.",
                    FileLocation = "zh",
                    ID = "2",
                    ImageType = "png",
                    Price = "14,99"
                }),
                add(c, new GoodsData{
                    Name = "EXTREME Mobile phone holders",
                    Code = "1234",
                    Description = "Universal Phone Holder The Silicone mount holds your device in a" +
                                  " secure position anywhere Can be used on any surface Leaves no " +
                                  "residue Cable management access ports for charging your device USB " +
                                  "charging cable not included.",
                    FileLocation = "tut",
                    ID = "3",
                    ImageType = "png",
                    Price = "6,99"
                }),
                add(c, new GoodsData{
                    Name = "3 Button Remote Key",
                    Code = "543",
                    Description = "AUDI 3 button remote key fob case FULL service repair kit.",
                    FileLocation = "a",
                    ID = "4",
                    ImageType = "png",
                    Price = "9,99"
                }),
                add(c, new GoodsData{
                    Name = "36CM UNIVERSAL CAR AUTO SAFETY SEAT BELT",
                    Code = "54321",
                    Description = "Increases the size and improves comfort of your existing seat belt." +
                                  "It is a perfect accessory for your safety, comfort and" +
                                  " ideal for use with baby and infant car seats.",
                    FileLocation = "lala",
                    ID = "5",
                    ImageType = "png",
                    Price = "7,99"
                }),
                add(c, new GoodsData{
                    Name = "GENUINE BLACK LEATHER CAR/VAN STEERING WHEEL COVER GLOVE",
                    Code = "999",
                    Description = "Black Leather Steering Wheel Cover. Genuine leather. Suitable for" +
                                  " steering wheels with an exterior diameter of 37 - 39cm.Simply stretches over the existing steering wheel",
                    FileLocation = "lala",
                    ID = "6",
                    ImageType = "png",
                    Price = "9,99"
                }),
                add(c, new GoodsData{
                    Name = "5 Bar Checker Patterned Rubber Flooring Matting",
                    Code = "987",
                    Description = "Natural rubber matting provides years of trouble-free service. Our matting provides excellent insulation" +
                                  " from the cold. ",
                    FileLocation = "lala",
                    ID = "7",
                    ImageType = "png",
                    Price = "15,99"
                }),
                add(c, new GoodsData{
                    Name = "Cup Holder",
                    Code = "98765",
                    Description = "This cup/can holder has a designated space for cans/cups anda space for coins and other small items.",
                    FileLocation = "lala",
                    ID = "8",
                    ImageType = "png",
                    Price = "10,99"
                }),
            };
            return l;
        }
        private static string add(SentryDbContext c, GoodsData goods) {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
            return goods.ID;
        }
    }
}