using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise.Services
{
    public class ReadFileService : IReadFileService
    {
        public async Task<IEnumerable<string>> Read(string fileName)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(AppContext.BaseDirectory + fileName))
            {
                var content = await reader.ReadToEndAsync();
                lines.AddRange(content.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
            }

            return lines;
        }
    }
}
