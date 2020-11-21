using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LTDTBuoi3_NguyenTheNguyen
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
                string st = sr.ReadLine();
                // Dat dieu kien dong doc ra khong trong
                if (st != "")
                {
                    string[] s = st.Split();
                    for (int j = 0; j < s.Length; j++)
                    {
                        int x = int.Parse(s[j]);
                        v[i].AddLast(x);
                    }
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
        //
        // Bai 1 : Duyet do thi theo BFS, xuat phat tu dinh s
        public bool[] visited;
        Queue<int> q = new Queue<int>();

        public void BFS(int s)
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            int n = int.Parse(sr.ReadLine());
            visited = new bool[n];

            visited[s] = true;
            q.Enqueue(s);

            while (q.Count != 0)
            {
                s = q.Dequeue();
                foreach (int u in v[s])
                {
                    if (visited[u]) continue;
                    visited[u] = true;
                    q.Enqueue(u);
                }
            }
            Console.WriteLine("---Bai1---");
            for (int i = 0; i < n; i++)
            {
                if(visited[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
        LinkedList<int> vertices;
        // Bai 2 : Tim duong di giua 2 dinh x va y
        public void BFSxy(int x, int y)
        {
            Console.WriteLine("\n---Bai2---");
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            int n = int.Parse(sr.ReadLine());
            visited = new bool[n];
            vertices = new LinkedList<int>();
            visited[x] = true;
            vertices.AddLast(x);

            q.Enqueue(x);

            while (q.Count != 0)
            {
                x = q.Dequeue();
                foreach (int u in v[x])
                {
                    if (visited[u]) continue;
                    vertices.AddLast(u);
                    visited[u] = true;
                    if (u == y) break;
                    q.Enqueue(u);
                }
            }
            if (visited[y])
            {
                foreach (int a in vertices)
                {
                    Console.Write(a + " ");
                }
            }
            else
            {
                Console.Write("x khong toi duoc y");
            }
            
        }
        // Bai 3 : kiem tra do thi lien thong
        public bool Lienthong(int s)
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            int n = int.Parse(sr.ReadLine());
            visited = new bool[n];

            visited[s] = true;
            q.Enqueue(s);

            while (q.Count != 0)
            {
                s = q.Dequeue();
                foreach (int u in v[s])
                {
                    if (visited[u]) continue;
                    visited[u] = true;
                    q.Enqueue(u);
                }
            }
            Console.WriteLine();
            Console.WriteLine("---Bai3---");
            foreach(var item in visited)
            {
                if (item==false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}


