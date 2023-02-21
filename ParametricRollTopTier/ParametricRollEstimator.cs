using Macs3.Modules.Lash.Abstractions.Core;
using System;

namespace ParametricRollTopTier
{
    public class ParametricRollEstimator : ICalculator<RollEstimatorInput,ParametricRollEstimatorOutput>

    {
        public ParametricRollEstimatorOutput Calculate(in RollEstimatorInput input)
        {
            ParametricRollEstimatorOutput output = new ParametricRollEstimatorOutput();
            if (input == null) { throw new ArgumentNullException("input"); }

            var shipFixedWaveDirection = TopTierHelpers.GetShipFixedWaveDirection(input);
            var waveEncounterPeriod = TopTierHelpers.GetWaveEncaunterPeriod(input, shipFixedWaveDirection);
            var (lowerTPhiRatioTe, upperTPhiRatioTe) = TopTierHelpers.GetTPhiRatios(input, waveEncounterPeriod);

            output.TPhiRatioTeAround2 = (lowerTPhiRatioTe >= 2 && upperTPhiRatioTe <= 2);

            var effectiveWaveLength = TopTierHelpers.GetEffectiveWaveLength(input, shipFixedWaveDirection);
            var waveLengthOrShipLengthRatio = TopTierHelpers.GetWaveLengthOrShipLengthRatio(input, effectiveWaveLength);


            output.LambdaRatioLAround1 = (waveLengthOrShipLengthRatio >= 0.5 && waveLengthOrShipLengthRatio <= 2);


            


            return output;

        }
    }
}
