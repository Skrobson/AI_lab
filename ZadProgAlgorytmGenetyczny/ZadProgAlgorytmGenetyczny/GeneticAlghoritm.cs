using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZadProgAlgorytmGenetyczny
{
    class GeneticAlghoritm
    {
        private readonly Random _random;
        private Func<IList<double>, double> _getFitnessFunc;
        private GenomeFactory _genomeFactory;
        private double _mutationRate;
        private double _crossoverRate;
        private int _populationSize;
        private int _generationSize;
        private int _genomeSize;

        private double _totalFitness;
        private List<double> _fitnessTable;
        private List<Genome> _thisGeneration;
        private List<Genome> _nextGeneration;

        public GeneticAlghoritm(Random random, Func<IList<double>, double> getFitnessFunc, GenomeFactory genomeFactory, double crossoverRate, int populationSize, int generationSize, int genomeSize)
        {
            _random = random;
            _getFitnessFunc = getFitnessFunc;
            _genomeFactory = genomeFactory;
            _crossoverRate = crossoverRate;
            _populationSize = populationSize;
            _generationSize = generationSize;
            _genomeSize = genomeSize;
        }

        public void GetBest(out IList<double> values, out double fitness)
        {
            Genome g = _thisGeneration.Last();
            values = g.Genes;
            fitness = g.Fitness;
        }

        public void GetWorst(out IList<double> values, out double fitness)
        {
            Genome g = _thisGeneration.First();
            values = g.Genes;
            fitness = g.Fitness;
        }

        public void Execute()
        {
            _fitnessTable = new List<double>();
            _thisGeneration = new List<Genome>(_generationSize);
            _nextGeneration = new List<Genome>(_generationSize);

            CreateGenomes();
            RankPopulation();

            for (int i = 0; i < _generationSize; i++)
            {
                CreateNextGeneration();
                RankPopulation();
            }
        }

        private void CreateNextGeneration()
        {
            _nextGeneration.Clear();

            for (int i = 0; i < _populationSize; i += 2)
            {
                int pidx1 = RouletteSelection();
                int pidx2 = RouletteSelection();
                Genome parent1, parent2, child1, child2;
                parent1 = _thisGeneration[pidx1];
                parent2 = _thisGeneration[pidx2];

                if (_random.NextDouble() < _crossoverRate)
                {
                    var result = _genomeFactory.Crossover(parent1, parent2);
                    child1 = result.Child1;
                    child2 = result.Child2;
                }
                else
                {
                    child1 = parent1;
                    child2 = parent2;
                }
                child1.Mutate();
                child2.Mutate();

                _nextGeneration.Add(child1);
                _nextGeneration.Add(child2);
            }
            _thisGeneration.Clear();
            foreach(var nextGenerationGenome in _nextGeneration)
            {
                _thisGeneration.Add(nextGenerationGenome);
            }     
        }

        private int RouletteSelection()
        {
            double randomFitness = _random.NextDouble() * _totalFitness;
            int idx = -1;
            int first = 0;
            int last = _populationSize - 1;
            int mid = (last - first) / 2;

            while (idx == -1 && first <= last)
            {
                if (randomFitness < _fitnessTable[mid])
                {
                    last = mid;
                }
                else if (randomFitness > _fitnessTable[mid])
                {
                    first = mid;
                }
                mid = (first + last) / 2;
                if ((last - first) == 1)
                    idx = last;
            }
            return idx;
        }

        private void RankPopulation()
        {
            _totalFitness = 0d;
            foreach(var thisGenerationGenome in _thisGeneration)
            {
                thisGenerationGenome.Fitness = _getFitnessFunc(thisGenerationGenome.Genes);
                _totalFitness += thisGenerationGenome.Fitness;
            }
            _thisGeneration.Sort();

            double fitness = 0.0;
            _fitnessTable.Clear();
            foreach(var thisGenerationGenome in _thisGeneration)
            {
                fitness += thisGenerationGenome.Fitness;
                _fitnessTable.Add(fitness);
            }
        }

        private void CreateGenomes()
        {
            for (int i = 0; i < _populationSize; i++)
            {
                Genome genome = _genomeFactory.Create(_genomeSize, true);
                _thisGeneration.Add(genome);
            }
        }
    }
}
