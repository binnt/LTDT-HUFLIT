using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LTDTBuoi6_NguyenKimLong_18DH110293
{
    class GraphDSK
    {
        LinkedList<int>[] v;
        bool[] visited;     // visited, pre thêm vào chỉ để tham gia giải thuật
        int[] pre;
        int[] color;
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
        // Doc file ra ds ke, luu y thay doi ten file
        // DSK1.txt : cho cac muc 1,2,3,4 : do thi vo huong
        // DSK2.txt : cho cac muc 1,2,5 : do thi 2 phia
        // DSK3.txt : cho cac muc 1,2,4,6 : do thi co huong
        public void FileToDSke()
        {
            StreamReader sr = new StreamReader("../../TextFile/DSK3.txt");
            int n = int.Parse(sr.ReadLine());
            v = new LinkedList<int>[n];
            visited = new bool[n];
            pre = new int[n];
            color = new int[n];

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
            Console.Write(s + " - ");
            foreach (int u in v[s])
                if (visited[u] == false) DFS(u);
        }
        public void DuyetDFS(int s)
        {
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;
            if (visited[s] == false)
                DFS(s);
        }
        // End - Duyệt DFS
        // Tìm đường đi từ đỉnh x đến đỉnh y
        public void DFSDuongdi(int s)
        {
            if (v[s] == null) return;
            visited[s] = true;
            foreach (int u in v[s])
                if (visited[u] == false)
                {
                    pre[u] = s;
                    DFSDuongdi(u);
                }
        }
        public void DFSTimDuongdi(int x, int y)
        {
            for (int i = 0; i < v.Length; i++)
            {
                visited[i] = false;
                pre[i] = -1;
            }
            DFSDuongdi(x);
            if (v[x].Count == 0 || v[y].Count == 0)
                Console.WriteLine(" Khong co duong di");
            else
                XuatDuongdi(x, y);
        }
        // Xuat duong di
        public void XuatDuongdi(int x, int y)
        {
            Stack<int> st = new Stack<int>();
            int k = y;
            st.Push(y);
            do
            {
                st.Push(pre[k]);
                k = pre[k];
            } while (pre[k] != -1);
            Console.Write("  Duong di tu " + x + " den " + y + " : ");
            while (st.Count > 0)
                Console.Write(" - " + st.Pop());
        }
        //Kiem tra do thi phan doi (hai phia)
        public bool Bipartite()
        {
            // array X, Y mô tả tập X và Y
            // voi X[i] = 1 -> i thuoc X, nguoc lai i khong thuoc X
            // Tuong tu cho tap Y
            int[] Y = new int[v.Length];
            int[] X = new int[v.Length];
            // Khởi tạo X, Y rỗng : X[i] = Y[i] = 0 , mọi i
            for (int i = 0; i < v.Length; i++)
            {
                X[i] = 0; Y[i] = 0;
            }
            // chon dinh v bat ky la dinh 0, bỏ 0 vào tập X

            // Lặp khi X giao Y con khac rong (!XgiaoY(X,Y)) &&
            // X và Y là chưa tối đại (!XYfull(X,Y))
            while (!giaoXY(X, Y) && !XYfull(X, Y))
            {
                // cho Y = Y U Ke(X)

                // cho X = X U Ke(Y)

            }
            // Nếu X giao Y khác rỗng trả về false,

            return true;
        }
        // Kiem tra X giao Y khác rỗng
        // neu la rong tra ve false, khac rong la true
        public bool giaoXY(int[] x, int[] y)
        {
            return false;
        }
        // Kiểm tra X và Y là tối đại, không bổ xung được nữa
        // trả về true : nếu là tối đại, ngược lại false
        public bool XYfull(int[] x, int[] y)
        {
            return false;
        }
        // Kiểm tra có chu trình hay không gồm 2 phương thức: DFSTestCycle(), DFSCycle(int s)
        // Duyệt DFS và tô màu : trả vè true, có chu trình, ngược lại thì không
        public bool DFSCycle(int s)
        {        
            // Đang duyệt : tô màu 1 cho đỉnh s
            color[s] = 1;
            // Duyệt tiếp các đỉnh kề u của s
            foreach (int u in v[s])
            {
              
            // nếu chưa duyệt u (u có màu 0) gọi đệ qui với u
                    if (color[u] == 0) DFSCycle(u);
               
            // Ngược lại, nếu u có màu 1 : trả vế true (có chu trình)
                else if(color[u] == 1) return true;
            }
            // Đến đây s đã duyệt xong s được tô màu 2
            color[s] = 2;
            return false;
        }
        // Kiểm tra chu trình
        public void DFSTestCycle()
        {
            
            // Tô màu 0 cho các đỉnh trước khi duyệt
            for(int i = 0; i < v.Length; i++)
            {
                color[i] = 0;
            }

            // Duyệt từng đĩnh và nhận phản hồi từ DFSCycle(i) cho mỗi đỉnh
            for (int i = 0; i < v.Length; i++)
            {
                // Nếu DFSCycle(i) = true -> có chu trình, ngược lại thì không
                if (DFSCycle(i) == true)
                {
                    Console.WriteLine("Co chu trinh");
                    return;
                }
            }
            Console.WriteLine("Khong co chu trinh");

        }
    }
}
