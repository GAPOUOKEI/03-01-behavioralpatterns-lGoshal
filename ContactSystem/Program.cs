namespace ContactSystem
{
    /*
     * ФИО студента: Барсуков Владислав
     * номер варианта: 4
     * условие задачи: Создайте приложение для хранения контактов,
     *                 которое позволяет добавлять, редактировать и
     *                 удалять контакты с помощью команд, а также поддерживает
     *                 отмену этих действий.
     */
    internal class Program
    {
        private static readonly ContactManager Manager = new ContactManager();
        // Для отмены команды используется стек в котором храняться последние команды
        private static readonly Stack<ICommand> CommandHistory = new Stack<ICommand>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Добавить контакт");
                Console.WriteLine("2 - Редактировать контакт");
                Console.WriteLine("3 - Удалить контакт");
                Console.WriteLine("4 - Показать все контакты");
                Console.WriteLine("5 - Отменить последнее действие");
                Console.WriteLine("6 - Выйти");
                Console.Write("Ваш выбор: ");

                var sw = Console.ReadLine();

                switch (sw)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        EditContact();
                        break;
                    case "3":
                        DeleteContact();
                        break;
                    case "4":
                        Manager.ListContacts();
                        break;
                    case "5":
                        UndoLastCommand();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            // Методы
            static void AddContact()
            {
                Console.Write("Введите имя: ");
                var name = Console.ReadLine();
                Console.Write("Введите номер телефона: ");
                var phoneNumber = Console.ReadLine();

                var contact = new Contact(name, phoneNumber);
                var command = new AddContactCommand(Manager, contact);
                command.Execute();
                CommandHistory.Push(command);
            }

            static void EditContact()
            {
                Console.Write("Введите имя контакта для редактирования: ");
                var oldName = Console.ReadLine();
                Console.Write("Введите новое имя: ");
                var newName = Console.ReadLine();
                Console.Write("Введите новый номер телефона: ");
                var newPhoneNumber = Console.ReadLine();

                var newContact = new Contact(newName, newPhoneNumber);
                var command = new EditContactCommand(Manager, oldName, newContact);
                command.Execute();
                CommandHistory.Push(command);
            }

            static void DeleteContact()
            {
                Console.Write("Введите имя контакта для удаления: ");
                var name = Console.ReadLine();

                var command = new DeleteContactCommand(Manager, name);
                command.Execute();
                CommandHistory.Push(command);
            }

            static void UndoLastCommand()
            {
                if (CommandHistory.Count > 0)
                {
                    var command = CommandHistory.Pop();
                    command.Undo();
                    Console.WriteLine("Последнее действие отменено.");
                }
                else
                {
                    Console.WriteLine("Нет действий для отмены.");
                }
            }
        }
    }
}
