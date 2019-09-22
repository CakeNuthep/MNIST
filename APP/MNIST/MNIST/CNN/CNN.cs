using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNIST.CNN
{
    class CNN
    {
        int numberHiddenLayer;
        double learningRate;
        string[] allLabel;
        Matrix<double> hWeightMatrix;
        Matrix<double> pOutputWeightMatrix;

        public CNN(int hiddenLayer,string[] allLabel,int dataLength,double learningRate)
        {
            this.numberHiddenLayer = hiddenLayer;
            this.learningRate = learningRate;
            this.allLabel = allLabel;
            hWeightMatrix = DenseMatrix.Create(this.numberHiddenLayer, dataLength, 0);
            randomMatrix(hWeightMatrix);

            pOutputWeightMatrix = DenseMatrix.Create(this.allLabel.Length, this.numberHiddenLayer, 0);
            randomMatrix(pOutputWeightMatrix);
        }


        public void train(double[] data,double[] target)
        {
            Matrix<double> mData = convertArrayToMatrix(data);
            Matrix<double> mTarget = convertArrayToMatrix(target);
            Matrix<double> predictData;
            Matrix<double> outputHiddenData;
            double error = predict(mData,target,out outputHiddenData, out predictData);
            improveUseGaussian(mData, mTarget, outputHiddenData, predictData);
            
        }


        public void improveUseGaussian(Matrix<double> data,Matrix<double> target,Matrix<double> outputHiddenMatrix, Matrix<double> predict)
        {
            //derivative cons function
            Matrix<double> pSubtractMatrix = target.Subtract(predict);

            //derivative of the sigmoid
            Matrix<double> pDSigmoidMatrix = derivativeSigmoid(predict);

            //deltas
            Matrix<double> pDeltasMatrix = dotMatrix(pDSigmoidMatrix, pSubtractMatrix);

            Matrix<double> pNewOutputWeightMatrix = pDeltasMatrix.TransposeAndMultiply(outputHiddenMatrix);
            pNewOutputWeightMatrix = pOutputWeightMatrix.Subtract(pNewOutputWeightMatrix);

            Matrix<double> transposePOutputWeightMatrix = pOutputWeightMatrix.Transpose();

            Matrix<double> newOutputMatrix = transposePOutputWeightMatrix.Multiply(pDeltasMatrix);

            //derivative of the sigmoid
            Matrix<double> dSigmoidMatrix = derivativeSigmoid(outputHiddenMatrix);

            //deltas
            Matrix<double> deltasMatrix = dotMatrix(dSigmoidMatrix, newOutputMatrix);

            Matrix<double> transposeData = data.Transpose();

            Matrix<double> newHMatrix = deltasMatrix.Multiply(transposeData);

            hWeightMatrix = newHMatrix;
            pOutputWeightMatrix = pNewOutputWeightMatrix;
        }

        public Matrix<double> dotMatrix(Matrix<double> matrix1,Matrix<double> matrix2)
        {
            Matrix<double> dotMatrix = matrix1.Clone();
            if (matrix1.RowCount == matrix2.RowCount 
                && matrix1.ColumnCount == matrix2.ColumnCount)
            {
                
                for (int line = 0; line < matrix1.RowCount; line++)
                {
                    for (int col = 0; col < matrix1.ColumnCount; col++)
                    {
                        dotMatrix[line, col] = matrix1[line, col] * matrix2[line, col];
                    }

                }
            }
            return dotMatrix;
        }

        public Matrix<double> derivativeSigmoid(Matrix<double> matrix)
        {
            Matrix<double> dSigmoinM = matrix.Clone();
            for (int line = 0; line < matrix.RowCount; line++)
            {
                for (int col = 0; col < matrix.ColumnCount; col++)
                {
                    dSigmoinM[line, col] = matrix[line, col]*(1-matrix[line,col]);
                }

            }
            return dSigmoinM;
        }
        public bool conFunc(double[] predict, double[] target,out double error)
        {
            double[] errorArr = new double[predict.Length];
            error = 0;
            if(predict.Length == target.Length)
            {
                for(int i=0;i < predict.Length;i++)
                {
                    errorArr[i] = 0.5 * Math.Pow(target[i] - predict[i], 2);
                    error += errorArr[i];
                }
                return true;
            }
            return false;
        }

        public double predict(Matrix<double> data, double[] target,out Matrix<double> output,out Matrix<double> pOutput)
        {

            Matrix<double> sumWeightIMatrix = hWeightMatrix.Multiply(data);
            Matrix<double> biasMatrix = createBias(this.numberHiddenLayer);
            Matrix<double> netMatrix = sumWeightIMatrix.Add(biasMatrix);
            Matrix<double> outputMatrix = sigmoidMatrix(netMatrix);

            
            Matrix<double> sumWeightHMatrix = pOutputWeightMatrix.Multiply(outputMatrix);
            Matrix<double> pBiasMatrix = createBias(this.allLabel.Length);
            Matrix<double> pNetMatrix = sumWeightHMatrix.Add(pBiasMatrix);
            Matrix<double> pOutputMatrix = sigmoidMatrix(pNetMatrix);

            double error = -1;
            pOutput = pOutputMatrix;
            output = outputMatrix;
            if (conFunc(pOutputMatrix.Column(0).ToArray(), target, out error))
            {
                return error;
            }

            return error;

        }

        public Matrix<double> predict(Matrix<double> data)
        {

            Matrix<double> sumWeightIMatrix = hWeightMatrix.Multiply(data);
            Matrix<double> biasMatrix = createBias(this.numberHiddenLayer);
            Matrix<double> netMatrix = sumWeightIMatrix.Add(biasMatrix);
            Matrix<double> outputMatrix = sigmoidMatrix(netMatrix);


            Matrix<double> sumWeightHMatrix = pOutputWeightMatrix.Multiply(outputMatrix);
            Matrix<double> pBiasMatrix = createBias(this.allLabel.Length);
            Matrix<double> pNetMatrix = sumWeightHMatrix.Add(pBiasMatrix);
            Matrix<double> pOutputMatrix = sigmoidMatrix(pNetMatrix);

            return pOutputMatrix;

        }


        public string answer(Matrix<double> pOutputMatrix)
        {
            int lineAnswer=0;
            for (int line = 1; line < pOutputMatrix.RowCount; line++)
            {
                if (pOutputMatrix[line, 0] > pOutputMatrix[lineAnswer, 0])
                {
                    lineAnswer = line;
                }
            }
            return this.allLabel[lineAnswer];

        }
        public Matrix<double> sigmoidMatrix(Matrix<double> matrix)
        {
            Matrix<double> sigmoinM = matrix.Clone();
            for (int line = 0; line < matrix.RowCount; line++)
            {
                for (int col = 0; col < matrix.ColumnCount; col++)
                {
                    sigmoinM[line, col] = 1 / (1 + Math.Exp(-1 * matrix[line, col]));
                }

            }
            return sigmoinM;
        }

        public Matrix<double> createBias(int numberData,bool isRow = true)
        {
            double[] bias = createArrayRandom(numberData);
            Matrix<double> biasMatrix = convertArrayToMatrix(bias);
            return biasMatrix;
        }

        public double[] createArrayRandom(int numberArray)
        {
            double[] values = new double[numberArray];

            Random random = new Random();
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = random.NextDouble() * 2 - 1;
            }
            return values;
        }

        public Matrix<double> convertArrayToMatrix(double[] arr,bool isRow=true)
        {
            Matrix<double> matrix;
            if (isRow)
            {
                matrix = DenseMatrix.Create(arr.Length, 1, -1);
                for (int i = 0; i < arr.Length; i++)
                {
                    matrix[i, 0] = arr[i];
                }
            }
            else
            {
                matrix = DenseMatrix.Create(1, arr.Length, -1);
                for (int i = 0; i < arr.Length; i++)
                {
                    matrix[0, i] = arr[i];
                }
            }
            return matrix;
        }

        public void randomMatrix(Matrix<double> matrix)
        {
            for (int line = 0; line < matrix.RowCount; line++)
            {
                for (int col = 0; col < matrix.ColumnCount; col++)
                {
                    Random random = new Random();
                    matrix[line, col] = random.NextDouble() * 2 -1;
                }
                
            }
        }

        
    }
}
