using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class WorkingCompany
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }
        public string CompanyImage { get; set; }
    }
}
