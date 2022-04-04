using BARG.Models;
using System.Collections.Generic;

namespace BARG.ViewModels
{
    public class AssessmentsViewModel
    {
        public int Id { get; set; }
        public ApplicationUser AssessmentUser { get; set; }

        public int RegionId { get; set; }
        public IEnumerable<Region> Regions { get; set; }
        public List<Region> RegionsList { get; set; }
        public string[] ShareRegion { get; set; }

        public string Heading { get; set; }

    }
}