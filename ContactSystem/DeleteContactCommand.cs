using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem
{
    class DeleteContactCommand : ICommand
    {
        private readonly ContactManager _manager;
        private readonly string _contactName;
        private Contact _deletedContact;

        public DeleteContactCommand(ContactManager manager, string contactName)
        {
            _manager = manager;
            _contactName = contactName;
        }

        public void Execute()
        {
            _deletedContact = _manager.GetContact(_contactName);
            _manager.RemoveContact(_contactName);
        }

        public void Undo() => _manager.AddContact(_deletedContact);
    }
}
