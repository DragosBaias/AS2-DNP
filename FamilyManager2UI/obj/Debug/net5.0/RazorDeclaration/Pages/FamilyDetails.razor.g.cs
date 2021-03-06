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
#line 2 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\FamilyDetails.razor"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\FamilyDetails.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\FamilyDetails.razor"
using FamilyManager2UI.WebClient;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Family/{address}/{number:int}")]
    public partial class FamilyDetails : MainLayout
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 149 "C:\Users\Dragos\Desktop\Downloads\DNP-AS-2-main\DNP-AS-2-main\FamilyManager2\FamilyManager2UI\Pages\FamilyDetails.razor"
       

    [Parameter]
    public string Address { get; set; }

    [Parameter]
    public int Number { get; set; }

    private Family _family;
    private IList<Person> _familyMembers;
    private IList<Person> _filteredFamilyMembers;

    private IList<Pet> _pets;
    private IList<Pet> _filteredPets;


    //carousel stuff
    string _firstSlide = "active";
    string _secondSlide = "";

    int _currentPosition = 0;
    int _currentSlide = 0;

    protected override async Task OnInitializedAsync() {
        _family = await _restClient.GetAsync<Family>(Address,Number);
        _familyMembers = _family.GetAllMembers();
        _filteredFamilyMembers = _familyMembers;

        _pets = _family.Pets;
        _filteredPets = _pets;
    }

    public void Manually(bool backwards) {
        if (backwards) {
            _currentPosition--;
            _filteredPets = _pets;
            _filteredFamilyMembers = _familyMembers;
        }
        else {
            _currentPosition++;
            _filteredPets = _pets;
            _filteredFamilyMembers = _familyMembers;
        }

        ChangeSlide();
    }


    private void ChangeSlide() {
        _currentSlide = Math.Abs(_currentPosition % 2);

        switch (_currentSlide) {
            case 0:
                _firstSlide = "active";
                _secondSlide = "";
                break;
            case 1:
                _firstSlide = "";
                _secondSlide = "active";
                break;
        }
    }

    private void FilterByName(ChangeEventArgs changeEventArgs) {
        List<Person> people = new List<Person>();
        foreach (var person in _family.GetAllMembers()) {
            if (person.FirstName.ToLower().Contains(changeEventArgs.Value.ToString().ToLower()) || person.LastName.ToLower().Contains(changeEventArgs.Value.ToString().ToLower()))
                people.Add(person);
        }
        _filteredFamilyMembers = people;
    }

    private void FilterByRole(ChangeEventArgs changeEventArgs) {
        List<Person> people = new List<Person>();
        if (changeEventArgs.Value.ToString().Equals("child")) {
            foreach (var person in _family.Children) {
                people.Add(person);
            }
        }
        else if (changeEventArgs.Value.ToString().Equals("adult")) {
            foreach (var person in _family.Adults) {
                people.Add(person);
            }
        }
        else if (changeEventArgs.Value.ToString().Equals("all")) {
            people = _familyMembers.ToList();
        }
        _filteredFamilyMembers = people;
    }

    private void SortByFirstName() {
        var sort = _filteredFamilyMembers.OrderBy(name => name.FirstName);
        _filteredFamilyMembers = sort.ToList();
    }

    private void SortByLastName() {
        var sort = _filteredFamilyMembers.OrderBy(name => name.LastName);
        _filteredFamilyMembers = sort.ToList();
    }

    private void View(int id, string firstName, string lastName) {
        _navigationManager.NavigateTo($"Person/{id}/{firstName}/{lastName}");
    }

    private void FilterByPetName(ChangeEventArgs changeEventArgs) {
        List<Pet> pets = new List<Pet>();
        foreach (var pet in _family.Pets) {
            if (pet.Name.ToLower().Contains(changeEventArgs.Value.ToString().ToLower()))
                pets.Add(pet);
        }
        _filteredPets = pets;
    }

    private void FilterBySpecies(ChangeEventArgs changeEventArgs) {
        List<Pet> pets = new List<Pet>();
        if (changeEventArgs.Value.ToString().Equals("cat")) {
            foreach (var pet in _family.Pets) {
                if(pet.Species.ToLower().Equals("cat"))
                    pets.Add(pet);
            }
        }
        else if (changeEventArgs.Value.ToString().Equals("dog")) {
            foreach (var pet in _family.Pets) {
                if(pet.Species.ToLower().Equals("dog"))
                    pets.Add(pet);
            }
        }
        else if (changeEventArgs.Value.ToString().Equals("other")) {
            foreach (var pet in _family.Pets) {
                if(!pet.Species.ToLower().Equals("cat") && !pet.Species.ToLower().Equals("dog"))
                    pets.Add(pet);
            }
        }
        else if (changeEventArgs.Value.ToString().Equals("all")) {
            pets = _family.Pets;
        }
        _filteredPets = pets;
    }

    private void SortByPetName() {
        var sort = _filteredPets.OrderBy(name => name.Name);
        _filteredPets = sort.ToList();
    }


    private void ViewPet(int itemId) {
        _navigationManager.NavigateTo($"PetDetails/{itemId}");
    }
    
    private async Task RemoveFamilyAsync() {
        await _restClient.DeleteAsync<Family>(Address,Number);
        _navigationManager.NavigateTo("/FamilyList");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRestClient _restClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
    }
}
#pragma warning restore 1591
