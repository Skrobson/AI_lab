using System;
using System.Collections.Generic;
using System.Text;

namespace ZadProgAlgorytmGenetyczny
{
    class GenesFactory
    {
        private Random _random;
        
        public GenesFactory(Random random)
        {
            _random = random;
        }

        public IList<double> Create(int length, bool fillGenes)
        {
            var genes = new List<double>(length);
            for (int i = 0; i < length; i++)
            {
                genes.Add(fillGenes ? _random.NextDouble() : 0d);
            }
            return genes;
        }
    }
}
