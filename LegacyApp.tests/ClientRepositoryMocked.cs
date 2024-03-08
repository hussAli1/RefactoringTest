using LegacyApp.Interface;
using LegacyApp.Model;

namespace LegacyApp.Tests
{
    internal class ClientRepositoryMocked : IClientRepository
    {
        List<Client> _clients = new();
        List<User> _users = new();

        public ClientRepositoryMocked()
        {
            _clients.Add(new Client
            {
                Name = "VeryImportantClient",
                ClientStatus = ClientStatus.none,
                Id = 1
            });

            _clients.Add(new Client
            {
                Name = "ImportantClient",
                ClientStatus = ClientStatus.none,
                Id = 2
            });

            _clients.Add(new Client
            {
                Name = "f",
                ClientStatus = ClientStatus.none,
                Id = 3
            });

            //_users.Add(new User
            //{
            //    Firstname = "",
            //    Surname = "amer",
            //    Client = _clients[1],
            //    EmailAddress = "hussain@gmail.com"
            //});

        }
        public Client GetById(int id)
        {
            return _clients.SingleOrDefault(c => c.Id == id);
        }
    }
}