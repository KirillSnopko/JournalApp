using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.ServiceException;


namespace LogicLayer.Service
{
    public abstract class ServiceMain<Type, Dto, Create>
        where Type : EntityBase
        where Dto : class
        where Create : class
    {
        protected RepositoryBase<Type> repository { get; set; }
        protected IMapper mapper { get; set; }
        public ServiceMain(RepositoryBase<Type> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<Dto> Get() => repository.FindAll().Select(i => mapper.Map<Dto>(i)).ToList();

        public Dto Get(int id) => mapper.Map<Dto>(getByid(id));

        public abstract Dto Add(Create create);

        public abstract void Update(int id, Create dto);

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
