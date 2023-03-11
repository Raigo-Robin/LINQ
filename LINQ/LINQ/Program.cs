
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
         {
            WhereLINQ();

            PeopleByAge();
            
            ThenByLINQ();
            
            ThenByDecending();

            ToLookUPLINQ();

            JoinLINQ();

            GroupJoinLINQ();

            SelectLINQ();

            AllAndAnyLINQ();

            ContainsLINQ();
            
            AggregateLINQ();

            AverageLINQ();

            CountLINQ();

            MaximumLINQ();
            
            SumLINQ();

            ElementjaElementAtOrDefaultLINQ();

            FirstLINQ();

            FirstOrDefaultLINQ();

            LastLINQ();

            LastOrDefault();

            SequenceEqual();

            ConcatLINQ();

            DefaultIfEmpty();

            EmptyLINQ();

            RangeLINQ();

            Repeat();

            DistinctLINQ();

            Except();

            Intersect();











        }

        public static void WhereLINQ()
        {
            Console.WriteLine("LINQ");
            //ctrl + k +c / u
            //IList<People> peoples = new List<People>()
            //{
            //    new People() { Id = 1, Name = "Joosep", Age = 10 },
            //    new People() { Id = 2, Name = "Kalev", Age = 21 },
            //    new People() { Id = 3, Name = "Roonas", Age = 18},
            //    new People() { Id = 4, Name = "Tom", Age = 12},
            //    new People() { Id = 5, Name = "Bill", Age = 17},
            //    new People() { Id = 6, Name = "Bill", Age = 15},
            //    new People() { Id = 7, Name = "Jaagup", Age = 21},

            //};

            //nätab nimekirjas üle ühe
            Console.WriteLine("------------");
            var filteredResult = PeopleList.people.Where((s, i) =>
            {
                if (i % 2 == 0)
                {
                    return true;
                }
                return false;
            });

            foreach (var People in filteredResult)
            {
                Console.WriteLine(People.Name);
            }

        }

        public static void PeopleByAge()
        {
            Console.WriteLine("Vanuse järgi selekteerimine");

            var peopleByAge = PeopleList.people.Where(s => s.Age >= 14 && s.Age <= 20);
            foreach (var people in peopleByAge)
            {
                Console.WriteLine(people.Age + " " + people.Name);
            }
            
        }

        public static void ThenByLINQ()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("ThenBy ja ThenByDecening järgi reastamine");

            var thenByResult = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenBy(y => y.Age);

            Console.WriteLine("ThenBy järgi: ");
            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ThenByDecending()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("ThenByDecending järgi reastamine");

            var thenByDecending = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenByDescending(y => y.Age);

            foreach (var people in thenByDecending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ToLookUPLINQ()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("ToLookup järgi reastamine");

            var toLookUp = PeopleList.people
                .ToLookup(x => x.Age);

            foreach (var people in toLookUp)
            {
                Console.WriteLine("Age Group " + people.Key);

                foreach (People p in people)
                {
                    Console.WriteLine("Person's name: {0} ", p.Name);

                }
            }
        }

        public static void JoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------------------");
            Console.WriteLine("InnerJoin in LINQ");
            
            var innerJoin = PeopleList.people.Join(
                GenderList.genderList,
                humans => humans.GenderId,
                gender => gender.Id,
                (humans, gender) => new
                {
                    Name = humans.Name,
                    Sex = gender.Sex
                });

            foreach (var obj in innerJoin)
            {
                Console.WriteLine("{0} - {1}", obj.Name, obj.Sex);
            }
        }

        public static void GroupJoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------");
            Console.WriteLine("GorupJoinLINQ");
            var groupJoin = GenderList.genderList
                .GroupJoin(PeopleList.people, 
                p => p.Id,
                g => g.GenderId,
                (p, peopleGroup) => new
                {
                    Humans = peopleGroup,
                    GenderFullName = p.Sex
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.GenderFullName);

                foreach (var name in item.Humans)
                {
                    Console.WriteLine(name.Name);
                }
            }
        }

        public static void SelectLINQ()
        {

            //Võtab objektid ja talletab need ning prindib
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("----------------");
            Console.WriteLine("Select in LINQ");
            var selectResult = PeopleList.people
                .Select(x => new
                {
                    Name = x.Name,
                    Age = x.Age
                });

            foreach (var item in selectResult)
            {
                Console.WriteLine("Human name: {0}, Age: {1}", item.Name, item.Age);
            }
        }

        public static void AllAndAnyLINQ()

        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------");
            Console.WriteLine("All LINQ");
            bool areAllPeeopleTeenagers = PeopleList.people
                .All(x => x.Age < 12 && x.Age < 20);
            //vasstus tuleb true
            Console.WriteLine(areAllPeeopleTeenagers);

            Console.WriteLine("----------------");
            Console.WriteLine("Any LINQ");

            bool isAnyPersonTeenager = PeopleList.people
                .Any(x => x.Age > 12);

            //kasvõi üks andmerida vastab tingimusele
            Console.WriteLine(isAnyPersonTeenager);
        }

        public static void ContainsLINQ()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Contains LINQ");

            //Pärib kas number 1 on numbrite nimekirjas olemas
            bool result = NumberList.numberList.Contains(1);
            Console.WriteLine(result);
        }

        public static void AggregateLINQ()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Aggregate LINQ");

            string commaSeperatedPersonNames = PeopleList.people
                .Aggregate<People, string>(
                "People names: ",
                (str, y) => str += y.Name + ", "
                );

            Console.WriteLine(commaSeperatedPersonNames);

        }

        public static void AverageLINQ()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Average LINQ");
            var averageResult = PeopleList.people
                .Average(x => x.Age);

            Console.WriteLine(averageResult);
        }

        public static void CountLINQ()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Count LINQ");
            var totalPeople = PeopleList.people.Count();

            Console.WriteLine("Inimesi on kokki: " + totalPeople);

            var adultPeople = PeopleList.people.Count(x => x.Age > 18);

            Console.WriteLine("Täisealisi inimesi on: " + adultPeople);
        }

        public static void MaximumLINQ()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Maximum LINQ");
            
            var oldest = PeopleList.people
                .Max(x => x.Age);
                

            Console.WriteLine("Oldest person is " + oldest + " years old" );
        }

        public static void SumLINQ()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Sum LINQ");
            
            var sumAge = PeopleList.people
                .Sum(x => x.Age);

            Console.WriteLine("Every age summed up: " + sumAge);

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Täisealiste isikute koondvanus");
           
            

            //Loeb kokku kõik 18+ inimesed ning liidab nende vanused
            var sumAdults = 0;
            var numAdults = 0;

            for (int i = 0; i < PeopleList.people.Count; i++)
            {
                if (PeopleList.people[i].Age >= 18)
                {
                    numAdults++;
                    sumAdults += PeopleList.people[i].Age;
                }
            }

            Console.WriteLine("Täiskasvanud isikute arv: " + numAdults);
            Console.WriteLine("Täiskavanute vanus kokku: "+ sumAdults);

        }

        public static void ElementjaElementAtOrDefaultLINQ()
        {


            
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;

            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",
                            intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strList.ElementAtOrDefault(9));
        }

        public static void FirstLINQ()
        {

            Console.WriteLine("--------------------");
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;


            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            
            
        }

        public static void FirstOrDefaultLINQ()
        {
            Console.WriteLine("--------------------------");
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;
            List<string> emptyList = Integral_and_String.emptyList;

            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());
            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());


        }

        public static void LastLINQ()
        {
            Console.WriteLine("-----------------------");
            
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;
            List<string> emptyList = Integral_and_String.emptyList;

            Console.WriteLine("Last Element in intList: {0}", intList.Last());

            Console.WriteLine("Last Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.Last());

   


        }

        public static void LastOrDefault()
        {
            Console.WriteLine("--------------------------");
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;
            List<string> emptylist = Integral_and_String.emptyList;

            Console.WriteLine("Last Element in intList: {0}", intList.LastOrDefault());

            Console.WriteLine("Last Even Element in intList: {0}",
                                             intList.LastOrDefault(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.LastOrDefault());

            Console.WriteLine("Last Element in emptyList: {0}", emptylist.LastOrDefault());
        }

        public static void SequenceEqual()
        {
            Console.WriteLine("--------------------------");
            List<string> strList = Integral_and_String.strList;
            List<string> strList2 = Integral_and_String.strList2;

            bool isEqual = strList.SequenceEqual(strList2); // returns true
            Console.WriteLine(isEqual);


        }

        public static void ConcatLINQ()
        {
            Console.WriteLine("-----------------------");
            List<string> strList = Integral_and_String.strList;
            List<string> strList2 = Integral_and_String.strList2;

            var collection3 = strList.Concat(strList2);

            foreach (string str in collection3)
            {
                Console.WriteLine(str);
            }
        }

        public static void DefaultIfEmpty()
        {

            Console.WriteLine("----------------------");
            List<int> emptyList2 = Integral_and_String.emptyList2;
            
            var newList1 = emptyList2.DefaultIfEmpty();
            var newList2 = emptyList2.DefaultIfEmpty(100);

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));
        }
        
        public static void EmptyLINQ()
        {
            Console.WriteLine("----------------");
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<Student>();

            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);
        }

        public static void RangeLINQ()
        {
            Console.WriteLine("---------------");
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
        }

        public static void Repeat()
        {

            Console.WriteLine("-------------");
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));

        }

        public static void DistinctLINQ()
        {
            Console.WriteLine("----------------------");
            List<int> intList = Integral_and_String.intList;
            List<string> strList = Integral_and_String.strList;

            var distinctList1 = strList.Distinct();

            foreach (var str in distinctList1)
                Console.WriteLine(str);

            var distinctList2 = intList.Distinct();

            foreach (var i in distinctList2)
                Console.WriteLine(i);

        }

        public static void Except()
        {

            Console.WriteLine("----------------");
            List<string> strList = Integral_and_String.strList;
            List<string> strList2 = Integral_and_String.strList2;

            var result = strList.Except(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }

        public static void Intersect()
        {
            List<string> strList = Integral_and_String.strList;
            List<string> strList2 = Integral_and_String.strList2;
            var result = strList.Intersect(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }
    }
    
}