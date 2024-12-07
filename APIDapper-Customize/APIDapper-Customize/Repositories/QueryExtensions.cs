using APIDapper_Customize.Helpers;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient;

namespace APIDapper_Customize.Repositories
{
    public static class QueryExtensions
    {
        public static async Task<PagedResultHelper<T>> QueryPagedAsync<T>(this SqlConnection connection, string sql, object param, IDbTransaction transaction = null)
        {
            sql = NormalizeSql(sql);

            string totalRegistersSql = BuildToTalRegistersSql(sql);

            sql = AppendPagination(sql);

            var totalRegisters = await connection.QueryFirstOrDefaultAsync<int>(totalRegistersSql, param, transaction);
            var data = await connection.QueryAsync<T>(sql, param, transaction);

            return new PagedResultHelper<T>
            {
                Data = data,
                TotalRegisters = totalRegisters
            };
        }

        private static string NormalizeSql(string sql)
        {
            sql = sql.Trim();
            if (sql.EndsWith(";"))
                sql = sql.Substring(0, sql.Length - 1);
            return sql;
        }

        private static string BuildToTalRegistersSql(string sql)
        {
            sql = sql.ToLower();
            if (sql.Contains("order by"))            
                sql = sql.Substring(0, sql.IndexOf("order by"));
            
            return $@"select count(1) from ({sql}) as cnt;";
        }

        private static string AppendPagination(string sql)
        {
            sql += $@"
                    offset ((@page - 1) * @pageSize) rows
                    fetch next @pageSize rows only;";
            return sql;
        }
    }
}
