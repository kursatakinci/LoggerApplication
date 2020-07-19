using Autofac;
using LoggerApplication.Repository;
using LoggerApplication.Service.Logging;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using LoggerApplication.Controllers;
using System;
using LoggerApplication.Core.Helper;
using System.Text.Json;

namespace LoggerApplication.Test
{
    public class Tests
    {
        private ILogService _loggerService;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<LoggerApplicationDbContext>();
                opt.UseSqlServer("Server=.;Initial Catalog=logdb; Trusted_Connection=True;");

                return new LoggerApplicationDbContext(opt.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();

            var scope = builder.Build();

            _loggerService = scope.BeginLifetimeScope().Resolve<ILogService>();
        }

        [Test]
        public void Test1()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                controller.GetAll();

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }

        [Test]
        public void Test2()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                var result = controller.Get(10);

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }

        [Test]
        public void Test3()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                JsonDocument jsonDocument = JsonDocument.Parse("[\"deneme\"]");

                var jsonElement = jsonDocument.RootElement;
                var array = jsonElement.EnumerateArray();
                array.MoveNext();

                controller.Search(array.Current);

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }

        [Test]
        public void Test4()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                JsonDocument jsonDocument = JsonDocument.Parse("[{ \"LogType\" : 10, \"ShortDesc\" : \"Deneme logu\", \"FullDesc\" : \"Deneme için atýlmýþ logdur\", \"RelatedObject\" : \"\", \"CreatedOnUtc\" : \"2020-07-20T02:00:18.058Z\" }]");

                var jsonElement = jsonDocument.RootElement;
                var array = jsonElement.EnumerateArray();
                array.MoveNext();

                controller.Insert(array.Current);

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }

        [Test]
        public void Test5()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                JsonDocument jsonDocument = JsonDocument.Parse("[{ \"LogId\" : 1, \"LogType\" : 10, \"ShortDesc\" : \"Deneme logu\", \"FullDesc\" : \"Deneme için atýlmýþ logdur, update için full desc düzenlenmiþtir.\", \"RelatedObject\" : \"\", \"CreatedOnUtc\" : \"2020-07-20T02:00:18.058Z\" }]");

                var jsonElement = jsonDocument.RootElement;
                var array = jsonElement.EnumerateArray();
                array.MoveNext();

                controller.Put(array.Current);

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }

        [Test]
        public void Test6()
        {
            bool passed = false;
            string exMessage = string.Empty;

            try
            {
                var controller = new LoggerController(_loggerService);

                controller.Delete(1);

                passed = true;
            }
            catch (Exception ex)
            {
                passed = false;
                exMessage = ex.GetExceptionMessage();
            }

            if (passed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(exMessage);
            }
        }
    }
}