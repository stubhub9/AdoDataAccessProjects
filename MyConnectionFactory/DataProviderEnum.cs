using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace MyConnectionFactory
//{
//    internal class DataProviderEnum
//    {
//    }
//}
namespace MyConnectionFactory;
//  OleDb is WinOnly; AND UNSUPPORTED in NetCore / Net 5+
enum DataProviderEnum
{
    SqlServer,
#if PC
    OleDb,
#endif
    Odbc,
    None
}
