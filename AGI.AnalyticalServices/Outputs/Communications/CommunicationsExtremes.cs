using System.Collections.Generic;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Communications
{
    public class CommunicationsExtremes
    {
        public CommunicationsExtremes(Dictionary<LinkBudgetType, ExtremesInfo> extremes)
        {
            TransmitterAntennaGainInLinkDirectionExtremes = extremes[LinkBudgetType.TransmitterAntennaGainInLinkDirection];
            ReceiverAntennaGainInLinkDirectionExtremes = extremes[LinkBudgetType.ReceiverAntennaGainInLinkDirection];
            BitErrorRateExtremes = extremes[LinkBudgetType.BitErrorRate];
            CarrierToInterferenceExtremes = extremes[LinkBudgetType.CarrierToInterference];
            CarrierToNoiseExtremes = extremes[LinkBudgetType.CarrierToNoise];
            CarrierToNoiseDensityExtremes = extremes[LinkBudgetType.CarrierToNoiseDensity];
            CarrierToNoisePlusInterferenceExtremes = extremes[LinkBudgetType.CarrierToNoisePlusInterference];
            EffectiveIsotropicRadiatedPowerExtremes = extremes[LinkBudgetType.EffectiveIsotropicRadiatedPower];
            EnergyPerBitToNoiseDensityExtremes = extremes[LinkBudgetType.EnergyPerBitToNoiseDensity];
            PowerAtReceiverOutputExtremes = extremes[LinkBudgetType.PowerAtReceiverOutput];
            PropagationLossExtremes = extremes[LinkBudgetType.PropagationLoss];
            ReceivedIsotropicPowerExtremes = extremes[LinkBudgetType.ReceivedIsotropicPower];
            ReceivedPowerFluxDensityExtremes = extremes[LinkBudgetType.ReceivedPowerFluxDensity];
        }

        public ExtremesInfo TransmitterAntennaGainInLinkDirectionExtremes { get; set; }
        public ExtremesInfo ReceiverAntennaGainInLinkDirectionExtremes { get; set; }
        public ExtremesInfo BitErrorRateExtremes { get; set; }
        public ExtremesInfo CarrierToInterferenceExtremes { get; set; }
        public ExtremesInfo CarrierToNoiseExtremes { get; set; }
        public ExtremesInfo CarrierToNoiseDensityExtremes { get; set; }
        public ExtremesInfo CarrierToNoisePlusInterferenceExtremes { get; set; }
        public ExtremesInfo EffectiveIsotropicRadiatedPowerExtremes { get; set; }
        public ExtremesInfo EnergyPerBitToNoiseDensityExtremes { get; set; }
        public ExtremesInfo PowerAtReceiverOutputExtremes { get; set; }
        public ExtremesInfo PropagationLossExtremes { get; set; }
        public ExtremesInfo ReceivedIsotropicPowerExtremes { get; set; }
        public ExtremesInfo ReceivedPowerFluxDensityExtremes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
