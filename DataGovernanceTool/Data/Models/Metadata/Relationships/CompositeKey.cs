using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Models.Metadata.Relationships
{
    public class CompositeKey : Base
    {
        public List<CompositeKeyField> CompositeKeyFields { get; set; }
        public int TableId { get; set; }
        public Table TablePrimary { get; set; }
        public Table TableForeign { get; set; }
    }
}