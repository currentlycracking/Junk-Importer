using System;
using System.IO;
using dnlib.DotNet;
using JunkImporter.JunkImports.Protect;

public class Program {
    public static void Main(string[] args) {
        Console.Title = "Junk Importer - @currentlycracking";
        Console.WriteLine("=== Junk Importer ===");

        if(args.Length == 0) {
            Console.WriteLine("Usage: JunkImporter.exe <path-to-assembly>");
            return;
        }

        string inputPath = args[0];
        if(!File.Exists(inputPath)) {
            Console.WriteLine("Error: File not found.");
            return;
        }

        try {
            ModuleDefMD module = ModuleDefMD.Load(inputPath);
            Console.WriteLine($"Loaded: {Path.GetFileName(inputPath)}");

            var junker = new AddJunk(module);
            var task = junker.ImportJunk();
            task.Wait();

            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "importedjunk_" + Path.GetFileName(inputPath));
            module.Write(outputPath);
            Console.WriteLine($"Saved: {outputPath}");
        } catch(Exception ex) {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        Console.ReadLine();
    }
}