using System;
using System.Collections.Generic;

namespace ZadProgAlgorytmGenetyczny
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Crossover		= 80%
            //  Mutation		=  5%
            //  Population size = 100
            //  Generations		= 2000
            //  Genome size		= 2
            var crossover = 0.8;
            var mutationRate = 0.05;
            var populationSize = 100;
            var generations = 2000;
            var genomeSize = 2;
            //create objects
            var random = new Random((int)DateTime.Now.Ticks);
            var genesFactory = new GenesFactory(random);
            var genomeFactory = new GenomeFactory(genesFactory, random, mutationRate);
            var geneticAlghoritm = new GeneticAlghoritm(random, FitnessFunction, genomeFactory, crossover, populationSize, generations, genomeSize);
            //execute alghoritm
            geneticAlghoritm.Execute();
            //show results
            ShowResults(true, geneticAlghoritm);
            ShowResults(false, geneticAlghoritm);
            //
            Console.ReadKey();
        }

        private static void ShowResults(bool theBest, GeneticAlghoritm geneticAlghoritm)
        {
            IList<double> values;
            double fitness;

            if (theBest)
            {
                geneticAlghoritm.GetBest(out values, out fitness);
                Console.WriteLine("Best ({0}):", fitness);
            }  
            else
            {
                geneticAlghoritm.GetWorst(out values, out fitness);
                Console.WriteLine("\nWorst ({0}):", fitness);
            }

            foreach(var value in values)
                System.Console.WriteLine("{0} ", value);
        }

        private static double FitnessFunction(IList<double> values)
        {
            double x = values[0];
            double y = values[1];
            double n = 8;

            double f1 = Math.Pow(15 * x * y * (1 - x) * (1 - y) * Math.Sin(n * Math.PI * x) * Math.Sin(n * Math.PI * y), 2);
            return f1;
        }
    }
}
