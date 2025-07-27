using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Indexer_concept_
{
    public class PhoneBook
    {
        private Dictionary<string, string> contacts = new();

        public string this[string name]
        {
            get => contacts.ContainsKey(name) ? contacts[name] : "Contact not found";
            set => contacts[name] = value;
        }

        public void Test()
        {
            var phoneBook = new PhoneBook();
            phoneBook["shubham"] = "2324242";
            Console.WriteLine(phoneBook["shubham"]); // Output: 2324242
        }
    }
}
