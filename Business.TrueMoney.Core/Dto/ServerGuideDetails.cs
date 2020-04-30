using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrueMoney.Core.Dto
{
    public class ServerGuideDetails
    {
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

        [StringLength(32)]
        public string ServerTypeName { get; set; }
    }

    public class ServerTypeDetails
    {
        public int ServerTypeId { get; set; }

        [Required]
        [StringLength(32)]
        public string ServerTypeName { get; set; }
    }

    public class ServerGuideDetailRequest
    {
        public long ServerId { get; set; }

        [StringLength(32)]
        public string ServerName { get; set; }

        [Required]
        [StringLength(32)]
        public string ServerTypeName { get; set; }

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
    }
}
