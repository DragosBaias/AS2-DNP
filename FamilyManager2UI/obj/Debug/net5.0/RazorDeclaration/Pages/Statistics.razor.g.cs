// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FamilyManager2UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using FamilyManager2UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using FamilyManager2UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\Statistics.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\Statistics.razor"
using FamilyManager2UI.WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\Statistics.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Statistics")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/Stats")]
    public partial class Statistics : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\Statistics.razor"
       
    private IList<Family> _families;
    private IList<Person> _people;
    
    private IList<ChartData> _sex;
    private IList<ChartData> _ages;
    private IList<ChartData> _hairColors;
    private IList<ChartData> _eyeColors;
    private IList<ChartData> _heights;
    private IList<ChartData> _weights;

    private struct ChartData {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    protected override async Task OnInitializedAsync() {
        _families = await _restClient.GetAsync<Family>();
        _people = new List<Person>();
        foreach (var fam in _families) {
            foreach (var person in fam.Adults) {
                _people.Add(person);
            }
            foreach (var child in fam.Children) {
                _people.Add(child);
            }
        }
        
        _sex = new List<ChartData>();
        _sex.Add(new ChartData() {
            Name = "Male",
            Count = _people.Count(p => p.Sex.Equals("M"))
        });
        _sex.Add(new ChartData() {
            Name = "Female",
            Count = _people.Count(p => p.Sex.Equals("F"))
        });

        _ages = new List<ChartData>();
        _ages.Add(new ChartData() {
            Name = "<10",
            Count = _people.Count(p => p.Age < 10)
        });
        _ages.Add(new ChartData() {
            Name = "10-18",
            Count = _people.Count(p => p.Age is >= 10 and < 19)
        });
        _ages.Add(new ChartData() {
            Name = "19-27",
            Count = _people.Count(p => p.Age is >= 19 and < 28)
        });
        _ages.Add(new ChartData() {
            Name = "28-40",
            Count = _people.Count(p => p.Age is >= 28 and < 41)
        });
        _ages.Add(new ChartData() {
            Name = "41-55",
            Count = _people.Count(p => p.Age is >= 41 and < 56)
        });
        _ages.Add(new ChartData() {
            Name = ">55",
            Count = _people.Count(p => p.Age > 55)
        });
        
        _hairColors = new List<ChartData>();
        foreach(var color in await _restClient.GetColorAsync("haircolors")) {
            _hairColors.Add(new ChartData() {
                Name = color,
                Count = _people.Count(p => p.HairColor.Equals(color))
            });
        }
        
        _eyeColors = new List<ChartData>();
        foreach (var color in await _restClient.GetColorAsync("eyecolors")) {
            _eyeColors.Add(new ChartData() {
                Name = color,
                Count = _people.Count(p => p.EyeColor.Equals(color))
            });
        }
        
        _heights = new List<ChartData>();
        _heights.Add(new ChartData() {
            Name = "<130",
            Count = _people.Count(p => p.Height < 130)
        });
        _heights.Add(new ChartData() {
            Name = "130-145",
            Count = _people.Count(p => p.Height is >= 130 and < 146)
        });
        _heights.Add(new ChartData() {
            Name = "146-160",
            Count = _people.Count(p => p.Height is >= 146 and < 161)
        });
        _heights.Add(new ChartData() {
            Name = "161-175",
            Count = _people.Count(p => p.Height is >= 161 and < 176)
        });
        _heights.Add(new ChartData() {
            Name = ">175",
            Count = _people.Count(p => p.Height is > 175)
        });
        
        _weights = new List<ChartData>();
        _weights.Add(new ChartData() {
            Name = "<35",
            Count = _people.Count(p => p.Weight < 35)
        });
        _weights.Add(new ChartData() {
            Name = "35-49",
            Count = _people.Count(p => p.Weight is <= 35 and < 50)
        });
        _weights.Add(new ChartData() {
            Name = "50-65",
            Count = _people.Count(p => p.Weight is >= 50 and < 66)
        });
        _weights.Add(new ChartData() {
            Name = "66-80",
            Count = _people.Count(p => p.Weight is >= 66 and < 81)
        });
        _weights.Add(new ChartData() {
            Name = "81-95",
            Count = _people.Count(p => p.Weight is >= 61 and < 96)
        });
        _weights.Add(new ChartData() {
            Name = ">95",
            Count = _people.Count(p => p.Weight > 95)
        });
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRestClient _restClient { get; set; }
    }
}
#pragma warning restore 1591
