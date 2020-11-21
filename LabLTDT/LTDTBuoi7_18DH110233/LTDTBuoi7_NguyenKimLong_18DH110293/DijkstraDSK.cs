using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LTDTBuoi7_NguyenKimLong_18DH110293
{
    class DijkstraDSK
    {
        LinkedList<Tuple<int, int>>[] v;
        int n;
        // Các array là biến toàn cục chỉ phục vụ cho giải thuật
        int[] pre;
        int[] dist;
        bool[] label;
        //Propeties
        public LinkedList<Tuple<int, int>>[] V
        {
            get { return v; }
            set { v = value; }
        }
        // Contructor
        public DijkstraDSK() { }
        public DijkstraDSK(int k)
        {
            v = new LinkedList<Tuple<int, int>>[k];
            n = k;
        }
        public DijkstraDSK(LinkedList<Tuple<int, int>>[] g)
        {
            v = g;
        }
        // Doc file ra ds ke
        public void FileToDSke()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK2.txt");
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<Tuple<int, int>>[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<Tuple<int, int>>();
                string[] s = sr.ReadLine().Split();
                int j = 0;
                while (j < s.Length)
                {
                    int t1 = int.Parse(s[j]);
                    int t2 = int.Parse(s[j + 1]);
                    Tuple<int, int> t = new Tuple<int, int>(t1, t2);
                    v[i].AddLast(t);
                    j = j + 2;
                }
            }
            sr.Close();
        }
        //Xuat do thi ds ke
        public void Output()
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("Dinh " + i + " : ");
                foreach (Tuple<int, int> x in v[i])
                    Console.Write("(" + x.Item1 + ", " + x.Item2 + ")  ");
                Console.WriteLine();
            }
        }

        // Dijkstra tim duong di ngan nhat tu s den cac dinh con lai
        // Ket qua luu trong array dist[]
        public void Di(int s)
        {
            pre = new int[n];
            dist = new int[n];
            label = new bool[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                pre[i] = s;
                label[i] = false;
            }
            label[s] = true;
            foreach (Tuple<int, int> x in v[s])
            {
                dist[x.Item1] = x.Item2;
            }
            dist[s] = 0;
            for (int i = 0; i < n; i++)
            {
                int a;
                a = dmin();
                label[a] = true;

                for (int b = 0; b < n; b++)
                {
                    int ab = weight(a, b);
                    if (label[b] == false && ab < int.MaxValue && (dist[b] > dist[a] + weight(a, b)))
                    {
                        dist[b] = dist[a] + weight(a, b);
                        pre[b] = a;
                    }
                }
            }
        }
        public void Dijkstra(int s)
        {
            Di(s);
            Console.WriteLine("Duong di ngan nhat tu dinh " + s +" den cac dinh con lai: ");
            Console.WriteLine(" Dinh: 0  1  2  3  4  5  6");
            Console.WriteLine("======================");
            Console.Write("pre: ");
            for(int i = 0; i < n; i++)
            {
                Console.Write("{0,3}", pre[i]);
            }
            Console.WriteLine();
            Console.Write("dist:");
            for(int i = 0; i < n; i++)
            {
                Console.Write("{0,3}", dist[i]);
            }
          
        }
        // Ham chon dinh gan nhat
        public int dmin()
        {
            int min = int.MaxValue;    // xuat phat min la gia tri lon nhat
            int vmin = 0;               // dinh tra ve
            for (int i = 0; i < n; i++)
            {
                if (label[i] == false && dist[i] < min)
                {
                    min = dist[i]; vmin = i;
                }
            }
            return vmin;
        }
        // Ham lay trong so canh (a,b)
        public int weight(int a, int b)
        {
            int wt = int.MaxValue;
            foreach (Tuple<int, int> x in v[a])
            {
                if (x.Item1 == b)
                {
                    wt = x.Item2; break;
                }
            }
            return wt;
        }
        // Tìm đường đi ngắn nhất từ x đến y
        Stack<int> st;
        public void MinXY(int x, int y)
        {
            st = new Stack<int>();
            Di(x);
            Console.WriteLine();
            Console.WriteLine("Duong di ngan nhat tu dinh {0} den dinh {1}: ", x , y);
            Console.Write("dist:");
            Console.WriteLine("{0,3}", dist[y]);
            st.Push(y);
            while(pre[y] != x)
            {
                y = pre[y];
                st.Push(y);
            }
            st.Push(x);
            Console.WriteLine();
            while (st.Count > 0)
            {
                Console.Write("{0} > ", st.Pop());
            }

        }
        // Tìm đường ngắn nhất từ x đền y qua đỉnh trung gian z
        public void MinXYZ(int x, int y, int z)
        {
            //Console.WriteLine("------------------------------");
            //st = new Stack<int>();
            //Di(x);
            //Console.WriteLine();
            //Console.WriteLine("Duong di ngan nhat tu dinh {0} den dinh {1}: ", x, z);
            //Console.Write("dist:");
            //Console.WriteLine("{0,3}", dist[z]);
            //st.Push(z);
            //while (pre[z] != x)
            //{
            //    z = pre[z];
            //    st.Push(z);
            //}
            //st.Push(x);

            //Di(z);
            //Console.WriteLine();
            //Console.WriteLine("Duong di ngan nhat tu dinh {0} den dinh {1}: ", z, y);
            //Console.Write("dist:");
            //Console.WriteLine("{0,3}", dist[y]);
            //st.Push(x);
            //while (pre[y] != z)
            //{
            //    y = pre[y];
            //    st.Push(y);
            //}
            //st.Push(x);

            //Console.WriteLine("Duong di ngan nhat tu dinh {0} den dinh {1}: ", x, y);
            //Console.Write("dist:");
            //int a = dist[y] + dist[z];
            //Console.WriteLine("{0,3}", a);

            MinXY(x, z);
            int co1 = dist[z];
            MinXY(z, y);
            int kq = co1 + dist[y];
            Console.WriteLine();
            Console.WriteLine("tong dist tu dinh {0} toi dinh {1}: {2} ",x,y,kq);
        }
    }
}