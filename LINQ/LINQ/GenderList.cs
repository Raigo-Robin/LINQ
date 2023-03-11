namespace LINQ
{
    public class GenderList
    {
        public static readonly List<Gender> genderList = new List<Gender>()
        {
            new Gender()
            {
                Id = Guid.Parse("de33e1b0-0ddf-4b2e-9e53-636ecbf546a0"),
                Sex = "Male"
            },
            
            new Gender() 
            {
                Id = Guid.Parse("28a97a6c-c3a1-45e0-ad9b-bb58c7fd64be"), 
                Sex = "Female"
            },
        };
    }
}
