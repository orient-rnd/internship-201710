using Interns2.AppServices.FlashCard.ExternalApis;
using Xunit;

namespace UnitTestProject1
{    
    public class UnitTest1
    {
        private BlogspotApis blogspotApis;
        public UnitTest1()
        {
            blogspotApis = new BlogspotApis();
        }
        [Fact]
        public void TestMethod1()
        {
            blogspotApis.Abc();

            Xunit.Assert.False(false, "1 should not be prime");
        }
    }
}
