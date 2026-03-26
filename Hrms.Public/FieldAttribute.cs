using System;

namespace Hrms.Public
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class FieldAttribute : Attribute
    {
        public int Length { get; set; }
        public int StartPosition { get; set; }
        public string Notes { get; set; }

        public FieldAttribute(int length, int startPosition, string notes = "")
        {
            Length = length;
            StartPosition = startPosition;
            Notes = notes;
        }
    }
}
