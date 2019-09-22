namespace MNIST
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_hiddenLayer = new System.Windows.Forms.TextBox();
            this.textBox_learningRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_TestAll = new System.Windows.Forms.Button();
            this.button_testOneImage = new System.Windows.Forms.Button();
            this.button_train = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_pathTestLabelFile = new System.Windows.Forms.TextBox();
            this.textBox_pathTestFile = new System.Windows.Forms.TextBox();
            this.textBox_pathLabelFile = new System.Windows.Forms.TextBox();
            this.textBox_pathTrainFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_predict = new System.Windows.Forms.Button();
            this.pictureBox_draw = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_target = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_hiddenLayer);
            this.groupBox1.Controls.Add(this.textBox_learningRate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_TestAll);
            this.groupBox1.Controls.Add(this.button_testOneImage);
            this.groupBox1.Controls.Add(this.button_train);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_pathTestLabelFile);
            this.groupBox1.Controls.Add(this.textBox_pathTestFile);
            this.groupBox1.Controls.Add(this.textBox_pathLabelFile);
            this.groupBox1.Controls.Add(this.textBox_pathTrainFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Train";
            // 
            // textBox_hiddenLayer
            // 
            this.textBox_hiddenLayer.Location = new System.Drawing.Point(508, 25);
            this.textBox_hiddenLayer.Name = "textBox_hiddenLayer";
            this.textBox_hiddenLayer.Size = new System.Drawing.Size(100, 26);
            this.textBox_hiddenLayer.TabIndex = 6;
            this.textBox_hiddenLayer.Text = "30";
            // 
            // textBox_learningRate
            // 
            this.textBox_learningRate.Location = new System.Drawing.Point(508, 58);
            this.textBox_learningRate.Name = "textBox_learningRate";
            this.textBox_learningRate.Size = new System.Drawing.Size(100, 26);
            this.textBox_learningRate.TabIndex = 5;
            this.textBox_learningRate.Text = "0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hidden Layer: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Learning Rate:";
            // 
            // button_TestAll
            // 
            this.button_TestAll.Location = new System.Drawing.Point(614, 113);
            this.button_TestAll.Name = "button_TestAll";
            this.button_TestAll.Size = new System.Drawing.Size(134, 44);
            this.button_TestAll.TabIndex = 3;
            this.button_TestAll.Text = "Test All";
            this.button_TestAll.UseVisualStyleBackColor = true;
            this.button_TestAll.Click += new System.EventHandler(this.Button_TestAll_Click);
            // 
            // button_testOneImage
            // 
            this.button_testOneImage.Location = new System.Drawing.Point(614, 66);
            this.button_testOneImage.Name = "button_testOneImage";
            this.button_testOneImage.Size = new System.Drawing.Size(134, 44);
            this.button_testOneImage.TabIndex = 3;
            this.button_testOneImage.Text = "Test one image";
            this.button_testOneImage.UseVisualStyleBackColor = true;
            this.button_testOneImage.Click += new System.EventHandler(this.Button_testOneImage_Click);
            // 
            // button_train
            // 
            this.button_train.Location = new System.Drawing.Point(614, 16);
            this.button_train.Name = "button_train";
            this.button_train.Size = new System.Drawing.Size(134, 44);
            this.button_train.TabIndex = 3;
            this.button_train.Text = "Train";
            this.button_train.UseVisualStyleBackColor = true;
            this.button_train.Click += new System.EventHandler(this.Button_train_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Path test label file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path train label file:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Path test file:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path train file:";
            // 
            // textBox_pathTestLabelFile
            // 
            this.textBox_pathTestLabelFile.Location = new System.Drawing.Point(154, 128);
            this.textBox_pathTestLabelFile.Name = "textBox_pathTestLabelFile";
            this.textBox_pathTestLabelFile.Size = new System.Drawing.Size(219, 26);
            this.textBox_pathTestLabelFile.TabIndex = 0;
            this.textBox_pathTestLabelFile.Text = "D:\\LearningC#\\page\\MNIST\\MNIST\\MNIST\\Dataset\\t10k-labels.idx1-ubyte";
            // 
            // textBox_pathTestFile
            // 
            this.textBox_pathTestFile.Location = new System.Drawing.Point(154, 92);
            this.textBox_pathTestFile.Name = "textBox_pathTestFile";
            this.textBox_pathTestFile.Size = new System.Drawing.Size(217, 26);
            this.textBox_pathTestFile.TabIndex = 0;
            this.textBox_pathTestFile.Text = "D:\\LearningC#\\page\\MNIST\\MNIST\\MNIST\\Dataset\\t10k-images.idx3-ubyte";
            // 
            // textBox_pathLabelFile
            // 
            this.textBox_pathLabelFile.Location = new System.Drawing.Point(154, 61);
            this.textBox_pathLabelFile.Name = "textBox_pathLabelFile";
            this.textBox_pathLabelFile.Size = new System.Drawing.Size(219, 26);
            this.textBox_pathLabelFile.TabIndex = 0;
            this.textBox_pathLabelFile.Text = "D:\\LearningC#\\page\\MNIST\\MNIST\\MNIST\\Dataset\\train-labels.idx1-ubyte";
            // 
            // textBox_pathTrainFile
            // 
            this.textBox_pathTrainFile.Location = new System.Drawing.Point(155, 25);
            this.textBox_pathTrainFile.Name = "textBox_pathTrainFile";
            this.textBox_pathTrainFile.Size = new System.Drawing.Size(217, 26);
            this.textBox_pathTrainFile.TabIndex = 0;
            this.textBox_pathTrainFile.Text = "D:\\LearningC#\\page\\MNIST\\MNIST\\MNIST\\Dataset\\train-images.idx3-ubyte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_clear);
            this.groupBox2.Controls.Add(this.button_predict);
            this.groupBox2.Controls.Add(this.pictureBox_draw);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Draw";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(254, 70);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(139, 39);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.Button_clear_Click);
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(254, 25);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(139, 39);
            this.button_predict.TabIndex = 1;
            this.button_predict.Text = "Predict";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.Button_predict_Click);
            // 
            // pictureBox_draw
            // 
            this.pictureBox_draw.BackColor = System.Drawing.Color.White;
            this.pictureBox_draw.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_draw.Location = new System.Drawing.Point(6, 25);
            this.pictureBox_draw.Name = "pictureBox_draw";
            this.pictureBox_draw.Size = new System.Drawing.Size(217, 243);
            this.pictureBox_draw.TabIndex = 0;
            this.pictureBox_draw.TabStop = false;
            this.pictureBox_draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_draw_MouseDown);
            this.pictureBox_draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_draw_MouseMove);
            this.pictureBox_draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_draw_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_target);
            this.groupBox3.Location = new System.Drawing.Point(434, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 273);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_target.Location = new System.Drawing.Point(106, 78);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(133, 147);
            this.label_target.TabIndex = 0;
            this.label_target.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MNIST";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_draw)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_pathLabelFile;
        private System.Windows.Forms.TextBox textBox_pathTrainFile;
        private System.Windows.Forms.Button button_train;
        private System.Windows.Forms.TextBox textBox_learningRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_target;
        private System.Windows.Forms.PictureBox pictureBox_draw;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_predict;
        private System.Windows.Forms.TextBox textBox_hiddenLayer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pathTestLabelFile;
        private System.Windows.Forms.TextBox textBox_pathTestFile;
        private System.Windows.Forms.Button button_TestAll;
        private System.Windows.Forms.Button button_testOneImage;
    }
}

