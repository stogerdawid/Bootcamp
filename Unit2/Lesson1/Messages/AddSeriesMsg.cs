using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lesson4.Messages
{
    public class AddSeriesMsg
    {
        public AddSeriesMsg(Series series)
        {
            Series = series;
        }

        public Series Series { get; private set; }
    }
}
