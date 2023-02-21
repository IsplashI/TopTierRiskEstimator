using System;
using Macs3.Modules.Lash.Abstractions.Core;

namespace ParametricRollTopTier
{
    public class ResonantRollEstimator : ICalculator<RollEstimatorInput, ResonantRollEstimatorOutput>

    {
        public ResonantRollEstimatorOutput Calculate(in RollEstimatorInput input)
        {
            ResonantRollEstimatorOutput output = new ResonantRollEstimatorOutput();
            if (input == null) { throw new ArgumentNullException("input"); }
            double shipFixedWaveDirection = TopTierHelpers.GetShipFixedWaveDirection(input);
            double waveEncounterPeriod = TopTierHelpers.GetWaveEncaunterPeriod(input, shipFixedWaveDirection);
            var (lowerTPhiRatioTe, upperTPhiRatioTe) = TopTierHelpers.GetTPhiRatios(input, waveEncounterPeriod);
            output.TPhiRatioTeAround1 = (lowerTPhiRatioTe >= 1 && upperTPhiRatioTe <= 1);
            double effectiveWaveLength = TopTierHelpers.GetEffectiveWaveLength(input, shipFixedWaveDirection);
            double waveLengthOrShipLengthRatio = TopTierHelpers.GetWaveLengthOrShipLengthRatio(input, effectiveWaveLength);
            output.LambdaRatioLGreaterThan033 = waveLengthOrShipLengthRatio >= 1 / 3;
            return output;

        }




    }
}
