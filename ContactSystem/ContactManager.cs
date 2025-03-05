using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem
{
    class ContactManager
    {
        private readonly Dictionary<string, Contact> _contacts = new Dictionary<string, Contact>();

        public void AddContact(Contact contact)
        {
            _contacts[contact.Name] = contact;
            Console.WriteLine($"Добавлен контакт: {contact}");
        }

        public void EditContact(string oldName, Contact newContact)
        {
            if (_contacts.ContainsKey(oldName))
            {
                _contacts.Remove(oldName);
                _contacts[newContact.Name] = newContact;
                Console.WriteLine($"Контакт '{oldName}' изменен на: {newContact}");
            }
            else
            {
                Console.WriteLine($"Контакт '{oldName}' не найден.");
            }
        }

        public void RemoveContact(string name)
        {
            if (_contacts.ContainsKey(name))
            {
                var contact = _contacts[name];
                _contacts.Remove(name);
                Console.WriteLine($"Удален контакт: {contact}");
            }
            else
            {
                Console.WriteLine($"Контакт '{name}' не найден.");
            }
        }

        public Contact GetContact(string name)
        {
            return _contacts.ContainsKey(name) ? _contacts[name] : null;
        }

        public void ListContacts()
        {
            Console.WriteLine("Список контактов:");
            foreach (var contact in _contacts.Values)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
