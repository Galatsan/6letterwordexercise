using System.Threading.Tasks;
using _6letterwordexercise.Interfaces;
using _6letterwordexercise.Models;
using Microsoft.Extensions.Options;

namespace _6letterwordexercise.Services
{
    public class SixLetterWordsFacade : ISixLetterWordsFacade
    {
        private readonly IInputDataReadService inputDataReadService;
        private readonly IOtputDataSaveService otputDataSaveService;
        private readonly IVariantsBuilderService variantsBuilderService;
        private readonly IPrepareOutputData prepareOutputData;
        private readonly Settings settings;

        public SixLetterWordsFacade(
            IInputDataReadService inputDataReadService,
            IOtputDataSaveService otputDataSaveService,
            IVariantsBuilderService variantsBuilderService,
            IPrepareOutputData prepareOutputData,
            IOptions<Settings> options)
        {
            this.inputDataReadService = inputDataReadService;
            this.otputDataSaveService = otputDataSaveService;
            this.variantsBuilderService = variantsBuilderService;
            this.prepareOutputData = prepareOutputData;
            settings = options.Value;
        }

        public async Task Process()
        {
            var lines = await inputDataReadService.Read();
            var variants = variantsBuilderService.GetVariants(lines, settings.CountOfWordsToConcat);
            var dataToSave = prepareOutputData.Prepare(variants, lines);
            await otputDataSaveService.Save(dataToSave);
        }
    }
}
