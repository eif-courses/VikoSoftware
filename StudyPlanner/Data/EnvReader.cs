namespace StudyPlanner.Data;

public class EnvReader
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        }

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                // Skip empty lines and comments
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                {
                    continue;
                }

                // Split the line into key and value
                var parts = line.Split('=', 2);

                if (parts.Length != 2)
                {
                    // Log or handle improperly formatted lines
                    Console.WriteLine($"Ignoring invalid line: {line}");
                    continue;
                }

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                // Set environment variable
                Environment.SetEnvironmentVariable(key, value);
                //Console.WriteLine($"Loaded environment variable: {key} = {value}");
            }
        }
        catch (Exception ex)
        {
            // Log or handle errors during file reading or setting environment variables
            Console.WriteLine($"An error occurred while loading environment variables: {ex.Message}");
        }
    }
}