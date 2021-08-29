namespace ContactsApp.DAL.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
