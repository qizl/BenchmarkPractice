using BenchmarkDotNet.Attributes;
using BenchmarkPractice.Nfx.Models;
using Com.EnjoyCodes.SqlHelper;
using System;
using System.Configuration;

namespace BenchmarkPractice.Nfx
{
    public class Orm
    {
        string _connectionString = ConfigurationManager.AppSettings["MSSQLConnectionString"];

        [Benchmark]
        public void Reflection()
        {
            for (var i = 0; i < 100; i++)
                SqlHelper<OrderDetail>.Read(this._connectionString, "id=4896484");
        }

        [Benchmark]
        public void AdoNet()
        {
            for (var i = 0; i < 100; i++)
            {
                var r = SqlHelper.ExecuteDataSet(this._connectionString, System.Data.CommandType.Text, "SELECT 'OrderDetail' MODELNAME,Id PK,* FROM T_OrderDetail WHERE id=4896484;");
                var orderDetail = new OrderDetail
                {
                    Id = Convert.ToInt32(r.Tables[0].Rows[0]["Id"]),
                    OrderId = Convert.ToInt32(r.Tables[0].Rows[0]["OrderId"]),
                    InName = r.Tables[0].Rows[0]["InName"].ToString(),
                    InUserNo = r.Tables[0].Rows[0]["InUserNo"].ToString(),
                    OutPaperCode = Convert.ToInt32(r.Tables[0].Rows[0]["OutPaperCode"])
                };
            }
        }
    }
}
