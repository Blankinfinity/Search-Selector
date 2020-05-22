using System.ComponentModel.DataAnnotations;

namespace Search_Selector.Models
{
    public class SearchModel
    {
        /// <summary>
        /// Get or sets SearchEngineName
        /// </summary>
        [Display(Name="Search Provider")]
        [Required(ErrorMessage = "Please select a search provider before clicking to search.")]
        public string SearchEngineName { get; set; }

        /// <summary>
        /// Gets or sets SearchTerm
        /// </summary>
        [Required(ErrorMessage = "Please enter a search term before clicking to search.")]
        public string SearchTerm { get; set; }
    }
}