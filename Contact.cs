namespace PhoneBook
{
    public class Contact
    {
        private string name;
        private string surname;
        private string number;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Number { get => number; set => number = value; }
        public Contact(string name, string surname, string number)
        {
            this.name = name;
            this.surname = surname;
            this.number = number;
        }
    }
}