using System.Collections.Generic;

namespace Hrms.Public.Files
{
    public class Gap01
    {
        public Gap01Header Header { get; set; } 
        public List<Gap01Detail> Details { get; set; } = new List<Gap01Detail>();

        public Gap01()
        {

        }
        public Gap01(IEnumerable<Gap01Detail> details)
        {
            Details = new List<Gap01Detail>(details);
            Header = new Gap01Header(details);
        }

    }
}
