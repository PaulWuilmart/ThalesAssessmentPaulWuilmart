using System;
using System.Collections.Generic;

namespace ThalesSolution
{
    public class Worker
    {
        private static readonly string separator = " - ";
        public string Name { get; set; }
        public string Role { get; set; }
        public List<Worker> Supervised { get; set; }

        public Worker(string name, string role)
        {
            Name = name;
            Role = role;
            Supervised = new List<Worker>();
        }

        public override string ToString()
        {
            return Name + separator + Role;
        }

        public static Worker FromString(string toStringResult)
        {
            string[] split = toStringResult.Split( new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            return new Worker(split[0], split[1]);
        }


        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Worker w = (Worker) obj;
                return (w.Name == Name) && (w.Role == Role);
            }
        }

        public void AddSupervised(Worker toSupervise)
        {
            if (!Supervised.Contains(toSupervise))
            {
                Supervised.Add(toSupervise);
            }
        }
    }
}
