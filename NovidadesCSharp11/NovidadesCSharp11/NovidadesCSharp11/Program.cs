// JSON

using NovidadesCSharp11.ModificadorFile;
using System.Text;

var jsonAntigo = "{\"nome\":\"CauêDiogodaCosta\",\"idade\":52,\"cpf\":\"774.463.907-35\"}";

var nome = "Pedro";
var jsonVersaoNova = $$"""	 
	{
		"nome": "{{nome}}",
		"idade": 52,
		"cpf": "774.463.907-35"
	}
	""";

Console.WriteLine(jsonAntigo);

// Quando a gente converte algo para um array de byts


ReadOnlySpan<byte> bytesAntigoNome = Encoding.UTF8.GetBytes("Manual do programador");
ReadOnlySpan<byte> bytesNovoNome = "Manual do programador"u8;


// Interpolação de strings em uma nova linha

var canal = "Manual do programador";
Console.WriteLine($"Olá {canal
						.ToUpper()}");



// Busca de palavras
string text = "Manual do Programado";

if(text is "Manual do Programado")
	Console.WriteLine(text);

if (text is ['M', ..])
    Console.WriteLine("Começa com a letra M");



// Membros obrigatórios de uma classe, onde seu valor só podera ser atribuido na construção do objeto

var user = new User
{
	Nome = "Alberto"
};


public class User
{
	public string Nome { get; init; }
}