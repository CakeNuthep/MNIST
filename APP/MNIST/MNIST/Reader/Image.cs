using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNIST.Reader
{
    public class Image
    {
        public byte Label { get; set; }
        public byte[,] Data { get; set; }
    }
}
