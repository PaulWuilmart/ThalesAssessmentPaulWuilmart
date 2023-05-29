using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesSolution
{
    public class Worker
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public List<Worker> Supervised { get; set; }

        public Worker(string name, string role)
        {
            Name = name;
            Role = role;
            Supervised = new List<Worker>();
        }

        public static Worker FromString(string toStringResult)
        {
            int separatorIndex = toStringResult.IndexOf('-');
            String name = toStringResult.Substring(0, separatorIndex - 1);
            String role = toStringResult.Substring(separatorIndex + 2);
            return new Worker(name, role);

        }
        public override string ToString()
        {
            return Name + " - " + Role;
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
 
        public String GetDataRaw()
        {
            String data = "";
            return data;
        }

        public void addSupervised(Worker toSupervise)
        {
            if (!Supervised.Contains(toSupervise))
            {
                Supervised.Add(toSupervise);
            }
        }
    }
}
