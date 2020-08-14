namespace CovidInfo.Models
{
    public class Estado
    {
        public string Id { get; set; }
        public string Uf { get; set; }
        public string State { get; set; }
        public string Cases { get; set; }
        public string Deaths { get; set; }
        public string Suspects {get;set;}
        public string Refuses{get; set;}
    }
}