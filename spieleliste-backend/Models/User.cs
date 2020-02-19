using spieleliste_backend.Extensions;
using System.Collections.Generic;

namespace spieleliste_backend.Models
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<UserEntry> UserEntries { get; set; } = new List<UserEntry>();

        public void InsertUserEntry(UserEntry entry)
        {
            EnsureCorrectIndices();

            for (int i = entry.Index; i < UserEntries.Count; i++)
            {
                UserEntries[i].Index++;
            }

            var indexOrLast = UserEntries.InsertAtOrLast(entry.Index, entry);
            entry.Index = indexOrLast;
        }

        public void RemoveUserEntry(UserEntry entry)
        {
            UserEntries.Remove(entry);

            EnsureCorrectIndices();
        }

        private void EnsureCorrectIndices()
        {
            for (int i = 0; i < UserEntries.Count; i++)
            {
                var entry = UserEntries[i];
                if (entry.Index != i)
                {
                    entry.Index = i;
                }
            }
        }
    }
}