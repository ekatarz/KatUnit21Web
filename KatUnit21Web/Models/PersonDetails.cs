namespace KatUnit21Web.Models
{
    public class PersonDetails
    {
        public string MemberId { get; set; }
        public string House { get; set; }
        public string Constituency { get; set; }
        public string Party { get; set; }
        public DateTime EnteredHouse { get; set; }
        public DateTime LeftHouse { get; set; }
        public string EnteredReason { get; set; }
        public string LeftReason { get; set; }
        public string PersonId { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Title { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
    }

}