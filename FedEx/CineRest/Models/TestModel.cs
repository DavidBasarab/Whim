using System;

namespace Models
{
    public class TestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Now { get; set; }

        public TestModel()
        {
            Now = DateTime.Now;
        }
    }
}