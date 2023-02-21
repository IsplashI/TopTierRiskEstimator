using Macs3.Modules.Lash.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParametricRollTopTier
{
    public class HeadSeasParametricRollEstimator : ICalculator<RollEstimatorInput, HeadSeasParametricRollEstimatorOutput>

    {
        public HeadSeasParametricRollEstimatorOutput Calculate(in RollEstimatorInput input)
        {

            HeadSeasParametricRollEstimatorOutput output = new HeadSeasParametricRollEstimatorOutput();
            if (input == null) { throw new ArgumentNullException("input"); }

            var shipFixedWaveDirection = TopTierHelpers.GetShipFixedWaveDirection(input);

            var parametricRollEstimator = new ParametricRollEstimator();
            var parametricRollEstimatorOutput = parametricRollEstimator.Calculate(input);
            output.LambdaRatioLAround1 = parametricRollEstimatorOutput.LambdaRatioLAround1;

            output.TPhiRatioTeAround2 = parametricRollEstimatorOutput.TPhiRatioTeAround2;

            output.CloseTo0deg = (shipFixedWaveDirection <= 60);


            return output;

        }

    }
    
}
