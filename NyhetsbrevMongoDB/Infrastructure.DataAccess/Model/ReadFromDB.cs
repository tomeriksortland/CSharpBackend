using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.DataAccess.Model
{
    [BsonIgnoreExtraElements]
    public class ReadFromDB
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")] //Dette trenger man ikke gjøre om felt navn er like de feltene som ligger i mongo DB

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public string VerificationCode { get; set; }

        public ReadFromDB(ObjectId id, string name, string email, bool active, string verificationCode)
        {
            Id = id;
            Name = name;
            Email = email;
            Active = active;
            VerificationCode = verificationCode;
        }

        public ReadFromDB()
        {
            
        }

    }
}
