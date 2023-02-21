namespace Macs3.Modules.Lash.Abstractions.Core
{
    public interface ICalculator<TInput, out Toutput>
    {
        Toutput Calculate(in TInput input);
    }
}
