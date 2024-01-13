using UnitTests.Model;

namespace UnitTests.Repository
{
  
    public class SampleRepository : ISampleRepository
    {
        private readonly List<Sample> _samples;

        public SampleRepository()
        {
            // Assume some sample data for demonstration purposes
            _samples = new List<Sample>
        {
            new Sample { Id = 1, Name = "Sample1", IsSpecial = true, Quantity = 5 },
            new Sample { Id = 2, Name = "Sample2", IsSpecial = false, Quantity = 15 },
            // Add more samples as needed
        };
        }

        public Sample GetSampleById(int sampleId)
        {
            return _samples.FirstOrDefault(s => s.Id == sampleId);
        }
    }
}
