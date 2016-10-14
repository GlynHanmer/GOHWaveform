namespace GOHWaveformTests
{
    interface WaveformTests
    {
        void Constructor_ThrowsArgumentOutOfRangeException_ForNegativeDutyCycle();
        void Constructor_ThrowsArgumentOutOfRangeException_ForDutyCycleGreatherThan1();
        void Value_ReturnsDouble();
        void Value_ReturnsKnownValues_ForKnownPhases();
        void Value_ReturnsKnownResults_ForKnownPhases_BeforeAndAfterSetDutyCycle();
    }
}
