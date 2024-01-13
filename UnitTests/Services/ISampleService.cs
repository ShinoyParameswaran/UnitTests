using UnitTests.Model;

namespace UnitTests.Services
{
    public interface ISampleService
    {
        SampleResult ProcessSampleData(int sampleId);
    }
}