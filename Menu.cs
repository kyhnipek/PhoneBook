namespace PhoneBook
{
    public static class Menu
    {
        static ContactActions contactActions = new ContactActions();
        public static void Show()
        {

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n*******************************************\n(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncelleme\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak");
            bool check = false;
            int selection = 0;
            while (!check || selection < 1 || selection > 6)
            {
                Console.Write("işlem numarasınız giriniz: ");
                check = int.TryParse(Console.ReadLine(), out selection);
                if (!check || selection < 1 || selection > 5)
                {
                    Console.WriteLine("Geçersiz giriş!");
                    check = false;
                }
            }
            switch (selection)
            {
                case 1:
                    contactActions.Save();
                    break;
                case 2:
                    contactActions.Delete();
                    break;
                case 3:
                    contactActions.Update();
                    break;
                case 4:
                    contactActions.ShowAllContacts();
                    break;
                case 5:
                    contactActions.SearchBy();
                    break;
            }
        }
    }
}