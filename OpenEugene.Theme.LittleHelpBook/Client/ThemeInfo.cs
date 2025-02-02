using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace OpenEugene.Theme.LittleHelpBook
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "OpenEugene LittleHelpBook",
            Version = "1.0.0",
            PackageName = "OpenEugene.Theme.LittleHelpBook",
            ThemeSettingsType = "OpenEugene.Theme.LittleHelpBook.ThemeSettings, OpenEugene.Theme.LittleHelpBook.Client.Oqtane",
            ContainerSettingsType = "OpenEugene.Theme.LittleHelpBook.ContainerSettings, OpenEugene.Theme.LittleHelpBook.Client.Oqtane",
            Resources = new List<Resource>()
            {
                //Bootstrap for Oqtane
                //Check out https://github.com/leigh-pointer/MudOqtaneRazorControls 
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootswatch/5.3.2/cyborg/bootstrap.min.css",
                Integrity = "sha512-RfNxVfFNFgqk9MXO4TCKXYXn9hgc+keHCg3xFFGbnp2q7Cifda+YYzMTDHwsQtNx4DuqIMgfvZead7XOtB9CDQ==", CrossOrigin = "anonymous" },
                new Resource { ResourceType = ResourceType.Script, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.2/js/bootstrap.bundle.min.js",
                Integrity = "sha512-X/YkDZyjTf4wyc2Vy16YGCPHwAY8rZJY+POgokZjQB2mhIRFJCckEGc6YyX9eNsPfn0PzThEuNs+uaomE5CO6A==", CrossOrigin = "anonymous", Location = ResourceLocation.Body },
					
                //MudBlazor
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "_content/MudBlazor/MudBlazor.min.css" },
                new Resource { ResourceType = ResourceType.Script,     Url = "_content/MudBlazor/MudBlazor.min.js", Level=ResourceLevel.Site},

                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css"},
            }
        };
    }
}
