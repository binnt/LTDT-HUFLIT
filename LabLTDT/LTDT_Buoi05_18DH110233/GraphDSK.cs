using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT_Buoi05_18DH110800
{
    class GraphDSK
    {
        int n;
        LinkedList<int>[] v;
        bool[] visited;     // visited, pre thêm vào chỉ để tham gia giải thuật
        int[] pre;
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
            visited = new bool[k];
        }
        public GraphDSK(LinkedList<int>[] g)
        {
            v = g;
        }
        // Doc file ra ds ke
        public void FileToDSke()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK.txt");
            n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            visited = new bool[n];
            pre = new int[n];

            for (int i = 0; i < n; i++)
            {
                v[i] = new LinkedList<int>();
                string st = sr.ReadLine();
                // Đặt điều kiện dòng đọc ra không trống
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
        // Duyệt đồ thị với đỉnh xuất phát là s
        public void DFS(int s)
        {
            visited[s] = true;
            Console.Write(s + "--");
            foreach (int u in V[s])
            {
                if (visited[u] == false)
                {
                    pre[u] = s;
                    DFS(u);
                }
            }
        }
        public void DuyetDFS(int s)
        {
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
                pre[i] = -1;
            }

            if (visited[s] == false)
            {
                DFS(s);
            }
        }
        // End - Duyệt DFS
        Stack<int> stack;
        // Tìm đường đi từ đỉnh x đến đỉnh y
        public void DFSDuongdi(int x, int y)
        {
            stack = new Stack<int>();
            int k = y;
            do
            {
                stack.Push(pre[k]);
                k = pre[k];
            }
            while (pre[k] != x);
            stack.Push(pre[k]);
        }
        public void DFSTimDuongdi(int x, int y)
        {
            try
            {
                visited = new bool[n];

                for (int i = 0; i < n; i++)
                {
                    visited[i] = false;
                    pre[i] = -1;
                }

                if (visited[x] == false)
                {
                    DFS(x);
                }
                Console.WriteLine();
                DFSDuongdi(x, y);
                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop() + "==");

                }
                Console.Write(y);
            }
            catch
            {

            }
        }
    }
}
