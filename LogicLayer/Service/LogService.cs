using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.log;
using LogicLayer.Service.Base;


namespace LogicLayer.Service
{
    public class LogService : ServiceMain<Log, LogDto, LogCreateDto>
    {
        public LogService(RepositoryBase<Log> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
