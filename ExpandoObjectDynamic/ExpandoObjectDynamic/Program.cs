// Salve galera blz, bem vindos ao canal manual do programador, no video de hoje vamos fazer um
// exemplo em .net core, onde vamos criar e manipular um objeto do tipo dynamic. Vamos nessa

using System.Dynamic;
using Newtonsoft.Json;

dynamic expandDynamic = new ExpandoObject();

expandDynamic.Nome = "Pedro";
expandDynamic.Idade = 25;

Console.WriteLine(expandDynamic.Nome);
Console.WriteLine(expandDynamic.Idade);
Console.WriteLine("-----------------------");

//Sem a conversao nao e possivel acessar campos nulos
var json = "{\"nome\":\"Alberto\",\"email\":\"alberto@teste.com\",\"sexo\":null,\"idade\":null}";
dynamic expandoDynamicJson = JsonConvert.DeserializeObject<ExpandoObject>(json);
Console.WriteLine(expandoDynamicJson.email);

//Apos a conversao e possivel chamar os campos que estao com valores nulos
var data = expandoDynamicJson as IDictionary<string, object>;

Console.WriteLine(data["nome"]);
Console.WriteLine(data["idade"]);

// Mas um campo que nao estao no json, nao é possível acessa-lo
//Console.WriteLine(data["dataNascimento"]);

if (data.ContainsKey("dataNascimento"))
    Console.WriteLine(data["dataNascimento"]);
else
    Console.WriteLine("Campo nao informado no json");


// Entao a vantagem que a gente tem em fazer essa conversao é que conseguimos manipular um campo mesmo
// ele não estando no json



