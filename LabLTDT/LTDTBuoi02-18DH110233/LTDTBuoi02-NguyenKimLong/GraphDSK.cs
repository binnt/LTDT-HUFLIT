using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LTDTBuoi02_NguyenKimLong
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
        LinkedList<Tuple<int, int>> g;
        Tuple<int, int> t;
        string[] s;
        public void DSKsangDSC()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            int n = int.Parse(sr.ReadLine());
            for(int i =0; i < n; i++)
            {
                s = sr.ReadLine().Split();
                for(int j =0; j< s.Length; j++)
                {
                    s = sr.ReadLine().Split();
                    t = new Tuple<int, int>(i, int.Parse(s[j]));
                    g.AddLast(t);
                }
            }

        }

        public void OutputDSKsangDSC()
        {
            foreach(Tuple<int, int> t in g)
            {
                Console.WriteLine("({0}, {1})", t.Item1, t.Item2);
            }
        }
    }
}
