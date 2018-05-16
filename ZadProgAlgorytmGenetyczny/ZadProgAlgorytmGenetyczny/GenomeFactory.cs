using System;
using System.Collections.Generic;
using System.Text;

namespace ZadProgAlgorytmGenetyczny
{
    class GenomeFactory
    {
        private GenesFactory _genesFactory;
        private Random _random;
        private double _mutationRate;

        public GenomeFactory(GenesFactory genesFactory, Random random, double mutationRate)
        {
            _genesFactory = genesFactory;
            _random = random;
            _mutationRate = mutationRate;
        }

        public Genome Create(int genesLength, bool fillGenes)
        {
            var genes = _genesFactory.Create(genesLength, fillGenes);
            return new Genome(genes, _mutationRate, _random);
        }

        public GenomeCrossoverResult Crossover(Genome genome1, Genome genome2)
        {
            var result = new GenomeCrossoverResult();
            int pos = Convert.ToInt32(_random.NextDouble() * genome1.GenesCount);
            result.Child1 = Create(genome1.GenesCount, false);
            result.Child2 = Create(genome1.GenesCount, false);
            for (int i = 0; i < genome1.GenesCount; i++)
            {
                if (i < pos)
                {
                    result.Child1.ReplaceGene(i, genome1.GetGene(i));
                    result.Child2.ReplaceGene(i, genome2.GetGene(i));
                }
                else
                {
                    result.Child1.ReplaceGene(i, genome2.GetGene(i));
                    result.Child2.ReplaceGene(i, genome1.GetGene(i));
                }
            }
            return result;
        }
    }
}
