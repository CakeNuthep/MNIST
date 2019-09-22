using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNIST.Reader
{
    public class MnistReader
    {
        string TrainImages;
        string TrainLabels;
        string TestImages;
        string TestLabels;
        BinaryReader labels;
        BinaryReader images;

        public MnistReader(string pathTrainImageFile, string pathTrainLabelFile, string pathTestImageFile, string pathTestLabelFile)
        {
            this.TrainImages = pathTrainImageFile;
            this.TrainLabels = pathTrainLabelFile;
            this.TestImages = pathTestImageFile;
            this.TestLabels = pathTestLabelFile;
        }
        public IEnumerable<Image> ReadTrainingData()
        {
            foreach (var item in Read(TrainImages, TrainLabels))
            {
                yield return item;
            }
        }

        public IEnumerable<Image> ReadTestData()
        {
            foreach (var item in Read(TestImages, TestLabels))
            {
                yield return item;
            }
        }

        private IEnumerable<Image> Read(string imagesPath, string labelsPath)
        {
            labels = new BinaryReader(new FileStream(labelsPath, FileMode.Open));
            images = new BinaryReader(new FileStream(imagesPath, FileMode.Open));

            

            int magicNumber = images.ReadBigInt32();
            int numberOfImages = images.ReadBigInt32();
            int width = images.ReadBigInt32();
            int height = images.ReadBigInt32();

            int magicLabel = labels.ReadBigInt32();
            int numberOfLabels = labels.ReadBigInt32();

            for (int i = 0; i < numberOfImages; i++)
            {
                var bytes = images.ReadBytes(width * height);
                var arr = new byte[height, width];

                arr.ForEach((j, k) => arr[j, k] = bytes[j * height + k]);

                yield return new Image()
                {
                    Data = arr,
                    Label = labels.ReadByte()
                };
            }

            closeRead();
        }


        public void closeRead()
        {
            labels.Close();
            images.Close();
        }
        
    }
}
