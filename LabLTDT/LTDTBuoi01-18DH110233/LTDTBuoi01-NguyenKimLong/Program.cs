using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTBuoi01_LeHoangVu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bai1();
            //Console.WriteLine("-----------------------------------");
            //Bai2();
            Console.WriteLine("-----------------------------------");
            Bai3();
        }
        static void Bai1()
        {
            GraphMTK mTK = new GraphMTK();
            mTK.FileToG();
            mTK.Outgraph();
            Console.WriteLine("Nhap dinh so: ");
            int dinh = int.Parse(Console.ReadLine());
            Console.WriteLine("Bac cua dinh {0}: {1}", dinh, mTK.BacdinhI(dinh));
            mTK.BacCacDinh();
        }
        static void Bai2()
        {
            GraphMTK_2 mTK2 = new GraphMTK_2();
            mTK2.FileToG();
            mTK2.Outgraph();
            Console.WriteLine("Nhap dinh so: ");
            int dinh = int.Parse(Console.ReadLine());
            Console.WriteLine("Bac vao cua dinh {0}: {1}", dinh, mTK2.BacVaodinhI(dinh));
            Console.WriteLine("Bac ra cua dinh {0}: {1}", dinh, mTK2.BacRadinhI(dinh));
            mTK2.BacCacDinh();

        }
        static void Bai3()
        {
            GraphDSK dSK = new GraphDSK();
            dSK.FileToDSke();
            dSK.Output();
            dSK.BacDinh();
        }
    }
}
