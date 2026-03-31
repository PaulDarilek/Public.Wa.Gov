namespace Hrms.Public.Converters
{

    /// <summary>Used to Implment COBOL like numeric fields with Leading/Trailing separate positive/negative signs</summary>
    public enum Sign
    {
        /// <summary>No Sign Character</summary>
        None = 0,
        
        /// <summary>Sign Leading Separate</summary>
        LeadingSeparate = 1,

        /// <summary>Sign Trailing Separate</summary>
        TrailingSeparate = 2
    }
}
