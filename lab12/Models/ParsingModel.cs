using Microsoft.AspNetCore.Mvc;

namespace Parsing.Models
{
    public class ParsingModel
    {
        public int Operand1 { get; set; }
        public string? Operator { get; set; }
        public int Operand2 { get; set; }
    }
}

