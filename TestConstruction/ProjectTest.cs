using TestConstruction.Construction;

namespace TestConstruction
{
    public class ProjectTest
    {
        [Fact]
        public async void GetProjectView()
        {
            ProjectAPI api = new ProjectAPI();
            var response = await api.GetProject();
            Assert.Equal("projectname1", response.Name);
        }
    }
}