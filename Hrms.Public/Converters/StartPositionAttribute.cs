using System;

namespace Hrms.Public.Converters
{
    /// <summary>Specification for a field in a Fixed Position Layout</summary>
    /// <remarks>1 based position (subtract 1 for array offset)</remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class StartPositionAttribute : Attribute
    {
        public int StartPosition { get; set; }
        public string Notes { get; set; }

        public StartPositionAttribute(int startPosition, string notes = "")
        {
            StartPosition = startPosition;
            Notes = notes;
        }
    }
}
