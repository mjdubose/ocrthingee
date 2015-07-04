using System;
using System.Windows.Forms;

namespace OCRTHINGEE
{
    public struct Closeness
    {
        public double Closeid;
        public string Item;
    }

    internal class ConsumerItemsList
    {
        //need to have the code load these items from the database (add methods to add new items below)
        private readonly string[] _items =
        {
            "PESTICIDES", "MINERAL OIL", "EXPLOSIVES", "HYDROGEN FUEL", "DOMESTIC APPLIANCES", "CONSUMER TECHNOLOGY",
            "CLOTHING", "DRUGS", "LIQUOR", "TOBACCO", "WINE", "NARCOTICS", "BEER", "COFFEE", "TEA", "FOOD CARTRIDGES",
            "FISH", "SYNTHETIC MEAT", "ANIMAL MEAT", "GRAIN", "ALGAE",
            "FRUIT AND VEGETABLES", "FISH", "SEMICONDUCTORS", "SUPERCONDUCTORS", "POLYMERS", "PLASTICS", "MACHINERY",
            "HEL-STATIC FURNACES", "MICROBIAL FURNACES" , "MINERAL EXTRACTORS", "CROP HARVESTERS", "MARINE EQUIPMENT", "PERFORMANCE ENHANCERS",
            "PROGENITOR CELLS", "COMBAT STABILISERS", "BASIC MEDICINES", "AGRI-MEDICINES", "GOLD", "SILVER", "PALLADIUM",
            "ALUMINIUM", "LITHIUM", "COPPER", "COBALT", "URANIUM", "INDIUM", "TITANIUM", "TANTALUM", "BERTRANDITE",
            "BERYLLIUM", "GALLIUM", "COLTAN", "RUTILE", "LEPIDOLITE", "INDITE", "GALLITE", "BAUXITE","PAINITE",
            "LAND ENRICHMENT SYSTEMS", "ROBOTICS", "H.E. SUITS", "COMPUTER COMPONTENTS", "AQUAPONIC SYSTEMS",
            "AUTO-FABRICATORS", "POWER GENERATORS", "WATER PURIFIERS",
            "RESONATING SEPARATORS", "ADVANCED CATALYSERS", "ANIMAL MONITORS", "BIOREDUCING LICHEN", "COTTON", "LEATHER",
            "SYNTHETIC FABRICS", "NATURAL FABRICS", "BIOWASTE", "SCRAP", "REACTIVE ARMOUR", "PERSONAL WEAPONS",
            "NON-LETHAL WEAPONS", "ATMOSPHERIC PROCESSORS",
            "MINERAL OIL", "PESTICIDES", "CLOTHING", "ENERGY DRINKS", "CROP HARVESTERS", "MINERAL EXTRACTORS",
            "PLATINUM", "SILVER", "URANITE", "TOXIC WASTE","CHEMICAL WASTE", "BATTLE WEAPONS", "HIGH", "MED", "LOW"
        };

        public string ReturnMostSimilarWord(string ocrword)
        {
            var thisword = new Closeness {Closeid = -1.0, Item = ""};

            foreach (var word in _items)
            {
                var tmep = CalculateSimilarity(ocrword.Trim(), word.ToUpper());
                if (tmep >= 1.0)
                {
                    return word;
                }

                if (!(thisword.Closeid < tmep)) continue;
                if (!(tmep > .25)) continue;
                thisword.Closeid = tmep;
                thisword.Item = word;
            }
            MessageBox.Show(@"ocr txt :" + ocrword + @" suggested word : " + thisword.Item);

            //have option to add new word here somewhere or where this is returned.  


            return thisword.Item;
        }

        /// <summary>
        ///     Calculate percentage similarity of two strings
        ///     <param name="source">Source String to Compare with</param>
        ///     <param name="target">Targeted String to Compare</param>
        ///     <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        private double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            var stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - (stepsToSame/(double) Math.Max(source.Length, target.Length)));
        }

        /// <summary>
        ///     Returns the number of steps required to transform the source string
        ///     into the target string.
        /// </summary>
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            var sourceWordCount = source.Length;
            var targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            var distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (var i = 0; i <= sourceWordCount; distance[i, 0] = i++)
            {
            }
            for (var j = 0; j <= targetWordCount; distance[0, j] = j++)
            {
            }
            for (var i = 1; i <= sourceWordCount; i++)
            {
                for (var j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
    }
}