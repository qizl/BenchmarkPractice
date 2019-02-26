using BenchmarkDotNet.Attributes;
using BenchmarkPractice.Nfx.Models;
using Newtonsoft.Json;
using Swifter.Json;
using System;
using System.Collections.Generic;

namespace BenchmarkPractice.Nfx
{
    public class Json
    {
        private List<Obj> _objs;
        private string _json;

        public Json()
        {
            _objs = new List<Obj>();
            for (var i = 0; i < 100; i++)
            {
                var obj = new Obj { Id = Guid.NewGuid(), Name = $"P{i}", Birth = DateTime.Now };
                _objs.Add(obj);
                obj.Childs = new List<Child>();
                for (var j = 0; j < 10; j++)
                    obj.Childs.Add(new Child { Id = Guid.NewGuid(), Name = $"C{i}", Birth = DateTime.Now, Sex = true });
            }

            _json = JsonConvert.SerializeObject(_objs);
        }

        [Benchmark]
        public void JsonNetSerializeObject()
        {
            JsonConvert.SerializeObject(_objs);
        }

        [Benchmark]
        public void JsonNetDeserializeObject()
        {
            JsonConvert.DeserializeObject<List<Obj>>(_json);
        }

        [Benchmark]
        public void SwifterJsonSerializeObject()
        {
            JsonFormatter.SerializeObject(_objs);
        }

        [Benchmark]
        public void SwifterJsonDeserializeObject()
        {
            JsonFormatter.DeserializeObject<List<Obj>>(_json);
        }
    }
}
