using CafetoTest.Common.Interfaces;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using static CafetoTest.Common.Enums.DestinationEnum;
using static CafetoTest.Common.Enums.LogTypeEnum;
using CafetoTest;
using System;

namespace CafetoTestUnitTests
{
    public class JobLoggerTest : IClassFixture<IOCFixture>
    {
        private readonly IJobLogger _jobLogger;

        private readonly ServiceProvider _serviceProvider;

        private IList<Destination> _destinations;

        public JobLoggerTest(IOCFixture iOCFixture)
        {
            _serviceProvider = iOCFixture.ServiceProvider;
            _jobLogger = (JobLogger)_serviceProvider.GetService(typeof(IJobLogger));
        }

        [Fact]
        public void JobLoggerBasicTest()
        {
            string logMessage = "****** Test log ******";

            _destinations = new List<Destination>() { Destination.Console, Destination.File };

            _jobLogger.LogMessage(_destinations, LogType.Error, $"Error - {logMessage}");

            _jobLogger.LogMessage(_destinations, LogType.Message, $"Message - {logMessage}");

            _jobLogger.LogMessage(_destinations, LogType.Warning, $"Warning - {logMessage}");

            Assert.True(true);
        }

        [Fact]
        public void JobLoggerMessageEmptyTest()
        {
            _destinations = new List<Destination>() { Destination.Console };

            Assert.Throws<Exception>(() => _jobLogger.LogMessage(_destinations, LogType.Error, string.Empty));
        }
    }
}