using System.Collections.Generic;

namespace MassReconApi.Infrastucture.Model
{
    public class CensysResponse
    {
        public IEnumerable<CensysResponseItem> Results { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public int Count { get; set; }
        public string Query { get; set; }
    }
}