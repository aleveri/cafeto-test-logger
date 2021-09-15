using CafetoTest;
using CafetoTest.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CafetoTestUnitTests
{
    public class IOCFixture
    {
        public IOCFixture()
        {
            ServiceCollection serviceCollection = new();

            serviceCollection.AddTransient<IJobLogger, JobLogger>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
