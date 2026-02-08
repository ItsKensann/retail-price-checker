using System.Runtime.Serialization;

namespace retailpricechecker.Models
{
    [DataContract]
    public class RetailPricingDto
    {
        [DataMember(Name = "Id")]
        public required string Id { get; set; }

        [DataMember(Name = "locationId")]
        public string? LocationId { get; set; }

        [DataMember(Name = "region")]
        public string? Region { get; set; }

        [DataMember(Name = "channel")]
        public string? Channel { get; set; }

        [DataMember(Name = "style")]
        public string? Style { get; set; }

        [DataMember(Name = "color")]
        public string? Color { get; set; }

        [DataMember(Name = "size")]
        public string? Size { get; set; }

        [DataMember(Name = "dimension")]
        public string? Dimension { get; set; }

        [DataMember(Name = "upc")]
        public string? UPC { get; set; }

        [DataMember(Name = "prices")]
        public PriceDto[]? Prices { get; set; }

        [DataMember(Name = "promotions")]
        public PromotionDto[]? Promotions { get; set; }

        [DataMember(Name = "discounts")]
        public DiscountDto[]? Discounts { get; set; }

        [DataMember(Name = "eventType")]
        public string? EventType { get; set; }
    }
}
