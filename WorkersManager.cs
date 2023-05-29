using System;
using System.IO;
using System.Collections.Generic;
using ThalesSolution;
using System.Text.Json;


namespace ThalesAssessment
{
    public class WorkersManager
    {
        // List with top-level workers who are unsupervised.
        // Each worker has a list with workers they supervise.
        // For this reason the data will be in a tree-structure.
        public List<Worker> UnsupervisedWorkers { get; set; }

        public WorkersManager() 
        {
            UnsupervisedWorkers = new List<Worker>();
        }
        
        public static WorkersManager FromJson(string fileName)
        {
            WorkersManager workersManager = new WorkersManager();
            if (File.Exists(fileName))
            {
                string jsonStr = File.ReadAllText(fileName);
                workersManager = JsonSerializer.Deserialize<WorkersManager>(jsonStr);
            }
            return workersManager;
        }

        public void SaveToJson(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public void AddSupervisedWorker(Worker supervisor, Worker newWorker)
        {
            Worker superv = FindWorker(supervisor);
            superv?.AddSupervised(newWorker);
        }

        public void AddUnsupervisedWorker(Worker worker)
        {
            UnsupervisedWorkers.Add(worker);
        }
        public void RemoveWorker(Worker toRemove)
        {
            foreach (Worker parent in UnsupervisedWorkers)
            {
                if (parent.Equals(toRemove))
                {
                    UnsupervisedWorkers.Remove(parent);
                    return;
                }
                else if (RemoveFromChild(parent, toRemove) == true)
                {
                    return;
                }
            }
        }

        private bool RemoveFromChild(Worker parent, Worker toRemove)
        {
            foreach (Worker child in parent.Supervised)
            {
                if (child.Equals(toRemove))
                {
                    parent.Supervised.Remove(child);
                    return true;
                }
                else if (RemoveFromChild(child, toRemove))
                {
                    return true;
                }
            }
            return false;
        }

        // Returns the worker-reference from our data or null if the worker was found.
        public Worker FindWorker(Worker toFind)
        {
            foreach (Worker parent in UnsupervisedWorkers)
            {
                Worker res = FindWorker(parent, toFind);
                if (res != null)
                {
                    return res;
                }
            }
            return null; // Not found
        }

        // Searches if the parent or any child that he/she supervises is the worker we look for.
        private Worker FindWorker(Worker parent, Worker toFind)
        {
            if (parent.Equals(toFind))
            {
                return parent;
            }

            foreach (Worker child in parent.Supervised)
            {
                Worker res = FindWorker(child, toFind);
                if (res != null)
                {
                    return res;
                }
            }
            return null; // Not found
        }

        public bool ContainsWorker(Worker toFind)
        {
            return FindWorker(toFind) != null;
        }

        public Worker UpdateWorker(Worker worker, string name, string role)
        {
            Worker toUpdate = FindWorker(worker);
            toUpdate.Name = name;
            toUpdate.Role = role;
            return toUpdate;
        }
    }
}
