using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegacyApp.Model;

namespace LegacyApp.Interface
{
    public interface IClientRepository
    {
        Client GetById(int id);
    }
}
