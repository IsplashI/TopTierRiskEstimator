using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ParametricRollTopTier;

namespace ParametricRollUnitTest
{
    [TestClass]
    public class UnitTestRollingRisk
    {
        //Sea Reference Files In Excel Folder

        [DataTestMethod]

        [DataRow(310.0, 40.0, 3.0, 15.0, 120.0, 300.0, 10.0, 0.3, null, null, false, true, true, true, false, true, true, true)] // Risk of Parametric Rolling in Following Seas 1
        [DataRow(310.0, 40.0, 3.0, 15.0, 120.0, 300.0, null, 0.3, 20.6, 224.0, false, true, true, true, false, true, true, true)]// Risk of Parametric Rolling in Following Seas 1.1
        
        [DataRow(310.0, 40.0, 3.0, 25.0, 120.0, 300.0, 10.0, 0.3, null, null, true, true, false, true, false, false, true, true)]// Risk of Resonant Rolling 1
        [DataRow(310.0, 40.0, 3.0, 25.0, 120.0, 300.0, null, 0.3, 39.4, 224.0, true, true, false, true, false, false, true, true)]// Risk of Resonant Rolling 1.1
        
        [DataRow(310.0, 40.0, 3.0, 20.0, 120.0, 300.0, 10.0, 0.3, null, null, false, true, false, true, false, false, true, true)]// No Risk 1
        [DataRow(310.0, 40.0, 3.0, 20.0, 120.0, 300.0, null, 0.3, 27.0, 224.0, false, true, false, true, false, false, true, true)]// No Risk 1.1
        
        [DataRow(310.0, 40.0, 3.0, 15.0, 180.0, 300.0, 10.0, 0.3, null, null, false, true, false, true, false, false, true, true)]// No Risk 2
        [DataRow(310.0, 40.0, 3.0, 15.0, 180.0, 300.0, null, 0.3, 15.1, 448.0, false, true, false, true, false, false, true, true)]// No Risk 2.1
        
        [DataRow(310.0, 30.0, 3.0, 15.0, 120.0, 300.0, 15.0, 0.3, null, null, true, true, false, true, false, false, true, true)]// Risk of Resonant Rolling 2
        [DataRow(310.0, 30.0, 3.0, 15.0, 120.0, 300.0, null, 0.3, 24.9, 504.0, true, true, false, true, false, false, true, true)]// Risk of Resonant Rolling 2.1
        
        [DataRow(310.0, 40.0, 3.0, 5.0, 120.0, 300.0, 10.0, 0.3, null, null, false, true, false, true, false, false, true, true)]// No Risk 3
        [DataRow(310.0, 40.0, 3.0, 5.0, 120.0, 300.0, null, 0.3, 13.9, 224.0, false, true, false, true, false, false, true, true)]// No Risk 3.1
        
        [DataRow(310.0, 40.0, 3.0, 15.0, 181.0, 300.0, 10.0, 0.3, null, null, false, true, false, true, false, false, true, false)] // No Risk 4
        [DataRow(310.0, 40.0, 3.0, 15.0, 181.0, 300.0, null, 0.3, 15.0, 462.0, false, true, false, true, false, false, true, false)] // No Risk 4.1
        
        [DataRow(310.0, 20.0, 3.0, 20.0, 240.0, 300.0, 10.0, 0.3, null, null, false, true, true, true, true, true, true, false)]// Risk of Parametric Rolling in Head Seas 1
        [DataRow(310.0, 20.0, 3.0, 20.0, 240.0, 300.0, null, 0.3, 9.4, 448.0, false, true, true, true, true, true, true, false)]// Risk of Parametric Rolling in Head Seas 1.1
        
























