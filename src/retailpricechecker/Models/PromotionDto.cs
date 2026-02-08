using System.Runtime.Serialization;

namespace retailpricechecker.Models
{
    [DataContract]
    public class PromotionDto
    {
        [DataMember(Name = "type")]
        public string? Type { get; set; }

        [DataMember(Name = "id")]
        public string? Id { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "amount")]
        public decimal? Amount { get; set; }

        [DataMember(Name = "currencyCode")]
        public string? CurrencyCode { get; set; }

        [DataMember(Name = "quantity")]
        public int? Quantity { get; set; }
    }
}
