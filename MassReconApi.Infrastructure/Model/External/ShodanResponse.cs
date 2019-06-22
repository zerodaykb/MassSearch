using System.Collections.Generic;

namespace MassReconApi.Infrastucture.Model
{
    public class ShodanResponse
    {
        public IEnumerable<ShodanResponseItem> Matches { get; set; }
        public int Total { get; set; }
    }
}