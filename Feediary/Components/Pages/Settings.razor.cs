using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Feediary.Components.Pages
{
    public partial class Settings : ComponentBase
    {
        // Mock settings data for demonstration
        public string BabyName { get; set; } = "Little Angel";
        public string BabyBirthDate { get; set; } = "March 15, 2024";
        public bool NotificationsEnabled { get; set; } = true;
        public int ReminderInterval { get; set; } = 3;
        public string QuietHoursStart { get; set; } = "10:00 PM";
        public string QuietHoursEnd { get; set; } = "6:00 AM";
        public bool AutoBackupEnabled { get; set; } = true;
        public string LastBackupDate { get; set; } = "Today, 2:30 PM";
        public int DataRetentionDays { get; set; } = 365;

        private string GetBabyAge()
        {
            // Mock calculation - in real app this would calculate actual age
            var birthDate = new DateTime(2024, 3, 15);
            var age = DateTime.Now - birthDate;
            
            if (age.Days < 30)
                return Localizer["DaysOld", age.Days];
            else if (age.Days < 365)
                return Localizer["MonthsOld", age.Days / 30];
            else
                return Localizer["YearsOld", age.Days / 365];
        }

        private string GetCurrentLanguageName()
        {
            var currentCulture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            return currentCulture switch
            {
                "de" => Localizer["German"],
                _ => Localizer["English"]
            };
        }

        private string GetLocalizedLastBackup()
        {
            // In a real app, this would format the date according to the current culture
            return $"{Localizer["Today"]}, 2:30 PM";
        }
    }
}