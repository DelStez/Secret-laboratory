#include <iostream>
#include "omp.h"
#include <iomanip>
#include <ctime>
using namespace std;


int main()
{
	const int N = 1e8;
	const double h = 0.5;
	double pi;
	double sum = 0.0;
	int a;
	double t = omp_get_wtime();
	#pragma omp parallel for reduction(+: sum) num_threads(4)
	for (int k = 0; k < N; ++k) 
	{
		sum += 1.0 / pow(16.0, k) * (
			8.0 / (k*8 + 2.0) +
			4.0 / (k*8 + 3.0) +
			4.0 / (k*8 + 4.0) -
			1.0 / (k*8 + 7.0));
	}
	pi = sum * h;
	printf("pi ~ %.10f\n", pi);
	cout << "Time: " << omp_get_wtime() - t << endl;
	system("pause");
}

