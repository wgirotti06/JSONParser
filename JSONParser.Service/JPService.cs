using JSONParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParser.Data
{
    public class JPService
    {
        public void SumLabeledIds(container container)
        {
            container.menu.items.RemoveAll(x => x == null);
            container.sum = container.menu.items.Any() ? container.menu.items.Where(x => !string.IsNullOrEmpty(x.label)).Sum(x => x.id) : 0;
        }
    }
}
