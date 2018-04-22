#pragma once
#include "Neuron.h"
class CompassNetwork
{
	using Layer = std::vector<Neuron>;
public:
	CompassNetwork();

	std::vector<double> predict(double x, double y)const;

	static const std::vector<std::string> CLASSES;

private:
	double sigmoid(const double x) const;

	void normalize( double& x,  double& y) const;
	Layer input;
	Layer output;

	const size_t inSize; 
	const size_t outSize; 
};

