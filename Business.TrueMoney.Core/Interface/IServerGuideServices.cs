using Business.TrueMoney.Core.Dto;
using DataAccess.Database.CoreTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TrueMoney.Core.Interface
{
    public interface IServerGuideServices
    {
        IQueryable<ServerGuideDetails> GetAll();
        IQueryable<ServerTypeDetails> GetAllServerTypes();
        long SaveDetails(ServerGuideDetailRequest request);
        bool UpdateDetails(ServerGuideDetailRequest request);
    }
}
