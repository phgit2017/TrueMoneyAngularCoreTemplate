namespace DataAccess.Database.CoreTemplate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServerType
    {
        public ServerType()
        {
            ServerGuides = new HashSet<ServerGuide>();
        }

        public int ServerTypeId { get; set; }

        [Required]
        [StringLength(32)]
        public string ServerTypeName { get; set; }

        public virtual ICollection<ServerGuide> ServerGuides { get; set; }
    }
}
