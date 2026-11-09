using System;
using System.IO;
using FraudModel;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("=== Fraud Model: Train → Save ZIP ===");

        // Save the ZIP inside this project's output folder.
        var outputDir = Path.Combine(
            AppContext.BaseDirectory, "TrainedModels");

        Directory.CreateDirectory(outputDir);

        var zipPath = Path.Combine(outputDir, "MLModel.zip");

        // The CSV is stored in the FraudModel project root.
        var projectRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

        var csvPath = Path.Combine(
            projectRoot, "credit_card_fraud_1000.csv");

        Console.WriteLine($"CSV: {csvPath}");
        Console.WriteLine($"ZIP: {zipPath}");

        if (!File.Exists(csvPath))
        {
            Console.WriteLine(
                "CSV not found. Put credit_card_fraud_1000.csv " +
                "in the FraudModel project root.");

            return;
        }

        // Retrain the pipeline previously selected by AutoML
        // and save the trained model as a ZIP.
        MLModel.Train(
            outputModelPath: zipPath,
            inputDataFilePath: csvPath);

        Console.WriteLine("MLModel.zip created successfully.");
    }
}