        public void TestMethod(double Lwl,double RollPeriod, double Uncertainty, double VesselSpeed, double ShipCourse, double WaveDirection, double? MeanWavePeriod, double Sensitivity, 
            double? WaveEncounterPeriod, double? EffectiveWaveLength,  bool expectedTPhiRatioTeAround1, bool expectedLambdaRatioLGreaterThan033, bool expectedHeadSeaTPhiRatioTeAround2,
            bool expectedHeadSeaLambdaRatioLAround1, bool expectedCloseTo0deg, bool expectedFollowingSeaTPhiRatioTeAround2, bool expectedFollowingSeaLambdaRatioLAround1, bool expectedCloseTo180deg)
        {
            var input = new RollEstimatorInput()
            {
                Lwl = Lwl,
                RollPeriod = RollPeriod,
                Uncertainty = Uncertainty,
                VesselSpeed = VesselSpeed,
                ShipCourse = ShipCourse,
                WaveDirection = WaveDirection,
                MeanWavePeriod = MeanWavePeriod,
                Sensitivity = Sensitivity,
                WaveEncounterPeriod = WaveEncounterPeriod,
                EffectiveWaveLength = EffectiveWaveLength
            };
            var resonantRollEstimator = new ResonantRollEstimator();
            var ResonantRollRisk = resonantRollEstimator.Calculate(input);

            var headSeasParametricRollEstimator = new HeadSeasParametricRollEstimator();
            var HeadSeasParametricRollRisk = headSeasParametricRollEstimator.Calculate(input);

            var followingSeasParametricRollEstimator = new FollowingSeasParametricRollEstimator();
            var FollowingSeasParametricRollRisk = followingSeasParametricRollEstimator.Calculate(input);

            Assert.AreEqual(expectedTPhiRatioTeAround1, ResonantRollRisk.TPhiRatioTeAround1, "expectedTPhiRatioTeAround1:<{0}> but actualTPhiRatioTeAround1:<{1}>", new object[] { expectedTPhiRatioTeAround1, ResonantRollRisk.TPhiRatioTeAround1 });
            Assert.AreEqual(expectedLambdaRatioLGreaterThan033, ResonantRollRisk.LambdaRatioLGreaterThan033, "expectedLambdaRatioLGreaterThan033:<{0}> but actualLambdaRatioLGreaterThan033:<{1}>", new object[] { expectedLambdaRatioLGreaterThan033, ResonantRollRisk.LambdaRatioLGreaterThan033 });

            Assert.AreEqual(expectedHeadSeaTPhiRatioTeAround2, HeadSeasParametricRollRisk.TPhiRatioTeAround2, "expectedTPhiRatioTeAround2:<{0}> but actualTPhiRatioTeAround2:<{1}>", new object[] { expectedHeadSeaTPhiRatioTeAround2, HeadSeasParametricRollRisk.TPhiRatioTeAround2 });
            Assert.AreEqual(expectedHeadSeaLambdaRatioLAround1, HeadSeasParametricRollRisk.LambdaRatioLAround1, "expectedHeadSeaLambdaRatioLAround1:<{0}> but actualHeadSeaLambdaRatioLAround1:<{1}>", new object[] { expectedHeadSeaLambdaRatioLAround1, HeadSeasParametricRollRisk.LambdaRatioLAround1 });
            Assert.AreEqual(expectedCloseTo0deg, HeadSeasParametricRollRisk.CloseTo0deg, "expectedCloseTo0deg:<{0}> but actualCloseTo0deg:<{1}>", new object[] { expectedCloseTo0deg, HeadSeasParametricRollRisk.CloseTo0deg });

            Assert.AreEqual(expectedFollowingSeaTPhiRatioTeAround2, FollowingSeasParametricRollRisk.TPhiRatioTeAround2, "expectedFollowingSeaTPhiRatioTeAround2:<{0}> but actualFollowingSeaTPhiRatioTeAround2:<{1}>", new object[] { expectedFollowingSeaTPhiRatioTeAround2, FollowingSeasParametricRollRisk.TPhiRatioTeAround2 });
            Assert.AreEqual(expectedFollowingSeaLambdaRatioLAround1, FollowingSeasParametricRollRisk.LambdaRatioLAround1, "expectedFollowingSeaLambdaRatioLAround1:<{0}> but actualFollowingSeaLambdaRatioLAround1:<{1}>", new object[] { expectedFollowingSeaLambdaRatioLAround1, FollowingSeasParametricRollRisk.LambdaRatioLAround1 });
            Assert.AreEqual(expectedCloseTo180deg, FollowingSeasParametricRollRisk.CloseTo180deg, "expectedCloseTo180deg:<{0}> but actualCloseTo180deg:<{1}>", new object[] { expectedCloseTo180deg, FollowingSeasParametricRollRisk.CloseTo180deg });


            
           
        }
    }
}
