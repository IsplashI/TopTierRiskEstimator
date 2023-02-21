using ParametricRollTopTier;


var input = new RollEstimatorInput()
{
    Lwl = 310,
    RollPeriod = 40,
    Uncertainty = 3,
    VesselSpeed = 15,
    ShipCourse = 120,
    WaveDirection = 300,
    MeanWavePeriod = 10,
    Sensitivity = 0.3, 
    WaveEncounterPeriod = 20.6,
    EffectiveWaveLength = 224


    
    

};
try
{


    var resonantRollEstimator = new ResonantRollEstimator();
    var ResonantRollRisk = resonantRollEstimator.Calculate(input);
    Console.WriteLine("Resonant Roll Risk:");
    Console.WriteLine(ResonantRollRisk.TPhiRatioTeAround1);
    Console.WriteLine(ResonantRollRisk.LambdaRatioLGreaterThan033);


    var headSeasParametricRollEstimator = new HeadSeasParametricRollEstimator();
    var headSeasParametricRollRisk = headSeasParametricRollEstimator.Calculate(input);
    Console.WriteLine("Head Seas Parametric Roll Risk:");
    Console.WriteLine(headSeasParametricRollRisk.TPhiRatioTeAround2);
    Console.WriteLine(headSeasParametricRollRisk.LambdaRatioLAround1);
    Console.WriteLine(headSeasParametricRollRisk.CloseTo0deg);



    var followingSeasParametricRollEstimator = new FollowingSeasParametricRollEstimator();
    var followingSeasParametricRollRisk =  followingSeasParametricRollEstimator.Calculate(input);
    Console.WriteLine("Following Seas Parametric Roll Risk:");
    Console.WriteLine(followingSeasParametricRollRisk.TPhiRatioTeAround2);
    Console.WriteLine(followingSeasParametricRollRisk.LambdaRatioLAround1);
    Console.WriteLine(followingSeasParametricRollRisk.CloseTo180deg);




}
catch(Exception e)
{
    Console.WriteLine(e);
}
Console.ReadLine();
