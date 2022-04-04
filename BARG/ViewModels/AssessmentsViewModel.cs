using BARG.Controllers;
using BARG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BARG.ViewModels
{
    public class AssessmentsViewModel
    {
        public int Id { get; set; }
        public ApplicationUser AssessmentUser { get; set; }

        public int RegionId { get; set; }
        [Required]
        public IEnumerable<Region> RegionLookUp { get; set; }
        public List<Region> RegionsList { get; set; }
        //public string[] ShareRegion { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {   // Lambda expression below represent an anomous method
                // func is a deligate that represent an anomous method
                Expression<Func<AssessmentsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<AssessmentsController, ActionResult>> save = (c => c.Save(this));

                var action = (Id != 0) ? update : save;
                return (action.Body as MethodCallExpression).Method.Name;

                // above instead of below
                //return (Id != 0) ? "Update" : "Save";
            }
        }
    }
}