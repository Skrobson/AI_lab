#pragma once
#include <vector>

class Neuron
{
public:
	Neuron() = default;
	Neuron(size_t inputs, const std::vector<double> & weights);

	void addValue(size_t connectionIndex, double value);

	double getValue()const { return value; }
	~Neuron();

private:
	size_t numInputs;
	std::vector<double> weights;

	double value;
};

