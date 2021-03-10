using Newtonsoft.Json;
using System;

namespace ToDoList.Entities.Base
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
            partition = "TST";
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string partition { get; set; }
    }
}