using System.Runtime.Serialization;

namespace retailpricechecker.Models
{
    [DataContract]
    public class PriceDto 
    {
        [DataMember(Name = "type")]
        public string? Type { get; set; }

        [DataMember(Name = "priceGroupCode")]
        public string? PriceGroupCode { get; set; }

        [DataMember(Name = "price")]
        public decimal? Price { get; set; }

        [DataMember(Name = "priorPrice")]
        public decimal? PriorPrice { get; set; }

        [DataMember(Name = "effectiveFromDateTime")]
        public string? EffectiveFromDateTime { get; set; }

        [DataMember(Name = "effectiveToDateTime")]
        public string? EffectiveToDateTime { get; set; }
    }
}
