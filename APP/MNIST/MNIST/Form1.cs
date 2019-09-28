using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNIST
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Bitmap bitMap;
        string[] allLabel = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int lengthImage = 784;
        MNIST.CNN.CNN cnn;
        int trainCount = 0;
        Reader.MnistReader mnist;
        int countStepTest = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitMap = new Bitmap(pictureBox_draw.Size.Width, pictureBox_draw.Size.Height);
            pictureBox_draw.Image = bitMap;
            g = Graphics.FromImage(bitMap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
        }

        private void PictureBox_draw_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            pictureBox_draw.Cursor = Cursors.Cross;
            
        }

        private void PictureBox_draw_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            pictureBox_draw.Cursor = Cursors.Default;
        }

        private void PictureBox_draw_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!=-1&&y!=-1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                pictureBox_draw.Image = bitMap;
            }
        }

        private void Button_clear_Click(object sender, EventArgs e)
        {
            pictureBox_draw.Image = bitMap;
            g.Clear(Color.White);
        }

        private void Button_predict_Click(object sender, EventArgs e)
        {
            if (bitMap != null)
            {
                Bitmap bitmap28_28 = new Bitmap(bitMap, new Size(28, 28));
                

                int[] flat = convertImageToFlatGrayScale(bitmap28_28);
                double[] flatDouble = nomalizeData(flat);
                Matrix<double> dataMatrix = cnn.convertArrayToMatrix(flatDouble);
                Matrix<double> pOutputMatrix = cnn.predict(dataMatrix);
                string answer = cnn.answer(pOutputMatrix);
                label_target.Text = answer;

                Bitmap img;
                if (convertFlatToImage(flat, 28, 28, out img))
                {
                    //pictureBox_draw.Image = img;
                }
            }
        }

        private int[] convertImageToFlatGrayScale(Bitmap img)
        {
            List<int> image_flat_list = new List<int>(); 
            for (x = 0; x < img.Width; x++)
            {
                for (y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    //New grayscale image = ( (0.3 * R) + (0.59 * G) + (0.11 * B) ).
                    int newColor = 255 - (int)((0.3 * pixelColor.R) + (0.59 * pixelColor.G) + (0.11 * pixelColor.B));
                    image_flat_list.Add(newColor);
                }
            }
            return image_flat_list.ToArray();
        }

        public bool convertFlatToImage(int[] flat,int width,int height,out Bitmap img)
        {
            if (width * height == flat.Length)
            {
                int i = 0;
                img = new Bitmap(width, height);
                for (x = 0; x < img.Width; x++)
                {
                    for(y=0;y<img.Height;y++)
                    {
                        Color pixelColor = Color.FromArgb(255, flat[i], flat[i], flat[i]);
                        img.SetPixel(x, y, pixelColor);
                        i++;
                    }
                }
                return true;
            }
            img = null;
            return false;
        }

        public int[] Convert2ArrayTo1Array(byte[,] data)
        {
            int count = 0;
            int height = data.GetLength(0);
            int weight = data.GetLength(1);
            int[] flat = new int[height * weight];
            for(int i=0;i<data.GetLength(0);i++)
            {
                for(int j=0;j< data.GetLength(1);j++)
                {
                    flat[count] = data[i, j];
                    count++;
                }
            }
            return flat;
        }

        private void Button_train_Click(object sender, EventArgs e)
        {
            double learningRate;
            int hiddenlayer;
            if (double.TryParse(textBox_learningRate.Text, out learningRate)
                && int.TryParse(textBox_hiddenLayer.Text, out hiddenlayer))
            {

                if (cnn == null)
                {
                    cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
                }
                if (mnist == null)
                {
                    mnist = new Reader.MnistReader(textBox_pathTrainFile.Text
                        ,textBox_pathLabelFile.Text
                        ,textBox_pathTestFile.Text
                        ,textBox_pathTestLabelFile.Text);
                }

                for (int numTrain = 0; numTrain <= 100; numTrain++)
                {
                    foreach (var image in mnist.ReadTrainingData())
                    {
                        int labelDataSet = image.Label;
                        double[] oneHotEncoding = convertLabelToOneHotEncoding(labelDataSet, allLabel.Length);
                        byte[,] images = image.Data;
                        int[] flat = Convert2ArrayTo1Array(images);
                        double[] flatDouble = nomalizeData(flat);
                        //double[] flatDouble = flat.Select(Convert.ToDouble).ToArray();
                        cnn.train(flatDouble, oneHotEncoding);
                        trainCount++;
                        //MessageBox.Show(answer);
                        #region test draw digit
                        ////8 digit
                        //int[] flat = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,43,47,47,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,108,249,253,253,208,207,207,207,149,65,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,184,254,253,253,253,254,253,253,253,254,253,213,25,0,0,0,0,0,0,0,0,0,0,0,0,0,55,203,254,254,199,127,127,60,93,84,68,151,222,254,161,0,0,0,0,0,0,0,0,0,0,0,0,0,138,253,253,199,19,0,0,0,0,0,0,0,155,253,211,0,0,0,0,0,0,0,0,0,0,0,0,0,138,253,253,17,0,0,0,0,0,0,0,74,241,253,211,0,0,0,0,0,0,0,0,0,0,0,0,0,105,253,253,102,0,0,0,0,0,0,34,229,253,253,160,0,0,0,0,0,0,0,0,0,0,0,0,0,0,149,254,229,40,0,0,0,38,153,254,254,254,180,25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19,198,254,207,9,34,72,235,253,253,224,139,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,211,253,215,240,254,253,234,128,17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,102,229,253,253,253,228,77,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,70,170,254,254,254,254,254,254,119,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26,130,230,254,253,253,185,115,64,211,253,248,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,166,232,253,253,247,162,46,13,7,91,245,253,254,56,0,0,0,0,0,0,0,0,0,0,0,0,0,0,128,253,253,253,210,93,127,159,204,253,253,253,228,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,134,241,254,255,254,254,254,254,254,254,228,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,27,115,140,206,206,206,207,206,123,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
                        //};
                        //int[] flat = convertImageToFlatGrayScale(bitmap28_28);
                        //Bitmap img;
                        //if (convertFlatToImage(flat, 28, 28, out img))
                        //{
                        //    pictureBox_draw.Image = new Bitmap(img, new Size(pictureBox_draw.Width, pictureBox_draw.Height));
                        //}
                        #endregion
                        //break;
                    }
                }
                MessageBox.Show("Train finish "+trainCount);
            }
        }

        public double[] nomalizeData(int[] data)
        {
            double[] result = new double[data.Length];
            for(int i=0;i<data.Length;i++)
            {
                result[i] = data[i] / 127.0 - 1.0; 
            }
            return result;
        }
        public double[] convertLabelToOneHotEncoding(int label, int length)
        {
            double[] oneHotEncoding = new double[length];
            oneHotEncoding[label] = 1;
            return oneHotEncoding;
        }

        private void Button_testOneImage_Click(object sender, EventArgs e)
        {
            double learningRate;
            int hiddenlayer;
            int count = 0;

            if (double.TryParse(textBox_learningRate.Text, out learningRate)
                && int.TryParse(textBox_hiddenLayer.Text, out hiddenlayer))
            {

                if (cnn == null)
                {
                    cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
                }
                if (mnist == null)
                {
                    mnist = new Reader.MnistReader(textBox_pathTrainFile.Text
                        , textBox_pathLabelFile.Text
                        , textBox_pathTestFile.Text
                        , textBox_pathTestLabelFile.Text);
                }
                foreach (var image in mnist.ReadTestData())
                {
                    if (count == countStepTest)
                    {
                        int labelDataSet = image.Label;
                        double[] oneHotEncoding = convertLabelToOneHotEncoding(labelDataSet, allLabel.Length);
                        byte[,] images = image.Data;
                        int[] flat = Convert2ArrayTo1Array(images);
                        double[] flatDouble = nomalizeData(flat);
                        //double[] flatDouble = flat.Select(Convert.ToDouble).ToArray();

                        Bitmap bmp;
                        if (convertFlatToImage(flat, 28, 28, out bmp))
                        {
                            pictureBox_draw.Image = bmp;
                        }
                        Matrix<double> flatMatrix = cnn.convertArrayToMatrix(flatDouble);


                        Matrix<double> pOutputMatrix = cnn.predict(flatMatrix);
                        string answer = cnn.answer(pOutputMatrix);
                        label_target.Text = answer;
                        countStepTest =(countStepTest +1)%1000;
                        break;
                    }
                    count++;
                }
                mnist.closeRead();
            }
        }

        private void Button_TestAll_Click(object sender, EventArgs e)
        {
            double learningRate;
            int hiddenlayer;
            int count = 0;
            int countHit = 0;
            int countMiss = 0;

            if (double.TryParse(textBox_learningRate.Text, out learningRate)
                && int.TryParse(textBox_hiddenLayer.Text, out hiddenlayer))
            {

                if (cnn == null)
                {
                    cnn = new MNIST.CNN.CNN(hiddenlayer, allLabel, lengthImage, learningRate);
                }
                if (mnist == null)
                {
                    mnist = new Reader.MnistReader(textBox_pathTrainFile.Text
                        , textBox_pathLabelFile.Text
                        , textBox_pathTestFile.Text
                        , textBox_pathTestLabelFile.Text);
                }
                foreach (var image in mnist.ReadTestData())
                {
                    
                    int labelDataSet = image.Label;
                    double[] oneHotEncoding = convertLabelToOneHotEncoding(labelDataSet, allLabel.Length);
                    byte[,] images = image.Data;
                    int[] flat = Convert2ArrayTo1Array(images);
                    double[] flatDouble = flat.Select(Convert.ToDouble).ToArray();

                        
                    Matrix<double> flatMatrix = cnn.convertArrayToMatrix(flatDouble);

                        
                    Matrix<double> pOutputMatrix = cnn.predict(flatMatrix);
                    string answer = cnn.answer(pOutputMatrix);
                    if (labelDataSet.ToString().Trim() == answer.Trim())
                    {
                        countHit++;
                    }
                    else
                    {
                        countMiss++;
                    }
                        
                    count++;
                }
                mnist.closeRead();
                MessageBox.Show(string.Format("Total: {0} Hit: {1} Miss: {2}", count, countHit, countMiss));
            }
        }
    }
}
