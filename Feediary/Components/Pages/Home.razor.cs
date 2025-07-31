using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Feediary.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private string GetGreeting()
        {
            var hour = DateTime.Now.Hour;
            return hour switch
            {
                >= 5 and < 12 => Localizer["GoodMorning"],
                >= 12 and < 17 => Localizer["GoodAfternoon"],
                >= 17 and < 22 => Localizer["GoodEvening"],
                _ => Localizer["GoodNight"]
            };
        }
    }
}