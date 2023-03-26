using System.Data;
using System.Data.SqlClient;
using BulkInsertSqlServer;
using Newtonsoft.Json;

List<Person> people = new List<Person>();
using (StreamReader r = new StreamReader("C:\\Users\\Gustavo Barbosa\\Downloads\\data.json"))
{
    string json = r.ReadToEnd();
    people = JsonConvert.DeserializeObject<List<Person>>(json);
}

using (var connection = new SqlServerConnection().GetConnection())
{
    DataTable dt = new DataTable();
    dt.TableName = "PessoaCarga";
    dt.Columns.Add(new DataColumn("NOME", typeof(string)));
    dt.Columns.Add(new DataColumn("DOCUMENTO", typeof(string)));

    foreach (var person in people)
    {
        DataRow row = dt.NewRow();
        row["NOME"] = person.Name;
        row["DOCUMENTO"] = person.Document;
        dt.Rows.Add(row);
    }

    using(var bulk = new SqlBulkCopy(connection))
    {
        bulk.BulkCopyTimeout = 10000000;
        bulk.ColumnMappings.Add("NOME", "NOME");
        bulk.ColumnMappings.Add("DOCUMENTO", "DOCUMENTO");
        bulk.DestinationTableName = dt.TableName;
        await bulk.WriteToServerAsync(dt);
    }

}
Console.WriteLine("Finalizou");
