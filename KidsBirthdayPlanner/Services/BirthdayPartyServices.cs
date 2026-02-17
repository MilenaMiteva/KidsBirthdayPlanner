using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Services.Interfaces;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KidsBirthdayPlanner.Services
{
    public class BirthdayPartyService : IBirthdayPartyService
    {
        private readonly KidsBirthdayPlannerContext context;

        public BirthdayPartyService(KidsBirthdayPlannerContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BirthdayPartyViewModel>> GetAllAsync()
        {
            return await context.BirthdayParties
                .Select(p => new BirthdayPartyViewModel
                {
                    Id = p.Id,
                    ThemeName = p.Theme.Name,
                    CakeName = p.Cake.Type + " - " + p.Cake.Flavor,
                    BalloonName = p.Balloon.Type + " - " + p.Balloon.Color,
                    Date = p.Date,
                    GuestsCount = p.GuestsCount,
                    Portions = p.Portions,
                    BalloonQuantity = p.BalloonQuantity,
                    LocationName = p.LocationName
                })
                .ToListAsync();
        }

        public async Task<BirthdayPartyViewModel?> GetByIdAsync(int id)
        {
            return await context.BirthdayParties
                .Where(p => p.Id == id)
                .Select(p => new BirthdayPartyViewModel
                {
                    Id = p.Id,
                    ThemeName = p.Theme.Name,
                    CakeName = p.Cake.Type + " - " + p.Cake.Flavor,
                    BalloonName = p.Balloon.Type + " - " + p.Balloon.Color,
                    Date = p.Date,
                    GuestsCount = p.GuestsCount,
                    BalloonQuantity = p.BalloonQuantity,
                    Portions = p.Portions,
                    LocationName = p.LocationName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BirthdayPartyViewModel> GetCreateModelAsync()
        {
            var model = new BirthdayPartyViewModel
            {
                Themes = await context.Themes
                    .OrderBy(t => t.Name)
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Name
                    }).ToListAsync(),

                Cakes = await context.Cakes
                    .OrderBy(c => c.Type)
                    .ThenBy(c => c.Flavor)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Type + " - " + c.Flavor
                    }).ToListAsync(),

                Balloons = await context.Balloons
                    .OrderBy(b => b.Type)
                    .ThenBy(b => b.Color)
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Type + " - " + b.Color
                    }).ToListAsync(),

                Locations = new List<SelectListItem>
                {
                    new SelectListItem{Value="Kids Club Galaxy",Text="Kids Club Galaxy"},
                    new SelectListItem{Value="Playground Varna",Text="Playground Varna"},
                    new SelectListItem{Value="Happy Land Varna",Text="Happy Land Varna"},
                    new SelectListItem{Value="Mini Party Center",Text="Mini Party Center"},
                    new SelectListItem{Value="Jump Arena",Text="Jump Arena"},
                    new SelectListItem{Value="Fun City Mall",Text="Fun City Mall"},
                    new SelectListItem{Value="Kids Planet",Text="Kids Planet"},
                    new SelectListItem{Value="Party Zone Varna",Text="Party Zone Varna"},
                    new SelectListItem{Value="Family Fun Center",Text="Family Fun Center"},
                    new SelectListItem{Value="Magic Kids Hall",Text="Magic Kids Hall"}
                }
            };

            return model;
        }

        public async Task CreateAsync(BirthdayPartyViewModel model)
        {
            var party = new BirthdayParty
            {
                ThemeId = model.ThemeId,
                CakeId = model.CakeId,
                BalloonId = model.BalloonId,
                BalloonQuantity = model.BalloonQuantity,
                Portions = model.Portions,
                Date = model.Date,
                GuestsCount = model.GuestsCount,
                LocationName = model.LocationName
            };

            await context.BirthdayParties.AddAsync(party);
            await context.SaveChangesAsync();
        }

        public async Task<BirthdayPartyViewModel?> GetEditAsync(int id)
        {
            var model = await GetByIdAsync(id);

            if (model == null)
            { 
                return null; 
            }

            model.Themes = await context.Themes
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                }).ToListAsync();

            model.Cakes = await context.Cakes
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Type + " - " + c.Flavor
                }).ToListAsync();

            model.Balloons = await context.Balloons
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Type + " - " + b.Color
                }).ToListAsync();

            model.Locations = new List<SelectListItem>
    {
        new("Kids Club Galaxy","Kids Club Galaxy"),
        new("Playground Varna","Playground Varna"),
        new("Happy Land Varna","Happy Land Varna"),
        new("Mini Party Center","Mini Party Center"),
        new("Jump Arena","Jump Arena"),
        new("Fun City Mall","Fun City Mall"),
        new("Kids Planet","Kids Planet"),
        new("Party Zone Varna","Party Zone Varna"),
        new("Family Fun Center","Family Fun Center"),
        new("Magic Kids Hall","Magic Kids Hall")
    };

            return model;
        }


        public async Task EditAsync(BirthdayPartyViewModel model)
        {
            var party = await context.BirthdayParties.FindAsync(model.Id);

            if (party == null) return;

            party.ThemeId = model.ThemeId;
            party.CakeId = model.CakeId;
            party.BalloonId = model.BalloonId;
            party.BalloonQuantity = model.BalloonQuantity;
            party.Portions = model.Portions;
            party.Date = model.Date;
            party.GuestsCount = model.GuestsCount;
            party.LocationName = model.LocationName;

            await context.SaveChangesAsync();
        }
        public async Task<BirthdayPartyViewModel?> GetDeleteAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var party = await context.BirthdayParties.FindAsync(id);

            if (party == null) return;

            context.BirthdayParties.Remove(party);
            await context.SaveChangesAsync();
        }
    }
}
