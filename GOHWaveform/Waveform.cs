using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOHWaveform
{
    interface Waveform
    {
        double Value(double phase);
    }
}
