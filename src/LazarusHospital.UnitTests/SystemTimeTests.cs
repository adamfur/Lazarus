using System;
using Xunit;

namespace LazarusHospital
{
    [Collection("MockTime")]
    public class SystemTimeTests
    {
        [Fact]
        public void Now_is_injectable()
        {
            // Arrange
            var timestamp = new DateTime(2000, 1, 2, 3, 4, 5);
            
            SystemTimeMock.SetTimeDelegate(() => timestamp);

            // Act
            var result = SystemTime.Now;
            
            // Assert
            Assert.Equal(timestamp, result);
        }
    }
}