using System;

namespace GOHWaveform
{
    public class TriangleWave : Waveform
    {
        private double _dutyCycle;
        public double DutyCycle
        {
            get
            {
                return _dutyCycle;
            }
            set
            {
                SetDutyCycle(value);
            }
        }
        public TriangleWave(double dutyCycle)
        {
            if (dutyCycle < 0.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleNegativeMessage);
            }
            else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleAbove1);
            }
            this._dutyCycle = dutyCycle;
        }

        public double Value(double phase)
        {
            phase %= Constants._2PI;
            if (0.0 <= phase && phase < _dutyCycle * Math.PI)
            {
                return phase / _dutyCycle / Math.PI;
            } else if (_dutyCycle * Math.PI <= phase && phase < _dutyCycle * Constants._2PI) {
                return 2.0 - phase / _dutyCycle / Math.PI;
            } else {
                return 0.0;
            }
        }

        private void SetDutyCycle(double dutyCycle)
        {
            throw new NotImplementedException();
        }
    }
}