using System;

namespace ParametricRollTopTier
{
    public static class TopTierHelpers
    {

        public static double GetEffectiveWaveLength(RollEstimatorInput input, double shipFixedWaveDirection)
        {
            var effectiveWaveLength = 1000.0;

            if (input.EffectiveWaveLength.HasValue)
            {
                effectiveWaveLength = input.EffectiveWaveLength.Value;

            }
            else
            {

                if (shipFixedWaveDirection < 89 || shipFixedWaveDirection > 91)
                {

                    var period = 1.198 * input.MeanWavePeriod.Value;
                    var cos = Math.Abs(Math.Cos((shipFixedWaveDirection * Math.PI) / 180));
                    effectiveWaveLength = 1.56 * period * period / cos;

                }


            }
            

            return effectiveWaveLength;
        }

        public static double GetShipFixedWaveDirection(RollEstimatorInput input)
        {
            var shipFixedWaveDirection = input.WaveDirection - input.ShipCourse;
            if (shipFixedWaveDirection < 0)
            {
                shipFixedWaveDirection = shipFixedWaveDirection + 360.0;
            }

            return shipFixedWaveDirection;
        }
        public static (double lowerTPhiRatioTe, double upperTPhiRatioTe) GetTPhiRatios(RollEstimatorInput input, double waveEncounterPeriod)
        {
            var lowerTPhi = input.RollPeriod + input.Uncertainty;
            var upperTPhi = input.RollPeriod - input.Uncertainty;
            var lowerTPhiRatioTe = lowerTPhi / waveEncounterPeriod + input.Sensitivity;
            var upperTPhiRatioTe = upperTPhi / waveEncounterPeriod - input.Sensitivity;

            return (lowerTPhiRatioTe, upperTPhiRatioTe);
        }
        public static double GetWaveEncaunterPeriod(RollEstimatorInput input, double shipFixedWaveDirection)
        {
            var waveEncounterPeriod = 0.0;

            if (input.WaveEncounterPeriod.HasValue)
            {
                waveEncounterPeriod = input.WaveEncounterPeriod.Value;

            }
            else
            {
                var period = 1.198 * input.MeanWavePeriod.Value;
                waveEncounterPeriod = 3 * period * period / (3 * period + input.VesselSpeed * Math.Cos((shipFixedWaveDirection * Math.PI) / 180));                 
            }

            return waveEncounterPeriod;
        }
        public static double GetWaveLengthOrShipLengthRatio(RollEstimatorInput input, double effectiveWaveLength)
        {          
            return effectiveWaveLength / input.Lwl;
        }
    }
}