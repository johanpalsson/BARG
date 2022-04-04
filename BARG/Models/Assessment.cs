using System.Collections.Generic;

namespace BARG.Models
{
    public class Assessment
    {
        public Assessment()
        {
            Regions = new List<Region>();
        }
        public int Id { get; set; }

        public ApplicationUser AssessmentUser { get; set; }

        public List<Region> Regions { get; set; }


    }
}