using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTBuoi3_NguyenTheNguyen
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphDSK g = new GraphDSK();
            g.FileToDSke();
            g.Output();
            g.BFS(0);
            g.BFSxy(2,6);
            if(g.Lienthong(0))
            {
                Console.WriteLine("Do thi lien thong");
            }
            else
            {
                Console.WriteLine("Do thi khong lien thong");
            }
            Console.ReadLine();
        }
    }
}
