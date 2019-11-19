namespace MIBI.UnitTests
{
    using System;
    using global::AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MIBI.AutoMapper;
    using MIBI.Data.Context;

    public class TestsInitializer
    {
        protected MIBIContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<MIBIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Microsoft.EntityFrameworkCore.InMemory
                .Options;

            return new MIBIContext(dbOptions);
        }

        protected IMapper GetAutoMapper()
        {
            var mockMapper = new MapperConfiguration(configuration =>
            {
                configuration.AllowNullCollections = true;
                configuration.AddProfile(new MapperInitializer());
            });

            return mockMapper.CreateMapper();
        }
    }
}
