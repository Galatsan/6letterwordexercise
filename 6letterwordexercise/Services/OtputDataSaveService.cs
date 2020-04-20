using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;
using _6letterwordexercise.Models;
using Microsoft.Extensions.Options;

namespace _6letterwordexercise.Services
{
    public class OtputDataSaveService : IOtputDataSaveService
    {
        private readonly Settings settings;

        public OtputDataSaveService(IOptions<Settings> options)
        {
            settings = options.Value;
        }

        public async Task Save(IEnumerable<string> lines)
        {
            var fullFileName = AppContext.BaseDirectory + settings.OutputFile;
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
