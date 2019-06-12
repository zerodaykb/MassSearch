using System.Collections.Generic;

namespace MassReconApi.Contract.Dto
{
    public class ResponseDto
    {
        public string Query { get; set; }
        
        public int Quantity { get; set; }
        
        public List<ResponseItemDto> Items { get; set; }
        
    }
}