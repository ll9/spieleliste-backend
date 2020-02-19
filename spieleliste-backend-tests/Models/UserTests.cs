using NUnit.Framework;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace spielelistebackendtests.Models
{
    public class UserTests
    {
        private readonly User _user = new User("");

        [Test]
        public void InsertEmptyUserEntry()
        {
            _user.UserEntries = new List<UserEntry>();

            var entry = CretateUserEntryAtIndex(0);
            _user.InsertUserEntry(entry);

            Assert.AreEqual(0, entry.Index);
        }

        [Test]
        public void InsertFirstUserEntry()
        {
            _user.UserEntries = Enumerable.Range(0, 2).Select(i => CretateUserEntryAtIndex(i)).ToList();

            var entry = CretateUserEntryAtIndex(0);
            _user.InsertUserEntry(entry);

            Assert.AreEqual(0, entry.Index);
            Assert.AreEqual(1, _user.UserEntries.ElementAt(1).Index);
            Assert.AreEqual(2, _user.UserEntries.ElementAt(2).Index);
        }

        [Test]
        public void InsertLastUserEntry()
        {
            _user.UserEntries = Enumerable.Range(0, 2).Select(i => CretateUserEntryAtIndex(i)).ToList();

            var entry = CretateUserEntryAtIndex(2);
            _user.InsertUserEntry(entry);

            Assert.AreEqual(2, entry.Index);
            Assert.AreEqual(0, _user.UserEntries.ElementAt(0).Index);
            Assert.AreEqual(1, _user.UserEntries.ElementAt(1).Index);
        }

        [Test]
        public void InsertCenterUserEntry()
        {
            _user.UserEntries = Enumerable.Range(0, 2).Select(i => CretateUserEntryAtIndex(i)).ToList();

            var entry = CretateUserEntryAtIndex(1);
            _user.InsertUserEntry(entry);

            Assert.AreEqual(1, entry.Index);
            Assert.AreEqual(0, _user.UserEntries.ElementAt(0).Index);
            Assert.AreEqual(2, _user.UserEntries.ElementAt(2).Index);
        }

        [Test]
        public void InsertOutOfBounds()
        {
            _user.UserEntries = Enumerable.Range(0, 2).Select(i => CretateUserEntryAtIndex(i)).ToList();

            var entry = CretateUserEntryAtIndex(10000);
            _user.InsertUserEntry(entry);

            Assert.AreEqual(2, entry.Index);
            Assert.AreEqual(0, _user.UserEntries.ElementAt(0).Index);
            Assert.AreEqual(1, _user.UserEntries.ElementAt(1).Index);
        }

        [Test]
        public void RemoveFirst()
        {
            _user.UserEntries = Enumerable.Range(0, 2).Select(i => CretateUserEntryAtIndex(i)).ToList();

            _user.RemoveUserEntry(_user.UserEntries.First());

            Assert.AreEqual(0, _user.UserEntries.ElementAt(0).Index);
        }

        [Test]
        public void RemoveMiddle()
        {
            _user.UserEntries = Enumerable.Range(0, 3).Select(i => CretateUserEntryAtIndex(i)).ToList();

            _user.RemoveUserEntry(_user.UserEntries.Skip(1).First());

            Assert.AreEqual(0, _user.UserEntries.ElementAt(0).Index);
            Assert.AreEqual(1, _user.UserEntries.ElementAt(1).Index);
        }

        private static UserEntry CretateUserEntryAtIndex(int index)
        {
            return new UserEntry(0, 0, index);
        }
    }
}