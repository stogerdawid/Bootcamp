using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartApp.Messages
{
    public class RemoveSeries
    {
        public RemoveSeries(string seriesName)
        {
            SeriesName = seriesName;
        }

        public string SeriesName { get; private set; }
    }
}
