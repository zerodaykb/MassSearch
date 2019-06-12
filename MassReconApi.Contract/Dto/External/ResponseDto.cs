using System.Collections.Generic;

namespace MassReconApi.Contract.Dto
{
    public class ResponseDto
    {
        public string SearchPhrase { get; set; }
        
        public int NumberOfItems { get; set; }
        
        public List<ResponseItemDto> ResponseItems { get; set; }
        
    }
}