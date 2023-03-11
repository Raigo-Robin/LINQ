
namespace LINQ
{
    public class PeopleList
    {
        public static readonly List<People> people = new List<People>()
        {
                new People()
                { 
                    Id = 1, 
                    Name = "Joosep",
                    Age = 10,
                    GenderId = Guid.Parse("de33e1b0-0ddf-4b2e-9e53-636ecbf546a0")
                },

                new People()
                {
                    Id = 2,
                    Name = "Moona",
                    Age = 21,
                    GenderId = Guid.Parse("28a97a6c-c3a1-45e0-ad9b-bb58c7fd64be")
                },
                new People()
                { 
                    Id = 3,
                    Name = "Roonas",
                    Age = 18,
                    GenderId = Guid.Parse("de33e1b0-0ddf-4b2e-9e53-636ecbf546a0")
                },
                new People()
                { 
                    Id = 4,
                    Name = "Anna",
                    Age = 12,
                    GenderId = Guid.Parse("28a97a6c-c3a1-45e0-ad9b-bb58c7fd64be")
                },
                new People()
                {
                    Id = 5,
                    Name = "Mari",
                    Age = 17,
                    GenderId = Guid.Parse("28a97a6c-c3a1-45e0-ad9b-bb58c7fd64be")
                },
                new People()
                {
                    Id = 6,
                    Name = "Bill",
                    Age = 15,
                    GenderId = Guid.Parse("de33e1b0-0ddf-4b2e-9e53-636ecbf546a0")
                },
                new People()
                {
                    Id = 7,
                    Name = "Jaagup",
                    Age = 21,
                    GenderId = Guid.Parse("de33e1b0-0ddf-4b2e-9e53-636ecbf546a0")
                }
        };
    }

}




