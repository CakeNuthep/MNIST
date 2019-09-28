using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MNIST.CNN;

namespace UnitTestCNN
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMulMatrix()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "1","2","3"};
            int lengthImage = 10;
            double learningRate = 0.1;
            Matrix<double> pDeltasMatrix = DenseMatrix.Create(7, 1, 0);
            for (int i = 0; i < 7; i++)
            {
                pDeltasMatrix[i, 0] = i+1;
            }



            Matrix<double> transposePOutputWeightMatrix = DenseMatrix.Create(3, 7, 0);
            int count = 0;
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<7;j++)
                {
                    transposePOutputWeightMatrix[i,j] = ++count;
                }
            }

            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> newOutputMatrix = transposePOutputWeightMatrix.Multiply(pDeltasMatrix);

            Matrix<double> expectMatrix = DenseMatrix.Create(3, 1, 0);
            expectMatrix[0, 0] = 140;
            expectMatrix[1, 0] = 336;
            expectMatrix[2, 0] = 532;
            Assert.AreEqual(newOutputMatrix, expectMatrix);
        }

        [TestMethod]
        public void testAddMatrix()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "1", "2", "3" };
            int lengthImage = 10;
            double learningRate = 0.1;
            Matrix<double> pDeltasMatrix = DenseMatrix.Create(7, 1, 0);
            for (int i = 0; i < 7; i++)
            {
                pDeltasMatrix[i, 0] = i + 1;
            }



            Matrix<double> transposePOutputWeightMatrix = DenseMatrix.Create(7, 1, 0);
            for (int i = 0; i < 7; i++)
            {
                transposePOutputWeightMatrix[i, 0] = i + 1;
            }

            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> newOutputMatrix = transposePOutputWeightMatrix.Add(pDeltasMatrix);

            Matrix<double> expectMatrix = DenseMatrix.Create(7, 1, 0);
            expectMatrix[0, 0] = 2;
            expectMatrix[1, 0] = 4;
            expectMatrix[2, 0] = 6;
            expectMatrix[3, 0] = 8;
            expectMatrix[4, 0] = 10;
            expectMatrix[5, 0] = 12;
            expectMatrix[6, 0] = 14;

            Assert.AreEqual(newOutputMatrix, expectMatrix);
        }

        [TestMethod]
        public void testsigmoidMatrix()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "1", "2", "3" };
            int lengthImage = 10;
            double learningRate = 0.1;

            Matrix<double> transposePOutputWeightMatrix = DenseMatrix.Create(7, 1, 0);
            for (int i = 0; i < 7; i++)
            {
                transposePOutputWeightMatrix[i, 0] = i + 1;
            }
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> newOutput = cnn.sigmoidMatrix(transposePOutputWeightMatrix);

            Matrix<double> expectMatrix = DenseMatrix.Create(7, 1, 0);
            expectMatrix[0, 0] = 0.731058579;
            expectMatrix[1, 0] = 0.880797078;
            expectMatrix[2, 0] = 0.952574127;
            expectMatrix[3, 0] = 0.98201379;
            expectMatrix[4, 0] = 0.993307149;
            expectMatrix[5, 0] = 0.997527377;
            expectMatrix[6, 0] = 0.999088949;
            Assert.AreEqual(true, equalMatrix(newOutput,expectMatrix,0.0001));
        }

        [TestMethod]
        public void testConsFunction()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "1", "2", "3" };
            int lengthImage = 10;
            double learningRate = 0.1;

            double[] predic = new double[] { 1, 2, 3, 4, 5, 6, 7 };
            double[] target = new double[] { 1, 2, 3, 5, 5, 5, 5 };
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            double error;
            double expect = 3;
            if (cnn.conFunc(predic, target, out error))
            {
                Assert.AreEqual(error, expect);
            }
            else
            {
                Assert.AreEqual(0, 1);
            }
        }


        private bool equalMatrix(Matrix<double> m1, Matrix<double> m2, double delta)
        {
            for(int row=0;row<m1.RowCount;row++)
            {
                for(int col=0;col<m1.ColumnCount;col++)
                {
                    if (!(m1[row, col] >= m2[row, col]-delta && m1[row,col] <= m2[row,col]+delta))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
        [TestMethod]
        public void testAnswer()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "0","1", "2", "3" ,"4","5","6","7","8","9"};
            int lengthImage = 10;
            double learningRate = 0.1;
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> outputPredic = DenseMatrix.Create(10, 1, 0);
            outputPredic[0, 0] = 0.731058579;
            outputPredic[1, 0] = 0.880797078;
            outputPredic[2, 0] = 0.952574127;
            outputPredic[3, 0] = 0.98201379;
            outputPredic[4, 0] = 0.993307149;
            outputPredic[5, 0] = 0.997527377;
            outputPredic[6, 0] = 0.999088949;
            outputPredic[7, 0] = 0.997527377;
            outputPredic[8, 0] = 0.999999999;
            outputPredic[9, 0] = 0.997527377;

            string answer = cnn.answer(outputPredic);
            string expect = "8";
            Assert.AreEqual(answer, expect);
        }


        [TestMethod]
        public void testDotMatrix()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int lengthImage = 10;
            double learningRate = 0.1;
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> matrix2 = DenseMatrix.Create(10, 1, 0);
            matrix2[0, 0] = 1;
            matrix2[1, 0] = 2;
            matrix2[2, 0] = 3;
            matrix2[3, 0] = 4; 
            matrix2[4, 0] = 5;
            matrix2[5, 0] = 6;
            matrix2[6, 0] = 7;
            matrix2[7, 0] = 8;
            matrix2[8, 0] = 9;
            matrix2[9, 0] = 10;


            Matrix<double> matrix1 = DenseMatrix.Create(10, 1, 0);
            matrix1[0, 0] = 10;
            matrix1[1, 0] = 9;
            matrix1[2, 0] = 8;
            matrix1[3, 0] = 7;
            matrix1[4, 0] = 6;
            matrix1[5, 0] = 5;
            matrix1[6, 0] = 4;
            matrix1[7, 0] = 3;
            matrix1[8, 0] = 2;
            matrix1[9, 0] = 1;

            Matrix<double> expect = DenseMatrix.Create(10, 1, 0);
            expect[0, 0] = matrix1[0, 0] * matrix2[0, 0];
            expect[1, 0] = matrix1[1, 0] * matrix2[1, 0];
            expect[2, 0] = matrix1[2, 0] * matrix2[2, 0];
            expect[3, 0] = matrix1[3, 0] * matrix2[3, 0];
            expect[4, 0] = matrix1[4, 0] * matrix2[4, 0];
            expect[5, 0] = matrix1[5, 0] * matrix2[5, 0];
            expect[6, 0] = matrix1[6, 0] * matrix2[6, 0];
            expect[7, 0] = matrix1[7, 0] * matrix2[7, 0];
            expect[8, 0] = matrix1[8, 0] * matrix2[8, 0];
            expect[9, 0] = matrix1[9, 0] * matrix2[9, 0];

            Matrix<double> dotMatrix = cnn.dotMatrix(matrix1, matrix2);
            Assert.AreEqual(dotMatrix, expect);
        }

        [TestMethod]
        public void testDerivativeSigmoid()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int lengthImage = 10;
            double learningRate = 0.1;
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);


            Matrix<double> matrix1 = DenseMatrix.Create(10, 1, 0);
            matrix1[0, 0] = 0.904083039728828;
            matrix1[1, 0] = 0.00000941094029599077;
            matrix1[2, 0] = 0.0106577785865162;
            matrix1[3, 0] = 0.00703778917745922;
            matrix1[4, 0] = 0.000820703909257055;
            matrix1[5, 0] = 0.00243879162789633;
            matrix1[6, 0] = 0.0120445706347156;
            matrix1[7, 0] = 0.000936247465062854;
            matrix1[8, 0] = 0.00992988293783782;
            matrix1[9, 0] = 0.0000295245568786306;

            Matrix<double> expect = DenseMatrix.Create(10, 1, 0);
            expect[0, 0] = 0.08671689700351050000;
            expect[1, 0] = 0.00000941085173019352;
            expect[2, 0] = 0.010544190342117;
            expect[3, 0] = 0.00698825870095285;
            expect[4, 0] = 0.000820030354350385;
            expect[5, 0] = 0.00243284392329204;
            expect[6, 0] = 0.011899498952941;
            expect[7, 0] = 0.000935370905747017;
            expect[8, 0] = 0.00983128036267865;
            expect[9, 0] = 0.0000295236851791717;

            Matrix<double> derivaticesSigmoidMatrix = cnn.derivativeSigmoid(matrix1);
            Assert.AreEqual(equalMatrix(derivaticesSigmoidMatrix,expect,0.0000000001), true);
        }


        [TestMethod]
        public void testTransposeAndMultiply()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "1", "2", "3" };
            int lengthImage = 10;
            double learningRate = 0.1;
            Matrix<double> matrix1 = DenseMatrix.Create(7, 1, 0);
            for (int i = 0; i < 7; i++)
            {
                matrix1[i, 0] = i + 1;
            }


            Matrix<double> matrix2 = DenseMatrix.Create(3, 1, 0);
            matrix2[0, 0] = 140;
            matrix2[1, 0] = 336;
            matrix2[2, 0] = 532;

           

            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
            Matrix<double> newOutputMatrix = matrix2.TransposeAndMultiply(matrix1);
            Matrix<double> exprect = DenseMatrix.Create(3, 7, 0);
            int count = 0;
            exprect[0, 0] = 140;
            exprect[0, 1] = 280;
            exprect[0, 2] = 420;
            exprect[0, 3] = 560;
            exprect[0, 4] = 700;
            exprect[0, 5] = 840;
            exprect[0, 6] = 980;

            exprect[1, 0] = 336;
            exprect[1, 1] = 672;
            exprect[1, 2] = 1008;
            exprect[1, 3] = 1344;
            exprect[1, 4] = 1680;
            exprect[1, 5] = 2016;
            exprect[1, 6] = 2352;

            exprect[2, 0] = 532;
            exprect[2, 1] = 1064;
            exprect[2, 2] = 1596;
            exprect[2, 3] = 2128;
            exprect[2, 4] = 2660;
            exprect[2, 5] = 3192;
            exprect[2, 6] = 3724;
            Assert.AreEqual(newOutputMatrix, exprect);
        }

        [TestMethod]
        public void testSubtrackMatrix()
        {
            int hiddenlayer = 30;
            string[] allLabel = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int lengthImage = 10;
            double learningRate = 0.1;
            MNIST.CNN.CNN cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);


            Matrix<double> matrix1 = DenseMatrix.Create(10, 1, 0);
            matrix1[0, 0] = 10;
            matrix1[1, 0] = 9;
            matrix1[2, 0] = 8;
            matrix1[3, 0] = 7;
            matrix1[4, 0] = 6;
            matrix1[5, 0] = 5;
            matrix1[6, 0] = 4;
            matrix1[7, 0] = 3;
            matrix1[8, 0] = 2;
            matrix1[9, 0] = 1;


            Matrix<double> matrix2 = DenseMatrix.Create(10, 1, 0);
            matrix2[0, 0] = 1;
            matrix2[1, 0] = 2;
            matrix2[2, 0] = 3;
            matrix2[3, 0] = 4;
            matrix2[4, 0] = 5;
            matrix2[5, 0] = 6;
            matrix2[6, 0] = 7;
            matrix2[7, 0] = 8;
            matrix2[8, 0] = 9;
            matrix2[9, 0] = 10;

            Matrix<double> expect = DenseMatrix.Create(10, 1, 0);
            expect[0, 0] = 9;
            expect[1, 0] = 7;
            expect[2, 0] = 5;
            expect[3, 0] = 3;
            expect[4, 0] = 1;
            expect[5, 0] = -1;
            expect[6, 0] = -3;
            expect[7, 0] = -5;
            expect[8, 0] = -7;
            expect[9, 0] = -9;

            Matrix<double> subtractMatrix = matrix1.Subtract(matrix2);
            Assert.AreEqual(subtractMatrix, expect);
        }

    }
}
