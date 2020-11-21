using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LTDTBuoi02_NguyenKimLong
{
    class DSC_DSK
    {

        LinkedList<Tuple<int, int>> g;     // Do thi ds canh thay cho edgeList
        int n;      // so dinh cua do thi
        int m;      // so canh cua do thi
        int x;
        int y;
        // Propeties
        public int N { get; set; }
        public int M { get; set; }
        // constructor
        public DSC_DSK()
        {
            g = new LinkedList<Tuple<int, int>>();
        }
        // Doc file DScanh.txt -> do thi g
        public void FileToG()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSC.txt");
            string[] s = sr.ReadLine().Split();
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split();
                Tuple<int, int> t = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]));
                g.AddLast(t);
            }
        }
        // Xuat danh sach canh len man hinh
        public void Output()
        {
            Console.WriteLine("Danh sach canh cua do thi voi so dinh n = " + n);
            foreach (Tuple<int, int> t in g)
                Console.WriteLine("(" + t.Item1 + "," + t.Item2 + ")");
        }
        LinkedList<int>[] v;
        public void DSCsangDSK()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSC.txt");
            string[] s;
            s = sr.ReadLine().Split();
            int n = int.Parse(s[1]);
            v = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                s = sr.ReadLine().Split();
                x = int.Parse(s[0]);
                y = int.Parse(s[1]);             
                v[x].AddLast(y);
            }
        }
        public void OutputDSCsangDSK()
        {
            for (int i = 0; i < v.Length; i++)
            {
                foreach (int x in v[i])
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }
    }
}
