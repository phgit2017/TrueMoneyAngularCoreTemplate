using Business.TrueMoney.Core.Dto;
using Business.TrueMoney.Core.Interface;
using DataAccess.Database.CoreTemplate;
using DataAccess.Repository.TrueMoney.Interface;
using dbentities = DataAccess.Database.CoreTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.TrueMoney.Core.Extensions;

namespace Business.TrueMoney.Core
{
    public partial class ServerGuideServices
    {
        ICoreTemplateRepository<dbentities.ServerGuide> _serverGuides;
        ICoreTemplateRepository<dbentities.ServerType> _serverTypes;

        private dbentities.ServerGuide serverGuides;
        private dbentities.ServerType serverTypes;

        public ServerGuideServices(ICoreTemplateRepository<dbentities.ServerGuide> serverGuides,
            ICoreTemplateRepository<dbentities.ServerType> serverTypes)
        {
            this._serverGuides = serverGuides;
            this._serverTypes = serverTypes;

            this.serverGuides = new dbentities.ServerGuide();
            this.serverTypes = new dbentities.ServerType();
        }
    }

    public partial class ServerGuideServices : IServerGuideServices
    {
        public IQueryable<ServerGuideDetails> GetAll()
        {
            var result = from det in this._serverGuides.GetAll()
                         select new ServerGuideDetails()
                         {
                             ServerId = det.ServerId,
                             ServerName = det.ServerName,
                             ServerTypeId = det.ServerTypeId,
                             ServerTypeName = det.ServerType.ServerTypeName,
                             RemoteLink = det.RemoteLink,
                             RemoteLinkDB = det.RemoteLinkDB,
                             RemoteUserCredentials = det.RemoteUserCredentials,
                             DHCRemoteLink = det.DHCRemoteLink,
                             URLLink = det.URLLink,
                             CreatedBy = det.CreatedBy,
                             CreatedTime = det.CreatedTime
                         };

            return result;
        }

        public IQueryable<ServerTypeDetails> GetAllServerTypes()
        {
            var result = from det in this._serverTypes.GetAll()
                         select new ServerTypeDetails()
                         {
                             ServerTypeId = det.ServerTypeId,
                             ServerTypeName = det.ServerTypeName
                         };

            return result;
        }

        public long SaveDetails(ServerGuideDetailRequest request)
        {
            request.ServerId = 0;
            this.serverGuides = request.DtoToEntity();
            var item = this._serverGuides.Insert(this.serverGuides);
            if (item == null)
            {
                return 0;
            }

            return item.ServerId;
        }

        public bool UpdateDetails(ServerGuideDetailRequest request)
        {
            this.serverGuides = request.DtoToEntity();
            var item = _serverGuides.Update2(this.serverGuides);
            if (item == null)
            {
                return false;
            }

            return true;
        }
    }
}
