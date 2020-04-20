using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;
using _6letterwordexercise.Models;
using Microsoft.Extensions.Options;

namespace _6letterwordexercise.Services
{
    public class InputDataReadService : IInputDataReadService
    {
        private readonly Settings settings;

        public InputDataReadService(IOptions<Settings> options)
        {
            settings = options.Value;
        }

        public async Task<IEnumerable<string>> Read()
        {
            var fullFileName = AppContext.BaseDirectory + settings.InputFile;
            if (!File.Exists(fullFileName))
            {
                throw new Exception($"File {fullFileName} doesn't exsist");
            }
            var lines = new List<string>();
            using (var reader = new StreamReader(fullFileName))
            {
                var content = await reader.ReadToEndAsync();
                lines.AddRange(content.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
            }

            return lines;
        }
    }
}
