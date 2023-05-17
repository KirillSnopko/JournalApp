using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto;
using LogicLayer.ServiceException;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Service
{
    public abstract class ServiceMain<Type, Dto, Create>
        where Type : class
        where Dto : class
        where Create : class
    {
        private readonly RepositoryBase<Type> repository;
        private readonly IMapper mapper;
        public virtual Expression<Func<Type, bool>> expression { get; set; }
        public ServiceMain(RepositoryBase<Type> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<Dto> Get() => repository.FindAll().Select(i => mapper.Map<Dto>(i)).ToList();

        public Dto Get(int id) => mapper.Map<Dto>(getByCondition(id));


        public virtual Type getByCondition(int id)
        {
            try
            {
                return repository.FindByCondition(expression).First();
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException($"{ex.Message} => {nameof(Type)} with id={id} not found");
            }
        }
    }
}
