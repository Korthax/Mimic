using System;
using System.Collections.Generic;

namespace Mimic.Core.IntegrationTests.Mocking
{
    public class ComplexObject
    {
        public SimpleObject SimpleObject { get; set; }
        public SimpleObject SimpleObject2 { get; set; }
        public SimpleObject SimpleObject3 { get; set; }
        public SimpleObject2 SimpleObject4 { get; set; }
        public string SetMe { get; set; }
        public Uri Uri { get; set; }
        public DateTime DateTime { get; set; }
        public List<SimpleObject2> List { get; set; }
        public SimpleObject2[] Array { get; set; }
        public Dictionary<string, SimpleObject2> Dictionary { get; set; }
    }
}