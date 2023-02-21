using Macs3.Modules.Lash.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParametricRollTopTier
{
    public class FollowingSeasParametricRollEstimator : ICalculator<RollEstimatorInput, FollowingSeasParametricRollEstimatorOutput>

    {
        public FollowingSeasParametricRollEstimatorOutput Calculate(in RollEstimatorInput input)
        {

            FollowingSeasParametricRollEstimatorOutput output = new FollowingSeasParametricRollEstimatorOutput();
            if (input == null) { throw new ArgumentNullException("input"); }

            var shipFixedWaveDirection = TopTierHelpers.GetShipFixedWaveDirection(input);

            var parametricRollEstimator = new ParametricRollEstimator();
            var parametricRollEstimatorOutput = parametricRollEstimator.Calculate(input);
            output.LambdaRatioLAround1 = parametricRollEstimatorOutput.LambdaRatioLAround1;

            output.TPhiRatioTeAround2 = parametricRollEstimatorOutput.TPhiRatioTeAround2;

            output.CloseTo180deg = (shipFixedWaveDirection >= 120);


            return output;

        }

    }
}       
     
    




