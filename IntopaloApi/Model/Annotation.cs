using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Annotation
    {
        public int AnnotationId { get; set; }
        public string Description { get; set; }
	    public Base Base { get; set; }
    }
}