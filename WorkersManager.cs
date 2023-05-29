using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesSolution;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThalesAssessment
{
    public class WorkersManager
    {
        public List<Worker> workers { get; set; }

        //public List<Worker> unsupervisedWorkers { get; set; }

        public WorkersManager() 
        {
            workers = new List<Worker>();
        }
        
        public void AddSupervisedWorker(Worker supervisor, Worker newWorker)
        {
            Worker superv = workers.Find(w1 => w1.Equals(supervisor));
            superv.addSupervised(newWorker);
            workers.Add(newWorker);
        }

        public void AddUnsupervisedWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public void RemoveWorker(Worker worker)
        {
            workers.Remove(worker);
        }

        public bool ContainsWorker(Worker worker)
        {
            return workers.Contains(worker);
        }

        public Worker UpdateWorker(Worker worker, String name, String role)
        {
            Worker w = workers.Find(w1 => w1.Equals(worker));
            w.Name = name;
            w.Role = role;
            return w;
        }

        public void SaveToJson()
        {
  
        }

        public void LoadFromJson()
        {

        }
    }
}
