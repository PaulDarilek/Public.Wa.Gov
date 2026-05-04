using System;

namespace Hrms.Public.Converters
{
    /// <summary>Specification for a field in a Fixed Position Layout</summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class FieldSpecAttribute : Attribute
    {
        public int Length { get; set; }
        public int StartPosition { get; set; }
        public string Notes { get; set; }

        public FieldSpecAttribute(int length, int startPosition, string notes = "")
        {
            Length = length;
            StartPosition = startPosition;
            Notes = notes;
        }
    }
}
