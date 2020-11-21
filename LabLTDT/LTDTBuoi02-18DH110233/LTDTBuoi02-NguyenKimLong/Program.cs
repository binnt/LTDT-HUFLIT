using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTBuoi02_NguyenKimLong
{
    class Program
    {
        static void Main(string[] args)
        {
            // Danh sach canh
            Console.WriteLine("DO THI DANH SACH CANH");
            DSC_DSK gDSC = new DSC_DSK();
            gDSC.FileToG();
            gDSC.Output();
            Console.WriteLine("Danh sach canh sang danh sach ke");
            gDSC.DSCsangDSK();
            gDSC.OutputDSCsangDSK();
            Console.WriteLine("---------------------------------------");
            // Danh sach ke
            Console.WriteLine("DO THI DANH SACH KE");
            GraphDSK gDSK = new GraphDSK();
            gDSK.FileToDSke();
            gDSK.Output();
            Console.WriteLine();
            Console.WriteLine("Danh sach ke sang danh sach canh");
            gDSK.DSKsangDSC();
            gDSK.OutputDSKsangDSC();
        }
    }
}
