// Application/Responses/BaseCommandResponse.cs
using System.Collections.Generic;

namespace Application.Responses
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public List<string>? ValidationErrors { get; set; }
        
    }
}