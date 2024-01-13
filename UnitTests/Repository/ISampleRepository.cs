using UnitTests.Model;

namespace UnitTests.Repository
{
    public interface ISampleRepository
    {
        Sample GetSampleById(int sampleId);
    }
}