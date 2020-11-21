using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LTDTBuoi01_LeHoangVu
{
    class GraphDSK
    {
        LinkedList<int>[] v;
        //Propeties
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
        // Contructor
        public GraphDSK() { }
        public GraphDSK(int k)
        {
            v = new LinkedList<int>[k];
        }
        public GraphDSK(LinkedList<int>[] g)
        {
            v = g;
        }
        // Contructor voi tham so la ma tran ke a, chuyen doi thi ma tran ke -> ds ke
        // Thuc chat la doc ma tran ke a -> ds ke v
        public GraphDSK(int[,] a)
        {
        }
        // Doc file ra ds ke
        public void FileToDSke()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            int n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                string[] s = sr.ReadLine().Split();
                for (int j = 0; j < s.Length; j++)
                {
                    int x = int.Parse(s[j]);
                    v[i].AddLast(x);
                }
            }
            sr.Close();
        }
        //Xuat do thi ds ke
        public void Output()
        {
            for (int i = 0; i < v.Length; i++)
            {
                foreach (int x in v[i])
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }
        public void BacDinh()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("So bac cua dinh: ");
            int demBac = 0;
            for (int i = 0; i < v.Length; i++)
            {
                foreach (int x in v[i])
                    demBac++;
                Console.Write(demBac + " ");
                demBac = 0;
            }
        }
    }
}
