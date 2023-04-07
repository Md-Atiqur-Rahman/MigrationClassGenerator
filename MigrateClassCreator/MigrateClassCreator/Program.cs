using System;
using System.CommandLine;
using System.IO;

namespace MigrateClassCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileOption = new Option<string?>(
           name: "--create",
           description: "Here Provide your class name.");

            var rootCommand = new RootCommand("Sample app for System.CommandLine");
            rootCommand.AddOption(fileOption);

            rootCommand.SetHandler((file) =>
            {
                CreateClass(file!);
            },
                fileOption);

            rootCommand.Invoke(args);
        }

        static void CreateClass(string EntityName)
        {
            //string EntityName = Console.ReadLine();
            EntityName = EntityName + DateTime.Now.ToString("yyyyMMddHHmmss");
            string projectFilesource = @"C:\MigrationClassGenerator\ProjectNameSpace.txt";
            StreamReader projectNamereader = new StreamReader(projectFilesource);
            string ProjectName = projectNamereader.ReadLine();
            Engine program = new Engine(EntityName, ProjectName);
            program.Main();
        }
    }
}
