using System;

namespace ParametricRollTopTier
{

    public class RollEstimatorInput
    {
        /// <summary>
        /// Vessel length in [meter]				
        /// </summary>
        public double Lwl;

       
        /// <summary>
        /// Roll period in [seconds]								
        /// </summary>
        public double RollPeriod;


        /// <summary>
        /// Uncertainty in roll or wave period [seconds]												
        /// </summary>
        public double Uncertainty;


        /// <summary>
        /// Vessel speed in [knots]															
        /// </summary>
        public double VesselSpeed;


        /// <summary>
        /// Course of ship in [degrees]																			
        /// </summary>
        public double ShipCourse;


        /// <summary>
        /// Wave direction in [degrees]																		
        /// </summary>
        public double WaveDirection;


        /// <summary>
        /// Mean wave period in [seconds] or enter																			
        /// </summary>
        public double? MeanWavePeriod;


        /// <summary>
        /// Sensitivity																			
        /// </summary>
        public double Sensitivity;


        /// <summary>
        /// Wave encounter period in [seconds] and																							
        /// </summary>
        public double?  WaveEncounterPeriod;


        /// <summary>
        /// Effective wave length in [meter]																							
        /// </summary>
        public double? EffectiveWaveLength;


        


    }
}    
