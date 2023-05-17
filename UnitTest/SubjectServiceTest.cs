using LogicLayer.Dto;
using LogicLayer.Service;
using LogicLayer.ServiceException;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WebApp;

namespace UnitTest
{
    public class SubjectServiceTest
    {
        private SubjectService subjectService;
        private int id;

        [SetUp]
        public void Setup()
        {
            subjectService = WebHost.CreateDefaultBuilder()
               .UseStartup<Startup>()
               .Build()
               .Services
               .GetService<SubjectService>();
        }

        [Test]
        [Order(1)]
        public void GetAll_ok()
        {
            Assert.DoesNotThrow(() => subjectService.Get());
        }

        [Test]
        [Order(2)]
        public void Create_ok()
        {
            SubjectCreateDto dto = new SubjectCreateDto();
            dto.Name = "Math";
            var result = subjectService.Create(dto);
            Assert.IsNotNull(result);
            id = result.Id;
        }

        [Test]
        [Order(3)]
        public void Get_ok()
        {
            Assert.IsNotNull(subjectService.Get(id));
        }

        [Test]
        [Order(4)]
        public void Get_404()
        {
            Assert.Throws<NotFoundException>(() => subjectService.Get(-1));
        }

        [Test]
        [Order(5)]
        public void Update_ok()
        {
            string name = "updated";
            SubjectCreateDto dto = new SubjectCreateDto();
            dto.Name = name;
            subjectService.Update(id, dto);

            var updated = subjectService.Get(id);
            Assert.True(string.Equals(name, updated.Name));
        }

        [Test]
        [Order(6)]
        public void Delete_ok()
        {
            subjectService.Delete(id);
            Assert.Throws<NotFoundException>(() => subjectService.Get(id));
        }
    }
}