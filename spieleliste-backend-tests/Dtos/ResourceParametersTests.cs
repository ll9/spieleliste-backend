using NUnit.Framework;
using spieleliste_backend.Dtos;

namespace spielelistebackendtests.Dtos
{
    public class ResourceParametersTests
    {
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        public void TestPageSetter(int page, int expected)
        {
            var rs = new ResourceParameters { Page = page };

            Assert.AreEqual(expected, rs.Page);
        }

        [TestCase(-1, 20)]
        [TestCase(2, 2)]
        [TestCase(50, 20)]
        public void TestPageSizeSetter(int page, int expected)
        {
            var rs = new ResourceParameters { PageSize = page };

            Assert.AreEqual(expected, rs.PageSize);
        }

        [TestCase(-1, 1, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 1, 0)]
        [TestCase(2, 10, 10)]
        [TestCase(2, 100, 20)]
        public void TestPageSizeSetter(int page, int pageSize, int expected)
        {
            var rs = new ResourceParameters { Page = page, PageSize = pageSize };

            Assert.AreEqual(expected, rs.SkipCount);
        }
    }
}