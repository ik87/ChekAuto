using System;
using System.Runtime.Serialization;

namespace Выбор_автомобилей {
    [Serializable()]
    class TAuto : ISerializable {
        public string Auto { get; set; }
        public string Cost { get; set; }
        public string Rate { get; set; }
        public string Realibility { get; set; }
        public string Comfort { get; set; }
        public TAuto() { }
        
        public TAuto(SerializationInfo info, StreamingContext ctxt) {
            Auto = (String)info.GetValue("Auto", typeof(string));
            Cost = (String)info.GetValue("Cost", typeof(string));
            Rate = (String)info.GetValue("Rate", typeof(string));
            Realibility = (String)info.GetValue("Realibility", typeof(string));
            Comfort = (String)info.GetValue("Comfort", typeof(string));
        }

       public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Auto", Auto);
            info.AddValue("Cost", Cost);
            info.AddValue("Rate", Rate);
            info.AddValue("Realibility", Realibility);
            info.AddValue("Comfort", Comfort);
        } 
        
    }
}
