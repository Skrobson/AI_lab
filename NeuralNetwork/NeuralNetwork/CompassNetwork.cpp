#include "stdafx.h"
#include "CompassNetwork.h"

const std::vector<std::string> CompassNetwork::CLASSES = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

CompassNetwork::CompassNetwork() : inSize(2), outSize(8)
{
	using Weights = std::vector<double>;

	//input = Layer(inSize);
	//std::vector<double> inputWeights(inSize);
	//std::fill(inputWeights.begin(), inputWeights.end(), 1);

	output.push_back(Neuron(2,Weights{0.35,0.65}));
	output.push_back(Neuron(2,Weights{0.52,0.52}));
	output.push_back(Neuron(2,Weights{0.65,0.35}));
	output.push_back(Neuron(2,Weights{0.52,-0.52}));
	output.push_back(Neuron(2,Weights{0.35,-0.65}));
	output.push_back(Neuron(2,Weights{-0.52,-0.52}));
	output.push_back(Neuron(2,Weights{-0.65,0.35}));
	output.push_back(Neuron(2,Weights{-0.52,0.52}));

}

std::vector<double> CompassNetwork::predict(double x, double y) const
{
	double ax = x;
	double ay = y;

	std::vector<double> prediction;

	normalize(x, y);

	for(Neuron neuron : output)
	{
		neuron.addValue(0, x);
		neuron.addValue(1, y);
		//auto sig = sigmoid(neuron.getValue());
		auto sig = neuron.getValue();

		prediction.push_back(sig);
	}

	return prediction;
}

double CompassNetwork::sigmoid(const double x) const
{
	return 1.0 / (1.0 + std::exp(-x));
}

void CompassNetwork::normalize(double&  x,  double& y) const
{
	 const auto l = std::fabs(std::sqrt((x * x) + (y * y)));
	 x /= l;
	 y /= l;
}
