using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using ParkingApp.Classes;
using ParkingApp.Enum;
using ParkingAppTest.Test;

namespace ParkingAppTest {
    [TestFixture]
    public class Tests {
        [Test]
        public void TestTranslator() {
            Assert.DoesNotThrow(() => new Translator(Language.DANISH, "da-DK"));
            Assert.Throws<FileNotFoundException>(() => new Translator(Language.MISSING, "missing"));
            Assert.True(new Translator(Language.DANISH, "da-DK").Translate( "LANGUAGE") == "Sprog");
            Assert.True(TranslatorTest.TestTranslate(Language.DANISH, "da-DK", "LANGUAGES") == "TRANSLATION_MISSING");
            Assert.True(TranslatorTest.TestTranslate(Language.MISSING, "da-DK", "LANGUAGE") == "");
        }
        
        [Test]
        public void TestParking() {
            Assert.IsInstanceOf(typeof (Dictionary<string, Parking>), Parking.GetByLicensePlate(Country.DENMARK, "AA12345"));
            Assert.DoesNotThrow(() => Parking.Post(Country.DENMARK, "AA12345"));
            Assert.DoesNotThrow(() => Parking.Put(Country.DENMARK, "AA12345"));
        }
    }
}
