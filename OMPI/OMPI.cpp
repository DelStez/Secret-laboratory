#include <iostream>
#include "omp.h"
#include <iomanip>
#include <ctime>
using namespace std;


int main()
{
	const int N = 1e8;
	double pi;
	double sum = 0.0;
	int a;
	double t = omp_get_wtime();
	#pragma omp parallel for reduction(+: sum) num_threads(8)
	for (int k = 0; k < N; ++k) 
	{
		sum += (1.0 / pow(16.0, k) )* (
			4.0 / (k * 8 + 1.0) -
			2.0 / (k * 8 + 4.0) -
			1.0 / (k * 8 + 5.0) -
			1.0 / (k * 8 + 6.0));
	}
	pi = sum;
	cout << "Time: " << omp_get_wtime() - t << endl;
	printf("pi ~ %.10f\n", pi);
	system("pause");
}

