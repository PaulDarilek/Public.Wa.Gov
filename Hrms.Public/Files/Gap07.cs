using System.Collections.Generic;

namespace Hrms.Public.Files
{
    public class Gap07
    {
        public Gap07Header Header { get; set; }
        public List<Gap07Detail> Details { get; set; } = new List<Gap07Detail>();

        public Gap07()
        {
            Details = Details ?? new List<Gap07Detail>();
        }

        public Gap07(IEnumerable<Gap07Detail> details)
        {
            Details = new List<Gap07Detail>(details);
            Header = new Gap07Header(details);
        }

    }
}
