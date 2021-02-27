namespace MyProgram
{
    public interface IGearCalculator
    {
        Gear CalculateGear(RPM currentRpm, Gear currentGear);
    }
}