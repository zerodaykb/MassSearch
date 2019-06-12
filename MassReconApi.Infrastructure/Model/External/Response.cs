using System.Collections.Generic;

namespace MassReconApi.Infrastucture.Model
{
    public class Response
    {
        public IEnumerable<ResponseItem> Matches { get; set; }
        public int Total { get; set; }
    }
}