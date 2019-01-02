using AspCorePluSight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AspCorePluSight.Models.Deputy;
namespace AspCorePluSight.Services
{
  public  interface IMongo
    {
        IEnumerable<Customer> GetData();
        Customer Get(int id);
        Customer Add(Customer customer);
        Customer Edit (Customer customer);
        Boolean Delete(int id);
        Election.Person addPerson(Election.Person person);
        milletvekiliAday addDeputy(milletvekiliAday milletvekiliAday);

    }
}
