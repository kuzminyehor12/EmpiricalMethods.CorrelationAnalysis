using DataAnalysis1.Computing.Computing;
using EmpiricMethods_Lab1.DataProcessing.DataSource;
using EmpiricMethods_Lab1.DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricMethods_Lab1.Computing.Computing
{
    public class MultiDimensionalLinearRegressionComputing
    {
        public VariationalSeries DependentSource { get; }
        public VariationalSeries[] IndependentSources { get; }
        public const double Alpha = 0.05;
        public int N => DependentSource.Series.Count;
        public int P => IndependentSources.Length;
        public double Criteria
        {
            get
            {
                var quantileComputing = new SeriesQuantileComputing();
                return quantileComputing.ComputeStudentQuantile(1 - Alpha / 2, N - P - 1);
            }
        }
        public MultiDimensionalLinearRegressionComputing(
            VariationalSeries dependentSource,
            params VariationalSeries[] independentSources)
        {
            DependentSource = dependentSource;
            IndependentSources = independentSources;
        }

        public Matrix Matrix()
        {
            double[][] matrix = new double[N][];

            for (int i = 0; i < N; i++)
            {
                matrix[i] = new double[P + 1];
            }
            
            for (int i = 0; i < N; i++)
            {
                matrix[i][0] = 1;
                for (int j = 1; j < P + 1; j++)
                {
                    matrix[i][j] = IndependentSources[j - 1].Series[i];
                }
            }

            return new Matrix(matrix);
        }

        public Matrix Vector()
        {
            double[][] matrix = new double[N][];
            for (int i = 0; i < N; i++)
            {
                matrix[i] = new double[1];
            }

            for (int i = 0; i < N; i++)
            {
                matrix[i][0] = DependentSource.Series[i];
            }

            return new Matrix(matrix);
        }

        public Matrix Parameters()
        {
            var squaredMatrix = Matrix().Transpose() * Matrix();
            return squaredMatrix.Invert() * Matrix().Transpose() * Vector();
        }

        public double ResidualVariance()
        {
            var sumOfSquaredErrors = (Vector() - Matrix() * Parameters()).Transpose() * (Vector() - Matrix() * Parameters());
            return sumOfSquaredErrors[0,0] / (N - P - 1);
        }
        public double[] Variances()
        {
            var a = (Matrix().Transpose() * Matrix()).Invert();
            var dc = a.Multiply(ResidualVariance());
            var variances = new double[P + 1];

            for (int i = 0; i < P + 1; i++)
            {
                variances[i] = dc[i, i];
            }

            return variances;
        }

        public Tuple<double, double>[] Intervals()
        {
            var parameters = Parameters();
            var variances = Variances();
            var intervals = new Tuple<double, double>[P + 1];

            for (int i = 0; i < P + 1; i++)
            {
                var inf = parameters[i, 0] - Criteria * Math.Sqrt(variances[i]);
                var sup = parameters[i, 0] + Criteria * Math.Sqrt(variances[i]);
                intervals[i] = Tuple.Create(inf, sup);
            }

            return intervals;
        }

        public Tuple<double, string>[] Statistics()
        {
            var statistics = new Tuple<double, string>[P + 1];
            var parameters = Parameters();
            var variances = Variances();

            for (int i = 0; i < P + 1; i++)
            {
                var statistic = parameters[i, 0] / Math.Sqrt(variances[0]);
                var summary = Math.Abs(statistic) <= Criteria ? NullEqual.Equal : NullEqual.NotEqual;
                statistics[i] = Tuple.Create(statistic, summary);
            }

            return statistics;
        }
    }
}
