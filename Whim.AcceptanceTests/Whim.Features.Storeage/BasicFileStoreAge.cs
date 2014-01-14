using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Whim.Models;
using Whim.Presentation.Infrastructure;

namespace Whim.Features.Storeage
{
    public class BasicFileStoreage : IStoreData
    {
        private const string USER_STORE_FILE_NAME = "Whim_USER_File_Storage";

        public void CreateUser(User user)
        {
            var userList = SearchUsers();

            if (userList.Contains(user))
                return;

            userList.Add(user);

            SaveList(userList);
        }

        public void DeleteUser(User user)
        {
            var userList = SearchUsers();

            if (userList.Contains(user))
                userList.Remove(user);

            SaveList(userList);
        }

        public IList<User> SearchUsers()
        {
            var json = File.ReadAllText(USER_STORE_FILE_NAME);

            return string.IsNullOrWhiteSpace(json) ? new List<User>() : JsonConvert.DeserializeObject<List<User>>(json);
        }

        private void SaveList(IList<User> users)
        {
            var json = JsonConvert.SerializeObject(users);

            File.WriteAllText(USER_STORE_FILE_NAME, json);
        }
    }
}