namespace ShennonFanoShutovReshetnikov
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.button_encode = new System.Windows.Forms.Button();
            this.textBox_encodedFilePath = new System.Windows.Forms.TextBox();
            this.button_decode = new System.Windows.Forms.Button();
            this.label_inputFile = new System.Windows.Forms.Label();
            this.label_outputFile = new System.Windows.Forms.Label();
            this.label_operation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_inputFile_size = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_outputFile_size = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_compression = new System.Windows.Forms.Label();
            this.progressBarExecution = new System.Windows.Forms.ProgressBar();
            this.button_encode_file = new System.Windows.Forms.Button();
            this.button_decode_file = new System.Windows.Forms.Button();
            this.groupBox_encode = new System.Windows.Forms.GroupBox();
            this.groupBox_decode = new System.Windows.Forms.GroupBox();
            this.button_Test = new System.Windows.Forms.Button();
            this.textBox_Test = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBox_encode.SuspendLayout();
            this.groupBox_decode.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Location = new System.Drawing.Point(9, 52);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(486, 23);
            this.textBox_FilePath.TabIndex = 0;
            // 
            // button_encode
            // 
            this.button_encode.Location = new System.Drawing.Point(501, 52);
            this.button_encode.Name = "button_encode";
            this.button_encode.Size = new System.Drawing.Size(105, 23);
            this.button_encode.TabIndex = 1;
            this.button_encode.Text = "Закодировать";
            this.button_encode.UseVisualStyleBackColor = true;
            this.button_encode.Click += new System.EventHandler(this.button_encode_Click);
            // 
            // textBox_encodedFilePath
            // 
            this.textBox_encodedFilePath.Location = new System.Drawing.Point(6, 52);
            this.textBox_encodedFilePath.Name = "textBox_encodedFilePath";
            this.textBox_encodedFilePath.Size = new System.Drawing.Size(486, 23);
            this.textBox_encodedFilePath.TabIndex = 2;
            // 
            // button_decode
            // 
            this.button_decode.Location = new System.Drawing.Point(499, 52);
            this.button_decode.Name = "button_decode";
            this.button_decode.Size = new System.Drawing.Size(105, 23);
            this.button_decode.TabIndex = 3;
            this.button_decode.Text = "Декодировать";
            this.button_decode.UseVisualStyleBackColor = true;
            this.button_decode.Click += new System.EventHandler(this.button_decode_Click);
            // 
            // label_inputFile
            // 
            this.label_inputFile.AutoSize = true;
            this.label_inputFile.Location = new System.Drawing.Point(182, 185);
            this.label_inputFile.Name = "label_inputFile";
            this.label_inputFile.Size = new System.Drawing.Size(86, 15);
            this.label_inputFile.TabIndex = 4;
            this.label_inputFile.Text = "Входной файл";
            // 
            // label_outputFile
            // 
            this.label_outputFile.AutoSize = true;
            this.label_outputFile.Location = new System.Drawing.Point(182, 309);
            this.label_outputFile.Name = "label_outputFile";
            this.label_outputFile.Size = new System.Drawing.Size(95, 15);
            this.label_outputFile.TabIndex = 5;
            this.label_outputFile.Text = "Выходной файл";
            // 
            // label_operation
            // 
            this.label_operation.AutoSize = true;
            this.label_operation.Location = new System.Drawing.Point(182, 249);
            this.label_operation.Name = "label_operation";
            this.label_operation.Size = new System.Drawing.Size(62, 15);
            this.label_operation.TabIndex = 6;
            this.label_operation.Text = "Операция";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Путь входного файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Операция";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Путь выходного файла";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Размер входного файла";
            // 
            // label_inputFile_size
            // 
            this.label_inputFile_size.AutoSize = true;
            this.label_inputFile_size.Location = new System.Drawing.Point(182, 212);
            this.label_inputFile_size.Name = "label_inputFile_size";
            this.label_inputFile_size.Size = new System.Drawing.Size(86, 15);
            this.label_inputFile_size.TabIndex = 10;
            this.label_inputFile_size.Text = "Входной файл";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Размер выходного файла";
            // 
            // label_outputFile_size
            // 
            this.label_outputFile_size.AutoSize = true;
            this.label_outputFile_size.Location = new System.Drawing.Point(182, 333);
            this.label_outputFile_size.Name = "label_outputFile_size";
            this.label_outputFile_size.Size = new System.Drawing.Size(95, 15);
            this.label_outputFile_size.TabIndex = 12;
            this.label_outputFile_size.Text = "Выходной файл";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Степень сжатия";
            // 
            // label_compression
            // 
            this.label_compression.AutoSize = true;
            this.label_compression.Location = new System.Drawing.Point(182, 273);
            this.label_compression.Name = "label_compression";
            this.label_compression.Size = new System.Drawing.Size(62, 15);
            this.label_compression.TabIndex = 14;
            this.label_compression.Text = "Операция";
            // 
            // progressBarExecution
            // 
            this.progressBarExecution.Location = new System.Drawing.Point(17, 362);
            this.progressBarExecution.Name = "progressBarExecution";
            this.progressBarExecution.Size = new System.Drawing.Size(703, 23);
            this.progressBarExecution.TabIndex = 16;
            // 
            // button_encode_file
            // 
            this.button_encode_file.Location = new System.Drawing.Point(612, 52);
            this.button_encode_file.Name = "button_encode_file";
            this.button_encode_file.Size = new System.Drawing.Size(105, 23);
            this.button_encode_file.TabIndex = 17;
            this.button_encode_file.Text = "Выбрать файл";
            this.button_encode_file.UseVisualStyleBackColor = true;
            this.button_encode_file.Click += new System.EventHandler(this.button_encode_file_Click);
            // 
            // button_decode_file
            // 
            this.button_decode_file.Location = new System.Drawing.Point(611, 52);
            this.button_decode_file.Name = "button_decode_file";
            this.button_decode_file.Size = new System.Drawing.Size(105, 23);
            this.button_decode_file.TabIndex = 18;
            this.button_decode_file.Text = "Выбрать файл";
            this.button_decode_file.UseVisualStyleBackColor = true;
            this.button_decode_file.Click += new System.EventHandler(this.button_decode_file_Click);
            // 
            // groupBox_encode
            // 
            this.groupBox_encode.Controls.Add(this.button_encode_file);
            this.groupBox_encode.Controls.Add(this.button_encode);
            this.groupBox_encode.Controls.Add(this.textBox_FilePath);
            this.groupBox_encode.Location = new System.Drawing.Point(3, 1);
            this.groupBox_encode.Name = "groupBox_encode";
            this.groupBox_encode.Size = new System.Drawing.Size(731, 83);
            this.groupBox_encode.TabIndex = 19;
            this.groupBox_encode.TabStop = false;
            this.groupBox_encode.Text = "Кодирование";
            // 
            // groupBox_decode
            // 
            this.groupBox_decode.Controls.Add(this.button_decode_file);
            this.groupBox_decode.Controls.Add(this.button_decode);
            this.groupBox_decode.Controls.Add(this.textBox_encodedFilePath);
            this.groupBox_decode.Location = new System.Drawing.Point(4, 85);
            this.groupBox_decode.Name = "groupBox_decode";
            this.groupBox_decode.Size = new System.Drawing.Size(732, 91);
            this.groupBox_decode.TabIndex = 20;
            this.groupBox_decode.TabStop = false;
            this.groupBox_decode.Text = "Декодирование";
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(615, 333);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(105, 23);
            this.button_Test.TabIndex = 21;
            this.button_Test.Text = "Тест";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBox_Test
            // 
            this.textBox_Test.Location = new System.Drawing.Point(502, 333);
            this.textBox_Test.Name = "textBox_Test";
            this.textBox_Test.Size = new System.Drawing.Size(107, 23);
            this.textBox_Test.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(502, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Время выполнения:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(625, 249);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(42, 15);
            this.labelTime.TabIndex = 23;
            this.labelTime.Text = "Время";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 400);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBox_Test);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.groupBox_decode);
            this.Controls.Add(this.groupBox_encode);
            this.Controls.Add(this.progressBarExecution);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_compression);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_outputFile_size);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_inputFile_size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_operation);
            this.Controls.Add(this.label_outputFile);
            this.Controls.Add(this.label_inputFile);
            this.Name = "Form1";
            this.Text = "Метод Шеннона-Фано, Шутов Решетников";
            this.groupBox_encode.ResumeLayout(false);
            this.groupBox_encode.PerformLayout();
            this.groupBox_decode.ResumeLayout(false);
            this.groupBox_decode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBox_FilePath;
        private Button button_encode;
        private TextBox textBox_encodedFilePath;
        private Button button_decode;
        private Label label_inputFile;
        private Label label_outputFile;
        private Label label_operation;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label_inputFile_size;
        private Label label5;
        private Label label_outputFile_size;
        private Label label6;
        private Label label_compression;
        private ProgressBar progressBarExecution;
        private Button button_encode_file;
        private Button button_decode_file;
        private GroupBox groupBox_encode;
        private GroupBox groupBox_decode;
        private Button button_Test;
        private TextBox textBox_Test;
        private Label label7;
        private Label labelTime;
    }
}