using ConsoleApp3.Solutions.Task1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            var expected = "moc.hcramnemreb@yrehcanemb";
            var ft = new Solution1();

            // act
            var res = ft.ReverseString("bmenachery@bermenmarch.com");

            // assert
            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            string? expected = null;
            var ft = new Solution1();

            // act
            var res = ft.ReverseString("");

            // assert
            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void TestMethod3()
        {
            // arrange
            string? expected = "мике@#";
            var ft = new Solution1();

            // act
            var res = ft.ReverseString("#@еким");

            // assert
            Assert.AreEqual(expected, res);
        }
        [TestMethod]
        public void TestMethod4()
        {
            // arrange
            string? expected = string.Empty;
            var ft = new Solution1();

            // act
            var res = ft.ReverseString("");

            // assert
            Assert.AreNotSame(expected, res);
        }
    }
}