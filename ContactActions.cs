using System.Collections;
using System.Collections.Generic;
namespace PhoneBook
{
    class ContactActions
    {
        List<Contact> contacts = [
            new Contact("Kayhan", "İpek", "5553332211"),
            new Contact("Ebru", "Demir", "5553334455"),
            new Contact("Burhan", "Toprak", "5553335566"),
            new Contact("Murat", "Günay", "5553336677"),
            new Contact("Ayşe", "Şen", "5553337788"),
        ];
        public void Save()
        {
            Console.Write("Lütfen isim giriniz             : ");
            string name = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz          : ");
            string surname = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz : ");
            string number = Console.ReadLine();
            Contact contact = new Contact(name, surname, number);
            contacts.Add(contact);
            Console.WriteLine("Kişi eklendi.");
            Menu.Show();
        }
        public void Delete()
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string query = Console.ReadLine().ToLower();
            foreach (var contact in contacts)
            {
                if (contact.Name.ToLower() == query || contact.Surname.ToLower() == query)
                {
                    Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", contact.Name);
                    string answer = Console.ReadLine().ToLower(); ;
                    if (answer == "y")
                    {
                        contacts.Remove(contact);
                        Console.WriteLine("Kişi silindi.");
                        break;
                    }
                    else
                        Menu.Show();

                }
            }
            Menu.Show();
        }
        public void ShowAllContacts()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*******************************************");
            Console.WriteLine("Kişilerin sıralanma türünü seçininiz.\n(1) A-Z\n(2) Z-A");
            string answer = Console.ReadLine();
            Console.WriteLine("*******************************************");
            if (answer == "1")
            {
                foreach (var contact in contacts.OrderBy(i => i.Name))
                {
                    Console.WriteLine("isim: {0} Soyisim: {1} Telefon Numarası: {2}", contact.Name, contact.Surname, contact.Number);
                }
            }
            else if (answer == "2")
            {
                foreach (var contact in contacts.OrderByDescending(i => i.Name))
                {
                    Console.WriteLine("isim: {0} Soyisim: {1} Telefon Numarası: {2}", contact.Name, contact.Surname, contact.Number);
                }
            }
            else
            {
                Menu.Show();
            }
            Console.WriteLine("*******************************************");
            Menu.Show();
        }
        public void Update()
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string query = Console.ReadLine().ToLower();
            foreach (var contact in contacts)
            {
                if (contact.Name.ToLower() == query || contact.Surname.ToLower() == query)
                {
                    Console.Write("Yeni telefon numarası: ");
                    string newNumber = Console.ReadLine();
                    contact.Number = newNumber;
                    Console.WriteLine("Kişi bilgileri başarıyla güncellendi.");
                    Menu.Show();
                }
                else
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("* Yeniden denemek için              : (2)");

                    string selection = Console.ReadLine();
                    if (selection == "1")
                        Menu.Show();
                    else if (selection == "2")
                        Update();
                    else
                    {
                        Console.WriteLine("Hatalı seçim yaptınız, ana menüye dönülüyor.");
                        Menu.Show();
                    }
                }
            }

        }
        public void SearchBy()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n **********************************************\nİsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");
            bool check = int.TryParse(Console.ReadLine(), out int selection);
            switch (selection)
            {
                case 1:
                    SearchByNameOrSurname();
                    break;
                case 2:
                    SearchByNumber();
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız, ana menüye dönülüyor.");
                    Menu.Show();
                    break;
            }
        }
        public void SearchByNameOrSurname()
        {
            Console.Write("Arama yapmak istediğiniz kişinin ismi yada soyismi: ");
            string query = Console.ReadLine().ToLower();
            foreach (var contact in contacts)
            {
                if (query == contact.Name.ToLower() || query == contact.Surname.ToLower())
                {
                    Console.WriteLine("isim: {0} Soyisim: {1} Telefon Numarası: {2}", contact.Name, contact.Surname, contact.Number);
                }
                else
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("* Yeniden denemek için              : (2)");

                    string selection = Console.ReadLine();
                    if (selection == "1")
                        Menu.Show();
                    else if (selection == "2")
                        SearchByNameOrSurname();
                    else
                    {
                        Console.WriteLine("Hatalı seçim yaptınız, ana menüye dönülüyor.");
                        Menu.Show();
                    }
                }

            }
        }
        public void SearchByNumber()
        {
            Console.Write("Arama yapmak istediğiniz kişinin telefon numarası: ");
            string query = Console.ReadLine().ToLower();
            foreach (var contact in contacts)
            {
                if (query == contact.Number)
                {
                    Console.WriteLine("isim: {0} Soyisim: {1} Telefon Numarası: {2}", contact.Name, contact.Surname, contact.Number);
                }
                else
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("* Yeniden denemek için              : (2)");

                    string selection = Console.ReadLine();
                    if (selection == "1")
                        Menu.Show();
                    else if (selection == "2")
                        SearchByNumber();
                    else
                    {
                        Console.WriteLine("Hatalı seçim yaptınız, ana menüye dönülüyor.");
                        Menu.Show();
                    }
                }

            }

        }
    }
}