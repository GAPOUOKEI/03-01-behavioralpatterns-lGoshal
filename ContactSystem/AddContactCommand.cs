using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem
{
    class AddContactCommand : ICommand
    {
        private readonly ContactManager _manager;
        private readonly Contact _contact;

        public AddContactCommand(ContactManager manager, Contact contact)
        {
            _manager = manager;
            _contact = contact;
        }

        public void Execute() => _manager.AddContact(_contact);

        public void Undo() => _manager.RemoveContact(_contact.Name);
    }
}
