using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using ParkingApp.Classes;
using ParkingApp.Enum;
using ParkingApp.Helper;
using ParkingAppTest.Test;

namespace ParkingAppTest {
    [TestFixture]
    public class Tests {
        [Test]
        public void TestTranslator() {
            Assert.DoesNotThrow(() => new Translator(Language.DANISH, "da-DK"));
            Assert.Throws<FileNotFoundException>(() => new Translator(Language.MISSING, "missing"));
            Assert.True(new Translator(Language.DANISH, "da-DK").Translate("LANGUAGE") == "Sprog");
            Assert.True(TranslatorTest.TestTranslate(Language.DANISH, "da-DK", "LANGUAGES") == "TRANSLATION_MISSING");
            Assert.True(TranslatorTest.TestTranslate(Language.MISSING, "da-DK", "LANGUAGE") == "");
        }

        [Test]
        public void TestParking() {
            Assert.IsInstanceOf(typeof(Dictionary<string, Parking>), Parking.GetByLicensePlate(Country.DENMARK, "AA12345"));
            Assert.DoesNotThrow(() => Parking.Post(Country.DENMARK, "AA12345"));
            Assert.DoesNotThrow(() => Parking.Put(Country.DENMARK, "AA12345"));
        }

        [Test]
        public void TestKeyboard() {
            var input = "";
            var keyboard = new Keyboard()
                .PushRow(new List<char> {'a', 'b', 'c'}, (s) => input += s)
                .PushKey(0, '⌫', (s) => {
                    if (input.Length == 0) return;
                    input = input.Remove(input.Length - 1);
                })
                .PushKey(0, '⌧', (s) => input = "");

            Assert.True(input == "");
            keyboard.Layout[0].Keys[0].Callback(keyboard.Layout[0].Keys[0].Symbol);
            keyboard.Layout[0].Keys[1].Callback(keyboard.Layout[0].Keys[1].Symbol);
            keyboard.Layout[0].Keys[2].Callback(keyboard.Layout[0].Keys[2].Symbol);
            Assert.True(input == "abc");
            keyboard.Layout[0].Keys[3].Callback(keyboard.Layout[0].Keys[3].Symbol);
            Assert.True(input == "ab");
            keyboard.Layout[0].Keys[4].Callback(keyboard.Layout[0].Keys[4].Symbol);
            Assert.True(input == "");
        }
    }
}
