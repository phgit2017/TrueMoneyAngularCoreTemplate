using Business.TrueMoney.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dbentities = DataAccess.Database.CoreTemplate;

namespace Business.TrueMoney.Core.Extensions
{
    public static class EntityMapper
    {
        public static dbentities.ServerGuide DtoToEntity(this ServerGuideDetailRequest request)
        {
            dbentities.ServerGuide entity = null;

            if (request != null)
            {
                entity = new dbentities.ServerGuide
                {
                    ServerId = request.ServerId,
                    ServerName = request.ServerName,
                    ServerTypeId = request.ServerTypeId,
                    RemoteLink = request.RemoteLink,
                    RemoteLinkDB = request.RemoteLinkDB,
                    RemoteUserCredentials = request.RemoteUserCredentials,
                    DHCRemoteLink = request.DHCRemoteLink,
                    URLLink = request.URLLink,
                    CreatedBy = request.CreatedBy,
                    CreatedTime = request.CreatedTime,
                };
            }

            return entity;
        }
    }
}
