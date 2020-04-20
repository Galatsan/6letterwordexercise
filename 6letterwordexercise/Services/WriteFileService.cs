using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise.Services
{
    public class WriteFileService : IWriteFileService
    {
        public async Task Write(string fileName, IEnumerable<string> lines)
        {
            var fullFileName = AppContext.BaseDirectory + fileName;
            if (File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
            }
            using var stream = new StreamWriter(fullFileName);
            foreach (var line in lines)
            {
                await stream.WriteLineAsync(line);
            }
        }
    }
}
