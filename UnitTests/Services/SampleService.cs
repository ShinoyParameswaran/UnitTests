using UnitTests.Model;
using UnitTests.Repository;

namespace UnitTests.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public SampleResult ProcessSampleData(int sampleId)
        {
            var sample = _sampleRepository.GetSampleById(sampleId);

            if (sample == null)
            {
                return new SampleResult { Message = "Sample not found", Success = false };
            }

            // Perform some complex business logic based on the sample data
            if (sample.IsSpecial)
            {
                // Special processing logic
                return new SampleResult { Message = "Special sample processed", Success = true };
            }
            else if (sample.Quantity > 10)
            {
                // Other processing logic
                return new SampleResult { Message = "Sample processed with quantity greater than 10", Success = true };
            }
            else
            {
                // Default processing logic
                return new SampleResult { Message = "Default sample processing", Success = true };
            }
        }
    }

}
