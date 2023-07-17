using restApi.Model;

namespace restApi.Services.implementations;

public class PersonServiceImplementation : IPersonService
{
    private volatile int count;

    public Person Create(Person person) {
        return person;
    }

    public void Delete(long id) {
        
    }

    public List<Person> FindAll() {
        List<Person> persons = new List<Person>();

        for(int i = 0; i < 8; i++) {
            Person person = MockPerson(i);
            persons.Add(person);
        }

        return persons;
    }

    public Person FindById(long id) {
        return new Person {
            Id = IncementAndGet(),
            Address = "Mogi Guaçu",
            Gender = "Masculino",
            LastName = "Surica",
            Name = "Guilherme"
        };
    }

    public Person Update(Person person) {
        return person;
    }

    private Person MockPerson(int i) {
        return new Person {
            Id = IncementAndGet(),
            Address = "Some Address" + i,
            Gender = "Masculino" + i,
            LastName = "Person last name" + i,
            Name = "person name" + i
        };
    }

    private long IncementAndGet() {
        
        return Interlocked.Increment(ref count);
    }
}