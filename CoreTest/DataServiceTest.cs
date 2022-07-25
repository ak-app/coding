namespace CoreTest
{
    public class DataServiceTest
    {
        [Fact]
        public void CreateConstructor_Passing()
        {
            FakeDataService data = new();

            Assert.NotNull(data);
            Assert.True(data.Get().Count == 2);
        }
    }
}