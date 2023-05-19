using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShennonFanoShutovReshetnikov
{
    internal class Coder
    {
        static bool TREE_LEFT = TreeNode<tableNote>.TREE_LEFT;
        static bool TREE_RIGHT = TreeNode<tableNote>.TREE_RIGHT;

        public class tableNote : IComparable
        {
            public byte symbol;
            public int count;

            public tableNote()
            {
                symbol = 0;
                count = 0;
            }
            public tableNote(byte s, int c)
            {
                symbol = s;
                count = c;
            }

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }
                else
                {
                    tableNote other = obj as tableNote;
                    return -(this.count - other.count);
                }
            }
        }
        public class codeNote : IComparable
        {
            public List<bool> code; // true - 1, false - 0
            public byte oneByte;

            public codeNote()
            {
                code = new List<bool>();
            }

            public codeNote(List<bool> code, byte symbol)
            {
                this.code = new List<bool>(code);
                this.oneByte = symbol;
            }
            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }
                else
                {
                    codeNote other = obj as codeNote;
                    return (this.oneByte - other.oneByte);
                }
            }
        }

        

        public string Encode(string inputPath, ProgressBar progressBar)
        {
            List<tableNote> table = new List<tableNote>();
            for (int i = 0; i < 256; i++)
            {
                table.Add(new tableNote((byte)i, 0));
            }

            //string inputPath = "D:\\forCoder\\test.txt"; //D:\\forCoder\\test.txt
            FileStream inputFile = File.OpenRead(inputPath);
            BinaryReader inputReader = new BinaryReader(inputFile);
            byte[] byteSign = new byte[1];

            // построение таблицы частот
            while (inputReader.Read(byteSign, 0, 1) != 0)
            {
                table[byteSign[0]].count++;
                progressBar.PerformStep();
            }

            int maxCount = 0;
            for (int i = 0; i < 256; i++)
            {
                if (maxCount < table[i].count)
                {
                    maxCount = table[i].count;
                }
            }

            inputReader.Close();
            inputFile.Close();

            inputFile = File.OpenRead(inputPath);
            inputReader = new BinaryReader(inputFile);

            string outputPath = inputPath + ".dat";
            FileStream outputFile = File.Open(outputPath, FileMode.Create);
            BinaryWriter outputWriter = new BinaryWriter(outputFile);

            for (int i = 0; i < 256; i++)
            {
                double d1 = (double)table[i].count / maxCount;
                if (d1 != 0)
                {
                    d1 = d1 * 254 + 1;
                }
                table[i].count = (byte)d1;
                outputWriter.Write((byte)d1);
            }
            outputWriter.Write((byte)255);

            for (int i = table.Count - 1; i >= 0; i--)
            {
                if (table[i].count <= 0)
                {
                    table.RemoveAt(i);
                }
            }

            // сортировка
            Sorter sorter = new Sorter();
            sorter.QuickSort(table);

            // разбиение таблицы
            TreeNode<tableNote> tree = new TreeNode<tableNote>(new tableNote());
            SplitTable(table, tree);

            List<codeNote> codeTable = new List<codeNote>();
            List<bool> code = new List<bool>();
            MergeCodeTable(codeTable, tree, code);
            codeTable.Sort();

            //List<byte> outputWord = new List<byte>();
            byte tbyte = 0;
            int freebits = 8;

            if (codeTable.Count != 256)
                while (inputReader.Read(byteSign, 0, 1) == 1)
                {
                    progressBar.PerformStep();

                    int step, sign, i;

                    i = step = codeTable.Count / 2;
                    sign = 1;

                    while (true)
                    {
                        if (byteSign[0] == codeTable[i].oneByte)
                        {
                            foreach (bool bit in codeTable[i].code)
                            {
                                if (freebits <= 0)
                                {
                                    outputWriter.Write(tbyte);
                                    tbyte = 0;
                                    freebits = 8;
                                }
                                tbyte *= 2;
                                if (bit)
                                {
                                    tbyte++;
                                }
                                freebits--;
                            }
                            break;
                        }

                        if (step >= 2)
                        {
                            step /= 2;
                        }
                        if (byteSign[0] < codeTable[i].oneByte)
                        {
                            sign = -1;
                        }
                        else
                        {
                            sign = 1;
                        }
                        i += step * sign;
                    }
                }
            else
                while (inputReader.Read(byteSign, 0, 1) == 1)
                {
                    progressBar.PerformStep();

                    foreach (bool bit in codeTable[byteSign[0]].code)
                    {
                        if (freebits <= 0)
                        {
                            outputWriter.Write(tbyte);
                            tbyte = 0;
                            freebits = 8;
                        }
                        tbyte *= 2;
                        if (bit)
                        {
                            tbyte++;
                        }
                        freebits--;
                    }
                }

            tbyte = (byte)(tbyte << freebits);
            outputWriter.Write(tbyte);

            freebits = freebits << 5;
            int extensionLenght = 0;
            for (int i = inputPath.Length - 1; i >= 0; i--)
            {
                if (inputPath[i] == '.')
                {
                    freebits |= extensionLenght;
                    if (extensionLenght > 31)
                        Console.WriteLine("ААААААА, КАК ТАК-ТО? ТЫ ВООБЩЕ ЧЕ СЖИМАЕШЬ?!");
                    break;
                }
                extensionLenght++;
            }
            outputWriter.Seek(256, SeekOrigin.Begin);
            outputWriter.Write((byte)freebits);
            inputReader.Close();
            outputWriter.Close();

            Console.WriteLine("Конец типа");
            return outputPath;
        }

        public static void SplitTable(List<tableNote> table, TreeNode<tableNote> tnode)
        {
            if (table.Count == 2)
            {
                tnode.AddChild(table[0], TREE_LEFT);
                tnode.AddChild(table[1], TREE_RIGHT);
            }
            else if (table.Count < 2)
            {
                tnode.Value = table[0];
            }
            else
            {
                int sum = 0;
                int min = int.MaxValue;
                foreach (tableNote t in table)
                {
                    sum += t.count;
                }

                int sumL = 0;
                int sumR = sum;
                for (int i = 0; i < table.Count; i++)
                {
                    sumL += table[i].count;
                    sumR -= table[i].count;

                    int diff = Math.Abs(sumL - sumR);
                    if (diff > min)
                    {
                        i--;
                        List<tableNote> tLeft = new List<tableNote>();
                        List<tableNote> tRight = new List<tableNote>();
                        for (int j = 0; j < table.Count; j++)
                        {
                            if (j <= i)
                            {
                                tLeft.Add(table[j]);
                            }
                            else
                            {
                                tRight.Add(table[j]);
                            }
                        }

                        tnode.AddChild(new tableNote(0, 0), TREE_LEFT);
                        tnode.AddChild(new tableNote(0, 0), TREE_RIGHT);
                        SplitTable(tLeft, tnode.Left);
                        SplitTable(tRight, tnode.Right);
                        break;
                    }
                    else
                    {
                        min = diff;
                    }
                }
            }
        }
        public static void MergeCodeTable(List<codeNote> codeTable, TreeNode<tableNote> tnode, List<bool> code)
        {

            if (tnode.Left == null && tnode.Right == null)
            {
                List<bool> bufcode = new List<bool>(code);
                codeTable.Add(new codeNote(bufcode, (byte)tnode.Value.symbol));
            }
            else
            {
                if (tnode.Left != null)
                {
                    List<bool> bufcode = new List<bool>(code);
                    bufcode.Add(false);
                    MergeCodeTable(codeTable, tnode.Left, bufcode);
                }
                if (tnode.Right != null)
                {
                    List<bool> bufcode = new List<bool>(code);
                    bufcode.Add(true);
                    MergeCodeTable(codeTable, tnode.Right, bufcode);
                }
            }
        }
    }
}
