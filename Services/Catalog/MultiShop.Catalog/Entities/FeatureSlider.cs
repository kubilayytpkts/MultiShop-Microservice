using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderID { get; set; }
        public string SliderTitle { get; set; }
        public string SliderDescription { get; set; }
        public string SliderImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
