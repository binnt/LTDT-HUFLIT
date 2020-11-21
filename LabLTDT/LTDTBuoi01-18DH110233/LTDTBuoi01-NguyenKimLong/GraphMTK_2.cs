using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LTDTBuoi01_LeHoangVu
{
    class GraphMTK_2
    {
        public int n;
        public int[,] a;
        // propeties
        public int N { get; set; }
        public int[,] A { get; set; }

        // Contrucstor

        public GraphMTK_2() { }
        public GraphMTK_2(int x)
        {
            n = x;
            a = new int[n, n];
        }
        public void FileToG()
        {
            StreamReader sr = new StreamReader("../../TextFile/MTK_2.txt");
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
        public int BacVaodinhI(int i)
        {
            
            int demBacVao = 0;
            for(int j = 0; j < n; j++)
            {
                if (a[j, i] == 1)
                {
                    demBacVao++;
                }
            }
            return demBacVao;
        }
        public int BacRadinhI(int i)
        {
            int demBacRa = 0;
            for (int j = 0; j < n; j++)
            {
                if (a[i, j] == 1)
                {
                    demBacRa++;
                }
            }
            return demBacRa;

        }
        public void BacCacDinh()
        {
            int[] list;
            list = new int[n];

            for (int i = 0; i < n; i++)
            {
                int demBacRa = 0;
                int demBacVao = 0;
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 1)
                    {
                        demBacRa++;
                    }
                    if (a[j, i] == 1)
                    {
                        demBacVao++;
                    }
                }
                Console.WriteLine("Dinh {0} la dinh bac vao {1}, dinh bac ra {2}", i, demBacVao, demBacRa);
            }
        }
    }
}
