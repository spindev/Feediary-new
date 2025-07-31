using Microsoft.AspNetCore.Components;

namespace Feediary.Components.Pages
{
    public partial class Calendar : ComponentBase
    {
        // Mock data for demonstration
        public int TodaysFeedingCount { get; set; } = 6;
        public int WeeklyFeedingCount { get; set; } = 42;
        public decimal AverageFeedingsPerDay { get; set; } = 6.0m;

        private string GetCurrentDateFormatted()
        {
            return DateTime.Now.ToString("dddd, MMMM dd");
        }

        private string GetLastFeedingTime()
        {
            // Mock data - in real app this would come from a database
            var lastFeeding = DateTime.Now.AddHours(-2.5);
            return lastFeeding.ToString("h:mm tt");
        }

        private string GetNextFeedingTime()
        {
            // Mock data - in real app this would be calculated based on feeding patterns
            var nextFeeding = DateTime.Now.AddHours(0.5);
            return nextFeeding.ToString("h:mm tt");
        }
    }
}