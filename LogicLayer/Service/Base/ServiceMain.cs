using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.ServiceException;


namespace LogicLayer.Service.Base
{
    public abstract class ServiceMain<Type, Dto, Create>
        where Type : EntityBase
        where Dto : class
        where Create : class
    {
        protected RepositoryBase<Type> repository { get; set; }
        protected IMapper mapper { get; set; }
        protected ServiceMain(RepositoryBase<Type> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<Dto> Get() => repository.FindAll().Select(i => mapper.Map<Dto>(i)).ToList();

        public Dto Get(int id) => mapper.Map<Dto>(getByid(id));

        public Dto Add(Create create)
        {
            Type t = repository.Create(mapper.Map<Type>(create));
            repository.Save();
            Dto dto = mapper.Map<Dto>(t);
            return dto;
        }

        public void Update(int id, Create dto)
        {
            Type type = getByid(id);
            repository.Update(mapper.Map<Create, Type>(dto, type));
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete(getByid(id));
            repository.Save();
        }

        protected Type getByid(int id)
        {
            try
            {
                return repository.FindByIdFirst(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException($"{ex.Message} => {nameof(Type)} with id={id} not found");
            }
        }
    }
}
