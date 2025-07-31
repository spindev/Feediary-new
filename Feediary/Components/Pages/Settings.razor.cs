using Microsoft.AspNetCore.Components;

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
        public string CurrentTheme { get; set; } = "Dark Mode";
        public string PreferredUnits { get; set; } = "Imperial (oz)";
        public string AppLanguage { get; set; } = "English";
        public bool AutoBackupEnabled { get; set; } = true;
        public string LastBackupDate { get; set; } = "Today, 2:30 PM";
        public int DataRetentionDays { get; set; } = 365;

        private string GetBabyAge()
        {
            // Mock calculation - in real app this would calculate actual age
            var birthDate = new DateTime(2024, 3, 15);
            var age = DateTime.Now - birthDate;
            
            if (age.Days < 30)
                return $"{age.Days} days old";
            else if (age.Days < 365)
                return $"{age.Days / 30} months old";
            else
                return $"{age.Days / 365} years old";
        }
    }
}