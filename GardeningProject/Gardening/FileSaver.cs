using System;
using System.IO;

namespace Gardening
{
    public class FileSaver
    {
        private readonly string fileName;

        public FileSaver(string fileName)
        {
            this.fileName = fileName;

            // Ensure the file exists, but don’t overwrite if it already exists
            if (!File.Exists(this.fileName))
            {
                File.Create(this.fileName).Close();
            }
        }

        public void AppendLine(string line)
        {
            try
            {
                File.AppendAllText(this.fileName, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error writing to file: {ex.Message}");
            }
        }
    }
}
