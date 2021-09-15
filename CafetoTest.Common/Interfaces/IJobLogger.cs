using System.Collections.Generic;
using static CafetoTest.Common.Enums.DestinationEnum;
using static CafetoTest.Common.Enums.LogTypeEnum;

namespace CafetoTest.Common.Interfaces
{
    public interface IJobLogger
    {
        void LogMessage(IEnumerable<Destination> destinations, LogType type, string text);
    }
}
