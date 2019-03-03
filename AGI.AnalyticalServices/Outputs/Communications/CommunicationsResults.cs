using System;
using System.Collections.Generic;
using AGI.AnalyticalServices.Inputs.Communications;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Communications
{
    public class CommunicationsResults: CommunicationsExtremes
    {
        public LinkBudgetResultAllWithLocation[] LinkBudgets { get; }

        public CommunicationsResults(CalculatedCommData libraryAccuracyResults, 
            Dictionary<LinkBudgetType,ExtremesInfo> extremes, OutputUnit units) :base(extremes)
        {
            List<LinkBudgetResultAllWithLocation> commLbs = new List<LinkBudgetResultAllWithLocation>();
            for (int i = 0; i < libraryAccuracyResults.Dates.Count; i++)
            {
                LinkBudgetResultAllWithLocation lbr = null;
                if (units == OutputUnit.Watts)
                {
                   lbr  = new LinkBudgetResultAllWithLocation(
                            libraryAccuracyResults.Series[LinkBudgetType.TransmitterAntennaGainInLinkDirection][i],
                            libraryAccuracyResults.Series[LinkBudgetType.ReceiverAntennaGainInLinkDirection][i],
                            libraryAccuracyResults.Series[LinkBudgetType.BitErrorRate][i],
                            libraryAccuracyResults.Series[LinkBudgetType.CarrierToInterference][i],
                            libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoise][i],
                            libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoiseDensity][i],
                            libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoisePlusInterference][i],
                            libraryAccuracyResults.Series[LinkBudgetType.EffectiveIsotropicRadiatedPower][i],
                            libraryAccuracyResults.Series[LinkBudgetType.EnergyPerBitToNoiseDensity][i],
                            libraryAccuracyResults.Series[LinkBudgetType.PowerAtReceiverOutput][i],
                            libraryAccuracyResults.Series[LinkBudgetType.PropagationLoss][i],
                            libraryAccuracyResults.Series[LinkBudgetType.ReceivedIsotropicPower][i],
                            libraryAccuracyResults.Series[LinkBudgetType.ReceivedPowerFluxDensity][i],
                            libraryAccuracyResults.Dates[i],
                            libraryAccuracyResults.Positions[i]);
                }
                else if (units == OutputUnit.Decibels)
                {
                    lbr = new LinkBudgetResultAllWithLocation(
                        libraryAccuracyResults.Series[LinkBudgetType.TransmitterAntennaGainInLinkDirection][i],
                        libraryAccuracyResults.Series[LinkBudgetType.ReceiverAntennaGainInLinkDirection][i],
                        libraryAccuracyResults.Series[LinkBudgetType.BitErrorRate][i],
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.CarrierToInterference][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoise][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoiseDensity][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.CarrierToNoisePlusInterference][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.EffectiveIsotropicRadiatedPower][i]),
                        libraryAccuracyResults.Series[LinkBudgetType.EnergyPerBitToNoiseDensity][i],
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.PowerAtReceiverOutput][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.PropagationLoss][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.ReceivedIsotropicPower][i]),
                        ToDecibels(libraryAccuracyResults.Series[LinkBudgetType.ReceivedPowerFluxDensity][i]),
                        libraryAccuracyResults.Dates[i],
                        libraryAccuracyResults.Positions[i]);
                }
                

                commLbs.Add(lbr);
            }
            LinkBudgets = commLbs.ToArray();

        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public double ToDecibels(double linearValue) => 10.0*Math.Log10(linearValue);
        public double FromDecibels(double decibelValue) => Math.Pow(10.0,decibelValue/10.0);
    }
}
