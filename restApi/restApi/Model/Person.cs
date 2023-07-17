using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restApi.Model;

public class Person {
    public long Id {get; set;}
    public string Name {get; set;}
    public string LastName {get; set;}
    public string Address {get; set;}
    public string Gender {get; set;}
}