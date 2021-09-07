using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string LeagueAdded = "Lig başarıyla eklendi";
        public static string FixtureList = "Fixture Listelendi";
        public static string FixtureDelete = "Fixture Silindi";
        public static string TeamAdded = "Takım Eklendi";
        public static string TeamList = "Takımlar Listelendi";
        public static object TeamsLeagueIdMesage = "Numaralı Lig Listelendi";
        public static string PlayerDeleted = "Oyuncu Silindi";
        public static string PlayerAdded = "Oyuncu Eklendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string AlreadyExist = "Aynı isimden eklenemez";
    }
}
