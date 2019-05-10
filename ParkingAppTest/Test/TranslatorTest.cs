using System;
using ParkingApp.Classes;
using ParkingApp.Enum;

namespace ParkingAppTest.Test {
    public static class TranslatorTest {
        public static bool TestConstructor(Language L, string S) {
            try {
                var a = new Translator(L, S);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public static string TestTranslate(Language L, string S, string Token) {
            try {
                var a = new Translator(L, S);
                return a.Translate(Token);
            }
            catch (Exception) {
                return "";
            }
        }
    }
}
