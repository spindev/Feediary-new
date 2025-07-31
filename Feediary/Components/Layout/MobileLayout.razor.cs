using Microsoft.AspNetCore.Components;

namespace Feediary.Components.Layout
{
    public partial class MobileLayout : LayoutComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        private string IsActive(string path)
        {
            var currentPath = new Uri(Navigation.Uri).AbsolutePath;
            
            if (path == "/" && currentPath == "/")
                return "active";
            
            if (path != "/" && currentPath.StartsWith(path, StringComparison.OrdinalIgnoreCase))
                return "active";
            
            return "";
        }
    }
}