using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LTDTBuoi01_LeHoangVu
{
    class GraphMTK
    {
        public int n;
        public int[,] a;
        // propeties
        public int N { get; set; }
        public int[,] A { get; set; }

        // Contrucstor

        public GraphMTK() { }
        public GraphMTK(int x)
        {
            n = x;
            a = new int[n, n];
        }
        public void FileToG()
        {
            StreamReader sr = new StreamReader("../../TextFile/MTK.txt");
            n = int.Parse(sr.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    a[i, j] = int.Parse(s[j]);
            }
            sr.Close();
        }
        public void Outgraph()
        {
            Console.WriteLine("Do thi");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        public int BacdinhI(int i)
        {
            int demBac = 0;
            for(int j = 0; j < n; j++)
            {
                if(a[i,j] == 1)
                {
                    demBac++;
                }
            }
            return demBac;
        }
        public void BacCacDinh()
        {
            int[] list;
            list = new int[n];

            for(int i = 0; i < n; i++)
            {
                int demBac = 0;
                for(int j = 0; j < n; j++)
                {
                    if (a[i, j] == 1)
                    {
                        demBac++;
                    }
                }
                Console.WriteLine("Dinh {0} la dinh bac {1}", i, demBac);
            }
        }
    }
}

