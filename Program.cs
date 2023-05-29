using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThalesSolution;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThalesAssessment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Read JSON
            string fileName = "Workers.json";
            string jsonString = File.ReadAllText(fileName);
            WorkersManager workersManager = JsonSerializer.Deserialize<WorkersManager>(jsonString);
            Console.WriteLine(jsonString);

            //Run Application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(workersManager));


            //Create JSON
            fileName = "Workers.json";
            jsonString = JsonSerializer.Serialize(workersManager);
            File.WriteAllText(fileName, jsonString);
            Console.Write("JSON form of WorkersManager object: ");
            Console.WriteLine(jsonString);
        }
    }
}
