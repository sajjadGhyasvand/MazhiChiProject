using System.Collections.Generic;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore
{
    public class SatisfactionLevel
    {
        public const int Satisfaction1 = 1;
        public const string SatisfactionStr1Fa = "عالی";
        public const string SatisfactionStr1En = "Great";
        public const string SatisfactionStr1Ar = "عظيم";
        public const string SatisfactionStr1Ru = "большой";

        public const int Satisfaction2 = 2;
        public const string SatisfactionStr2Fa = "خوب";
        public const string SatisfactionStr2En = "Good";
        public const string SatisfactionStr2Ar = "جيد";
        public const string SatisfactionStr2Ru = "хороший";

        public const int Satisfaction3 = 3;
        public const string SatisfactionStr3Fa = "متوسط";
        public const string SatisfactionStr3En = "Medium";
        public const string SatisfactionStr3Ar = "متوسط";
        public const string SatisfactionStr3Ru = "средний";

        public const int Satisfaction4 = 4;
        public const string SatisfactionStr4Fa = "ضعیف";
        public const string SatisfactionStr4En = "Weak";
        public const string SatisfactionStr4Ar = "ضعيف";
        public const string SatisfactionStr4Ru = "слабый";
    }

    public class SatisfactionLevelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public static class SatisfactionLevelItemService
    {
        public static List<SatisfactionLevelItem> GetComplaintAndSatisfactionListAdmin()
        {
            return new List<SatisfactionLevelItem>
            {
                new SatisfactionLevelItem
                    { Id = SatisfactionLevel.Satisfaction1, Name = SatisfactionLevel.SatisfactionStr1Fa },
                new SatisfactionLevelItem
                    { Id = SatisfactionLevel.Satisfaction2, Name = SatisfactionLevel.SatisfactionStr2Fa },
                new SatisfactionLevelItem
                    { Id = SatisfactionLevel.Satisfaction3, Name = SatisfactionLevel.SatisfactionStr3Fa },
                new SatisfactionLevelItem
                    { Id = SatisfactionLevel.Satisfaction4, Name = SatisfactionLevel.SatisfactionStr4Fa },
            };
        }

        public static List<SatisfactionLevelItem> GetComplaintAndSatisfactionList(string lng)
        {
            switch (lng)
            {
                case "fa-IR":
                    return new List<SatisfactionLevelItem>
                    {
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction1, Name = SatisfactionLevel.SatisfactionStr1Fa },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction2, Name = SatisfactionLevel.SatisfactionStr2Fa },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction3, Name = SatisfactionLevel.SatisfactionStr3Fa },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction4, Name = SatisfactionLevel.SatisfactionStr4Fa },
                    };
                case "en-US":
                    return new List<SatisfactionLevelItem>
                    {
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction1, Name = SatisfactionLevel.SatisfactionStr1En },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction2, Name = SatisfactionLevel.SatisfactionStr2En },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction3, Name = SatisfactionLevel.SatisfactionStr3En },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction4, Name = SatisfactionLevel.SatisfactionStr4En },
                    };
                case "ru-RU":
                    return new List<SatisfactionLevelItem>
                    {
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction1, Name = SatisfactionLevel.SatisfactionStr1Ru },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction2, Name = SatisfactionLevel.SatisfactionStr2Ru },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction3, Name = SatisfactionLevel.SatisfactionStr3Ru },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction4, Name = SatisfactionLevel.SatisfactionStr4Ru },
                    };

                case "ar":
                    return new List<SatisfactionLevelItem>
                    {
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction1, Name = SatisfactionLevel.SatisfactionStr1Ar },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction2, Name = SatisfactionLevel.SatisfactionStr2Ar },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction3, Name = SatisfactionLevel.SatisfactionStr3Ar },
                        new SatisfactionLevelItem
                            { Id = SatisfactionLevel.Satisfaction4, Name = SatisfactionLevel.SatisfactionStr4Ar },
                    };
            }

            return new List<SatisfactionLevelItem>();
        }
    }
}