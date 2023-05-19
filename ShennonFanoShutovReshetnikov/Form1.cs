using System.Diagnostics;

namespace ShennonFanoShutovReshetnikov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            groupBox_encode.AllowDrop = true;
            groupBox_encode.DragEnter += new DragEventHandler(groupBox_encode_DragEnter);
            groupBox_encode.DragDrop += new DragEventHandler(groupBox_encode_DragDrop);

            groupBox_decode.AllowDrop = true;
            groupBox_decode.DragEnter += new DragEventHandler(groupBox_decode_DragEnter);
            groupBox_decode.DragDrop += new DragEventHandler(groupBox_decode_DragDrop);
        }

        void groupBox_encode_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void groupBox_encode_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string inputFilePath in files)
            {
                Encode(inputFilePath);
            };
        }

        void groupBox_decode_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void groupBox_decode_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string inputFilePath in files)
            {
                if (new FileInfo(inputFilePath).Extension == ".dat")
                {
                    Decode(inputFilePath);
                }
            };
        }

        private void button_encode_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFilePath = new string("");
                if (File.Exists(textBox_FilePath.Text))
                {
                    inputFilePath = textBox_FilePath.Text;
                    Encode(inputFilePath);
                }
                else
                {
                    button_encode_file_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button_decode_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFilePath = new string("");
                if (File.Exists(textBox_encodedFilePath.Text) && new FileInfo(textBox_encodedFilePath.Text).Extension == ".dat")
                {
                    inputFilePath = textBox_encodedFilePath.Text;
                    Decode(inputFilePath);
                }
                else
                {
                    button_decode_file_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button_encode_file_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFilePath = new string("");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All files(*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        inputFilePath = openFileDialog.FileName;
                    }
                }
                Encode(inputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button_decode_file_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFilePath = new string("");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "dat files (*.dat)|*.dat";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        inputFilePath = openFileDialog.FileName;
                    }
                }
                Decode(inputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Encode(string inputFilePath)
        {
            FileInfo inputFileInfo = new FileInfo(inputFilePath);

            progressBarExecution.Visible = true;
            progressBarExecution.Minimum = 1;
            progressBarExecution.Maximum = (int)inputFileInfo.Length * 2;
            progressBarExecution.Value = 1;
            progressBarExecution.Step = 1;

            SetInputFileInfo(inputFileInfo, "Кодирование");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Coder coder = new Coder();
            string outputFilePath = coder.Encode(inputFilePath, progressBarExecution);
            progressBarExecution.Visible = false;
            FileInfo outputFileInfo = new FileInfo(outputFilePath);

            stopwatch.Stop();
            labelTime.Text = $"{string.Format("{0:0.####}", stopwatch.Elapsed.TotalMilliseconds / 1000)}" + " с";

            SetOutputFileInfo(outputFileInfo, "Кодирование");

            label_compression.Text = string.Format("{0:0.##}", (double)(inputFileInfo.Length - outputFileInfo.Length) * 100 / inputFileInfo.Length) + " %";
        }

        private void Decode(string inputFilePath)
        {
            FileInfo inputFileInfo = new FileInfo(inputFilePath);

            progressBarExecution.Visible = true;
            progressBarExecution.Minimum = 1;
            progressBarExecution.Maximum = (int)inputFileInfo.Length - 257;
            progressBarExecution.Value = 1;
            progressBarExecution.Step = 1;

            SetInputFileInfo(inputFileInfo, "Декодирование");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Decoder decoder = new Decoder();
            string outputFilePath = decoder.Decode(inputFilePath, progressBarExecution);
            progressBarExecution.Visible = false;
            FileInfo outputFileInfo = new FileInfo(outputFilePath);

            stopwatch.Stop();
            labelTime.Text = $"{string.Format("{0:0.####}", stopwatch.Elapsed.TotalMilliseconds / 1000)}" + " с";

            SetOutputFileInfo(outputFileInfo, "Декодирование");

            label_compression.Text = string.Format("{0:0.##}", ((double)(outputFileInfo.Length - inputFileInfo.Length) * 100 / outputFileInfo.Length).ToString()) + " % - степень сжатия оригинального файла";
        }

        private void SetInputFileInfo(FileInfo inputFileInfo, string operationText)
        {
            label_inputFile.Text = inputFileInfo.Name;
            label_operation.Text = operationText;
            label_inputFile_size.Text = inputFileInfo.Length.ToString();
        }

        private void SetOutputFileInfo(FileInfo outputFileInfo, string operationText)
        {
            switch (operationText)
            {
                case "Кодирование":
                    textBox_encodedFilePath.Text = outputFileInfo.FullName;
                    label_outputFile.Text = outputFileInfo.Name;
                    label_outputFile_size.Text = outputFileInfo.Length.ToString();
                    break;
                case "Декодирование":
                    textBox_FilePath.Text = outputFileInfo.FullName;
                    label_outputFile.Text = outputFileInfo.Name;
                    label_outputFile_size.Text = outputFileInfo.Length.ToString();
                    break;

            }

        }

        private void Test(int fileSize, FileStream outputStream)
        {
            Decoder decoder = new Decoder();
            Coder coder = new Coder();
            Random random = new Random();

            GenerateFile("Temp.txt", fileSize, 10);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();

            stopwatch.Start();
            string outputPath = coder.Encode("Temp.txt", new ProgressBar());
            stopwatch.Stop();
            double encodeTime = stopwatch.Elapsed.TotalSeconds;

            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch2.Reset();

            stopwatch2.Start();
            decoder.Decode(outputPath, new ProgressBar());
            stopwatch2.Stop();
            double decodeTime = stopwatch2.Elapsed.TotalSeconds;

            BinaryWriter binaryWriter = new BinaryWriter(outputStream);
            string buf = $"{fileSize};{string.Format("{0:0.####}", encodeTime)};{string.Format("{0:0.####}", decodeTime)}";
            binaryWriter.Write(buf + Environment.NewLine);

            File.Delete("Temp.txt");
            File.Delete(outputPath);
        }

        static public void GenerateFile(string filepath, int filelenght, int uniqByteCount)
        {
            if (uniqByteCount > 256)
            {
                uniqByteCount = 256;
            }

            Random random = new Random();
            int[] frequencies = new int[uniqByteCount];
            int sumFrequency = 0;
            for (int i = 0; i < uniqByteCount; i++)
            {
                frequencies[i] = random.Next() % filelenght;
                sumFrequency += frequencies[i];
            }

            double proportion = (double)filelenght / sumFrequency;
            for (int i = 0; i < uniqByteCount; i++)
            {
                frequencies[i] = (int)Math.Ceiling(frequencies[i] * proportion);
            }

            BinaryWriter writer = new BinaryWriter(File.Open(filepath, FileMode.Create));
            for (int i = 0; i < uniqByteCount; i++)
            {
                byte newbyte = (byte)(i);
                while (frequencies[i] > 0)
                {
                    writer.Write(newbyte);
                    frequencies[i]--;
                }
            }
            writer.Close();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            int testSize = Convert.ToInt32(textBox_Test.Text);

            progressBarExecution.Visible = true;
            progressBarExecution.Minimum = 1;
            progressBarExecution.Maximum = (int)(Math.Log(testSize * 1024, 1.2) - Math.Log(128, 1.2) + 1);
            progressBarExecution.Value = 1;
            progressBarExecution.Step = 1;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            FileStream fileStream = File.Create("Result.csv");
            for (int i = 128; i < testSize * 1024; i = (int)(i * 1.2))
            {
                progressBarExecution.PerformStep();
                Test(i, fileStream);
            }
            fileStream.Close();

            stopwatch.Stop();
            labelTime.Text = $"{string.Format("{0:0.####}", stopwatch.Elapsed.TotalMilliseconds / 1000)}" + " с";

            progressBarExecution.Visible = false;
        }
    }
}