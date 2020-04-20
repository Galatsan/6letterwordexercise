﻿using System.Collections.Generic;
using System.Linq;
using _6letterwordexercise.Extensions;
using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise.Services
{
    public class PrepareOutputData : IPrepareOutputData
    {
        public IEnumerable<string> Prepare(IEnumerable<IEnumerable<string>> variants, IEnumerable<string> linesFromFile)
        {
            foreach (var item in variants.Distinct(new EnumerableEqualityComparer()))
            {
                var concat = item.ConcateStrings("+");
                var concatResult = item.ConcateStrings();
                if (concatResult.Length <= 6 && linesFromFile.Contains(concatResult))
                    yield return $"{concat}={concatResult}";
            }
        }
    }
}
