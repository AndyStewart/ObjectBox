using System;

namespace ObjectBox.Tests.Fixtures
{
    public class DefaultObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Total { get; set; }
        public MyObject Association { get; set; }
    }
}