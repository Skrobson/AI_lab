#include "stdafx.h"
#include "Neuron.h"
#include <cassert>

Neuron::Neuron(size_t inputs, const std::vector<double>& weights): numInputs(inputs), weights(weights), value(0)
{
	//assert(numInputs == weights.size());
}

void Neuron::addValue(size_t connectionIndex, double value)
{
	//assert(weights.size() >connectionIndex);

	this->value += value * weights.at(connectionIndex);
}

Neuron::~Neuron()
{
}
