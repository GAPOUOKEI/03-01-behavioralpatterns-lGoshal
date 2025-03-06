using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem
{
    class EditContactCommand : ICommand
    {
        private readonly ContactManager _manager;
        private readonly string _oldName;
        private readonly Contact _newContact;
        private Contact _oldContact;

        public EditContactCommand(ContactManager manager, string oldName, Contact newContact)
        {
            _manager = manager;
            _oldName = oldName;
            _newContact = newContact;
        }

        public void Execute()
        {
            _oldContact = _manager.GetContact(_oldName);
            _manager.EditContact(_oldName, _newContact);
        }

        public void Undo() => _manager.EditContact(_newContact.Name, _oldContact);
    }
}
