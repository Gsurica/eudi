using System;
using System.Collections.Generic;
using System.Linq;  
using System.Threading.Tasks;
using restApi.Model;

namespace restApi.Services;

public interface IPersonService {
    Person Create(Person person);
    Person Update(Person person);
    Person FindById(long id);
    void Delete(long id);
    List<Person> FindAll();
}