using Search_Selector.Models;
using System.Collections.Generic;

namespace Search_Selector.ViewModels
{
    public class SearchViewModel
    {
        public SearchModel SearchModel { get; set; }
        public List<QuickLink> QuickLinks { get; set; }
    }
}