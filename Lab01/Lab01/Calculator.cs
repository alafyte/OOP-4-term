using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Calculator : ICalculator
    {
        private static readonly float[] belarussianSizes = { 34, 35, 36, 37, 38, 39, 40};
        private static readonly float[] USASizes = { 4.5f, 5.5f, 6, 7, 8, 8.5f, 9.5f};
        private static readonly float[] britishSizes = { 2, 3, 4, 4.5f, 5.5f, 6, 7};
        private static readonly float[] europeanSizes = { 35, 36, 37, 38, 39, 40, 41};
        private static readonly List<float[]> tableOfSizes = new List<float[]>() 
        { europeanSizes, belarussianSizes, USASizes, britishSizes  };

        public float calculate(float currentSize, int currentType, int resultType)
        {
            var convert = tableOfSizes[currentType].Zip(tableOfSizes[resultType], (s, i) => new { s, i })
                          .ToDictionary(item => item.s, item => item.i);
            float value;
            convert.TryGetValue(currentSize, out value);
            if (value == 0)
                throw new ArgumentException();
            else
                return value;
        }
    }
}
