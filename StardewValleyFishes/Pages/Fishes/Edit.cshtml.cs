using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StardewValleyFishes.Core;
using StardewValleyFishes.Data;
namespace StardewValleyFishes.Pages.Fishes
{
    public class EditModel : PageModel
    {

        private readonly IFishData fishData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Fish Fish { get; set; }
        public IEnumerable<SelectListItem> Seasons { get; set; }
        public IEnumerable<SelectListItem> Locals { get; set; }


        public EditModel(IFishData fishData,
                         IHtmlHelper htmlHelper)
        {
            this.fishData = fishData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? fishId)
        {
            
            Seasons = htmlHelper.GetEnumSelectList<SeasonType>();
            Locals = htmlHelper.GetEnumSelectList<Location>();
            if (fishId.HasValue)
            {
                Fish = fishData.GetById(fishId.Value);
             
            }
            else
            {
                Fish = new Fish();
                
              
            }
            if (Fish == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Seasons = htmlHelper.GetEnumSelectList<SeasonType>();
                return Page();
            }

            if (Fish.Id > 0)
            {
                fishData.Update(Fish);
            }
            else
            {
                fishData.Add(Fish);
            }
            fishData.Commit();
            TempData["Message"] = "Fish saved!";
            return RedirectToPage("./Detail", new { fishId = Fish.Id });
        }

    }
}