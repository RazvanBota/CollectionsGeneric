using Xunit;
using static DelegateUssing.Delegate;

namespace DelegateUssing
{
    public class DelegateTest
    {
        [Fact]
        public void TestIfIsMatch()
        {
            Delegate person = new Delegate("Andrei", 1234);

            Match match = person.IsThisPerson;

            Assert.True(match("Andrei", 1234));
        }

        [Fact]
        public void TestForNotMatchName()
        {
            Delegate person = new Delegate("Andrei", 1234);

            Match match = person.IsThisPerson;

            Assert.False(match("Matei", 1234));
        }

        [Fact]
        public void NotMatchNumber()
        {
            Delegate person = new Delegate("Andrei", 1234);

            Match match = person.IsThisPerson;

            Assert.False(match("Andrei", 4321));
        }

        [Fact]
        public void TotalDiferentValue()
        {
            Delegate person = new Delegate("Andrei", 1234);

            Match match = person.IsThisPerson;

            Assert.False(match("Matei", 4321));
        }
    }
}
