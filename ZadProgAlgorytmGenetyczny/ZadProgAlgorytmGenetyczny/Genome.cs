using System;
using System.Collections.Generic;
using System.Text;

namespace ZadProgAlgorytmGenetyczny
{
    class Genome : IComparable
    {
        private IList<double> _genes;
        private double _mutationRate;
        private Random _random;

        public IList<double> Genes => _genes;
        public int GenesCount => _genes.Count;
        public double MutationRate => _mutationRate;

        public double Fitness { get; internal set; }

        public Genome(IList<double> genes, double mutationRate, Random random)
        {
            _genes = genes;
            _mutationRate = mutationRate;
            _random = random;
        }

        public double GetGene(int index)
        {
            return _genes[index];
        }

        public void ReplaceGene(int index, double newValue)
        {
            _genes[index] = newValue;
        }

        public void Mutate()
        {
            for (int pos = 0; pos < _genes.Count; pos++)
            {
                if (_random.NextDouble() < _mutationRate)
                    _genes[pos] = (_genes[pos] + _random.NextDouble()) / 2.0;
            }
        }

        public int CompareTo(object obj)
        {
            var y = (Genome)obj;
            if (Fitness > y.Fitness)
                return 1;
            else if (Fitness == y.Fitness)
                return 0;
            else
                return -1;
        }
    }
}
