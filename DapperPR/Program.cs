using System;
using Dapper;
using System.Data.SqlClient;
using System.IO;

namespace DapperPR
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection =
                @"Data Source=192.168.40.1;Initial Catalog=edidb; User ID=sa; Password=SitioM1";

            using (var db = new SqlConnection(connection))
            {
                var sql = "select tea.isa,tea.isa_01,tea.isa_02,tea.isa_03,tea.isa_04,tea.isa_05,tea.isa_06,tea.isa_07,"+
                              "tea.isa_08,tea.isa_09,tea.isa_10,tea.isa_10,tea.isa_11,tea.isa_12,tea.isa_13,tea.isa_14," +
	                          "tea.isa_15,tea.isa_16,tea.b2_02,tea.b2_04,tea.gs,tea.gs_01,tea.gs_02,tea.gs_03,tea.gs_04," +
                              "tea.gs_05,tea.gs_06,tea.gs_07,tea.gs_08,tea.st,tea.st_01,tea.st_02,tea.g62,tea.g62_01," +
                              "tea.g62_02,tea.g62_03,g62_04,g62_05,tea.l3,tea.l3_01,tea.l3_02,tea.l3_03,tea.l3_04,tea.l3_05,"+
	                          "tea.l3_06,tea.l3_07,tea.l3_08,tea.l3_09,tea.l3_10,tea.l3_11," +
	                          "tea100.codigo,tea100.c01,tea100.c02,tea100.c03,tea100.c04,tea100.c05,tea100.c06 " +
                          "from edidb.dbo.trafico_edi_archivo tea with(nolock), "+
	                           "edidb.dbo.trafico_edi_archivo_L100 tea100 with(nolock) "+
                          "where tea.id_archivo = 343 "+
                                 "and tea.id_archivo = tea100.id_archivo "+
                                 "and tea100.codigo = 'N1'";

                var lst = db.Query<Consulta>(sql);

                foreach(var oElement in lst)
                {
                   
                    string scac = oElement.b2_02;
                    string shipment = oElement.b2_04;

                    TextWriter write_210 = new StreamWriter("prueba_crea_210.edi");

                    write_210.WriteLine(oElement.isa + "*" + oElement.isa_02 + "*" + oElement.isa_03 + "*" + oElement.isa_04 + "*" +
                                      oElement.isa_05 + "*" + oElement.isa_06 + "*" + oElement.isa_07 + "*" + oElement.isa_08 + "*" +
                                      oElement.isa_09 + "*" + oElement.isa_10 + "*" + oElement.isa_11 + "*" + oElement.isa_12 + "*" +
                                      oElement.isa_13 + "*" + oElement.isa_14 + "*" + oElement.isa_15 + "*" + oElement.isa_16);
                    write_210.WriteLine(oElement.gs + "*" + oElement.gs_01 + "*" + oElement.gs_02 + "*" + oElement.gs_03 + "*" +
                                      oElement.gs_04 + "*" + oElement.gs_05 + "*" + oElement.gs_06 + "*" + oElement.gs_07 + "*" +
                                      oElement.gs_08);
                    write_210.WriteLine(oElement.st + "*" + oElement.st_01 + "*" + oElement.st_02);
                    write_210.WriteLine(oElement.g62 + "*" + oElement.g62_01 + "*" + oElement.g62_02 + "*" + oElement.g62_03 + "*" +
                                      oElement.g62_04 + "*" + oElement.g62_05);


                    write_210.WriteLine(oElement.l3 + "*" + oElement.l3_01 + "*" + oElement.l3_02 + "*" + oElement.l3_03 + "*" +
                                      oElement.l3_04 + "*" + oElement.l3_05 + "*" + oElement.l3_06 + "*" + oElement.l3_07 + "*" +
                                      oElement.l3_08 + "*" + oElement.l3_09 + "*" + oElement.l3_11);
                    //N1*BT
                    write_210.WriteLine(oElement.codigo + "*" + oElement.c01 + "*" + oElement.c02 + "*" + oElement.c03 + "*" +
                                      oElement.c04 + "*" + oElement.c05 + "*" + oElement.c06);
                    write_210.Close();

                    
                   
                }


            }
        }
    }
}
