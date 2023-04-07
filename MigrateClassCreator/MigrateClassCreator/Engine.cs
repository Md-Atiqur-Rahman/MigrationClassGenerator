using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MigrateClassCreator
{
    public class Engine
    {
        private string EntityName;
        private string ProjectName;
        public Engine(string entityName, string projectName)
        {
            EntityName = entityName;
            ProjectName = projectName;
        }

        public void GenerateFile(string sourceFile, string destinationFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(sourceFile))
                {
                    using (StreamWriter writer = new StreamWriter(destinationFile))
                    {
                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine();
                            if (line.Contains("{{EntityName}}"))
                                line = line.Replace("{{EntityName}}", EntityName);
                            if (line.Contains("{{ProjectName}}"))
                                line = line.Replace("{{ProjectName}}", ProjectName);

                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Exception Message: {0}", ex.Message);
            }
        }
        public void Main()
        {
            try
            {
                string destinationFilesource = @"C:\MigrationClassGenerator\destinationLocation.txt";
                StreamReader reader = new StreamReader(destinationFilesource);
                string destinationWorkingDir = reader.ReadLine();

                string sourceFile = "";
                string destinationFile = "";

                destinationFile += EntityName + ".cs";
                Engine program = new Engine(EntityName, ProjectName);
                // Create Class
                sourceFile = @"C:\MigrationClassGenerator\SampleClass.txt";
                destinationFile = destinationWorkingDir;
                string className = EntityName + ".cs";
                destinationFile += className;
                program.GenerateFile(sourceFile, destinationFile);
                Console.WriteLine("********Success********");
                Console.WriteLine("Successfully {0} is created on {1} ", className, destinationWorkingDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Exception Message: {0}", ex.Message);
            }


        }
    }
}
