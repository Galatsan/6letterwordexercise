using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;
using _6letterwordexercise.Models;
using Microsoft.Extensions.Options;

namespace _6letterwordexercise.Services
{
    public class SixLetterWordsFacade : ISixLetterWordsFacade
    {
        private readonly IReadFileService readFileService;
        private readonly IWriteFileService writeFileService;
        private readonly IVariantsBuilderService variantsBuilderService;
        private readonly IPrepareOutputData prepareOutputData;
        private readonly Settings settings;

        public SixLetterWordsFacade(IReadFileService readFileService,
            IWriteFileService writeFileService,
            IVariantsBuilderService variantsBuilderService,
            IPrepareOutputData prepareOutputData,
            IOptions<Settings> options)
        {
            this.readFileService = readFileService;
            this.writeFileService = writeFileService;
            this.variantsBuilderService = variantsBuilderService;
            this.prepareOutputData = prepareOutputData;
            settings = options.Value;
        }

        public async Task Process()
        {
            var lines = await readFileService.Read(settings.InputFile);
            var variants = variantsBuilderService.GetVariants(lines, settings.CountOfWordsToConcat);
            var dataToSave = prepareOutputData.Prepare(variants, lines);
            await writeFileService.Write(settings.OutputFile, dataToSave);
        }
    }
}
