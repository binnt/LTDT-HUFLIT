
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTBuoi7_NguyenKimLong_18DH110293
{
    class Program
    {
        static int Menu()
        {
            int chon;
            Console.WriteLine();
            Console.WriteLine("     DIJSTRA - TIM DUONG DI NGAN NHAT");
            Console.WriteLine("  1. Tao do thi tu file");
            Console.WriteLine("  2. Xuat do thi DSK len man hinh");
            Console.WriteLine("  3. Duong di ngan nhat tu mot dinh den cac dinh con lai");
            Console.WriteLine("  4. Duong di ngan nhat tu x den y");
            Console.WriteLine("  5. Duong di ngan nhat qua tu x den y qua dinh trung gian z");
            Console.WriteLine("  0. Thoat");
            Console.Write("     Chon : ");
            chon = int.Parse(Console.ReadLine());
            Console.WriteLine("  **************************************");

            return chon;
        }
        static void Main(string[] args)
        {
            DijkstraDSK g = new DijkstraDSK();
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
                            Console.WriteLine("Duong di ngan nhat tu dinh s den cac dinh con lai : ");
                            Console.Write("  Nhap dinh s : ");
                            int s = int.Parse(Console.ReadLine());
                            g.Dijkstra(s);
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Tim duong di ngan nhat tu dinh x den dinh y");
                            Console.Write("  Nhap dinh x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Nhap dinh y : ");
                            int y = int.Parse(Console.ReadLine());
                            g.MinXY(x, y);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Tim duong di ngan nhat tu dinh x den dinh y qua dinh trung gian z");
                            Console.Write("  Nhap dinh x : ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("  Nhap dinh y : ");
                            int y = int.Parse(Console.ReadLine());
                            Console.Write("  Nhap dinh z : ");
                            int z = int.Parse(Console.ReadLine());
                            g.MinXYZ(x, y, z);
                            break;

                        }
                }
            } while (chon != 0);
        }
    }
}
