namespace DataAccess.Database.CoreTemplate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServerGuides")]
    public partial class ServerGuide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ServerId { get; set; }

        [StringLength(32)]
        public string ServerName { get; set; }

        public int ServerTypeId { get; set; }

        [StringLength(192)]
        public string RemoteLink { get; set; }

        [StringLength(192)]
        public string RemoteLinkDB { get; set; }

        [StringLength(32)]
        public string RemoteUserCredentials { get; set; }

        [StringLength(192)]
        public string DHCRemoteLink { get; set; }

        [StringLength(192)]
        public string URLLink { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        [ForeignKey("ServerTypeId")]
        public virtual ServerType ServerType { get; set; }
    }
}
