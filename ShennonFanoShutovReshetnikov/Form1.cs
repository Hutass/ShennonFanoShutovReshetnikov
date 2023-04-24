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

            Coder coder = new Coder();
            string outputFilePath = coder.Encode(inputFilePath, progressBarExecution);
            progressBarExecution.Visible = false;
            FileInfo outputFileInfo = new FileInfo(outputFilePath);

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

            Decoder decoder = new Decoder();
            string outputFilePath = decoder.Decode(inputFilePath, progressBarExecution);
            progressBarExecution.Visible = false;
            FileInfo outputFileInfo = new FileInfo(outputFilePath);

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
    }
}