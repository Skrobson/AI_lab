// Network.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "CompassNetwork.h"

#include <iostream>
#include <string>


void predict(const double x, const double y)
{
	const CompassNetwork compass;
	auto pred = compass.predict(x, y);

	std::cout << "x: " << x << " y: " << y << std::endl;

	for (auto& dir : compass.CLASSES)
		std::cout << dir << "	  ";

	std::cout << std::endl;

	for (auto& p : pred)
		std::cout << p << " ";

	std::getchar();
}


int main(const int argc, char** argv)
{
	if(argc ==2)
	{
		try
		{
			const auto x = std::stod(argv[0]);
			const auto y = std::stod(argv[1]);

			predict(x, y);

			return 0;
		}
		catch(std::exception ex )
		{
			std::cout << ex.what();
		}
	}
	else
	{
		const double x = -1;
		const double y = 1;

		predict(x, y);

		return 0;
	}
	
}

