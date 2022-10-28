namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string CommonNamespace = "Common";
        private const string WebUINamespace = "WebUI";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {

        }
    }
}