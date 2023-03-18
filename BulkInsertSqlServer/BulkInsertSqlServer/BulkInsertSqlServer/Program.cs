using System.Data;
using System.Data.SqlClient;
using BulkInsertSqlServer;
using Newtonsoft.Json;

List<Person> people = new List<Person>();
using (StreamReader r = new StreamReader("/Users/gustavobarbosa/Downloads/data.json"))
{
    string json = r.ReadToEnd();
    people = JsonConvert.DeserializeObject<List<Person>>(json);
}

using (var connection = new SqlServerConnection().GetConnection())
{
    DataTable dt = new DataTable();
    dt.TableName = "PessoaCarga";
    dt.Columns.Add(new DataColumn("Nome", typeof(string)));
    dt.Columns.Add(new DataColumn("Documento", typeof(string)));

    foreach (var person in people)
    {
        DataRow row = dt.NewRow();
        row["Nome"] = person.Name;
        row["Documento"] = person.Document;
    }

    using(var bulk = new SqlBulkCopy(connection))
    {
        bulk.BulkCopyTimeout = 10000000;
        bulk.ColumnMappings.Add("Nome", "Nome");
        bulk.ColumnMappings.Add("Documento", "Documento");
        bulk.DestinationTableName = dt.TableName;
        bulk.WriteToServerAsync(dt).Wait();
    }

}
Console.WriteLine("Finalizou");
