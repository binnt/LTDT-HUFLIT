using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT_Buoi05_18DH110800
{
    class Program
    {
        static int Menu()
        {
            int chon;
            Console.WriteLine();
            Console.WriteLine("     CHON CONG VIEC");
            Console.WriteLine("  1. Tao do thi tu file");
            Console.WriteLine("  2. Xuat do thi DSK len man hinh");
            Console.WriteLine("  3. Duyet do thi DFS");
            Console.WriteLine("  4. Tim duong di tu x den y");
            Console.WriteLine("  0. Thoat");
            Console.Write("     Chon : ");
            chon = int.Parse(Console.ReadLine());
            Console.WriteLine("  **************************************");

            return chon;
        }
        static void Main(string[] args)
        {
            GraphDSK g = new GraphDSK();
            int chon;

            do
            {
                chon = Menu();
                Console.WriteLine();
                switch (chon)
                {
                    case 1: { g.FileToDSke(); break; }
                    case 2:
                        {
                            Console.WriteLine("Do thi DSK : ");
                            g.Output();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Duyet do thi DFS tu cac dinh : ");
                            for (int i = 0; i < g.V.Length; i++)
                            {
                                g.DuyetDFS(i);
                                Console.WriteLine("");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Tim duong di tu dinh x den dinh y");
                            Console.Write("  Nhap dinh x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Nhap dinh y : ");
                            int y = int.Parse(Console.ReadLine());
                            g.DFSTimDuongdi(x, y);
                            break;
                        }
                }
            } while (chon != 0);
        }
    }
}
