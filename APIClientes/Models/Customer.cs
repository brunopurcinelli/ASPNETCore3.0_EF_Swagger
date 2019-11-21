using System;

namespace APIClientes.Models
{
    public class Customer : Entity
    {
        public Customer() { }

        public Customer(Guid id, string name, string email, string address, DateTime birthday, DateTime createdDateTime)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Birthday = birthday;
            CreatedDateTime = createdDateTime;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
