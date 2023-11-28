using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        string textoDecifrado = Decifrar(textoCifrado);

        Console.WriteLine("Conteúdo do texto cifrado:\n" + textoCifrado);

        textoDecifrado = textoDecifrado.Replace("@", "\n");

        string textoDecifradoAtualizado = SubstituirPalindromos(textoDecifrado);

        ExibirInformacoes(textoDecifrado, textoDecifradoAtualizado);
    }

    static string Decifrar(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();

        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            int chave = (i % 5 == 0) ? 8 : 16;
            caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
        }

        return new string(caracteresCifrados);
    }

    static string SubstituirPalindromos(string texto)
    {           //Marcos Gabriel Da Rosa De Almeida************************
        string[] palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] palavrasSubstituidas = new string[palavras.Length];

        for (int i = 0; i < palavras.Length; i++)
        {
            palavrasSubstituidas[i] = SubstituirPalindromo(palavras[i]);
        }

        Console.WriteLine("\nTexto decifrado com substituição de palíndromos:\n" + string.Join(" ", palavrasSubstituidas));

        // Retorna o texto atualizado
        return string.Join(" ", palavrasSubstituidas);
    }

    static string SubstituirPalindromo(string palavra)
    {
        switch (palavra.ToLower())
        {
            case "arara":
                return "gloriosa";
            case "ovo":
                return "bondade";
            case "osso":
                return "passam";
            default:
                return palavra;
        }
    }

    static void ExibirInformacoes(string textoDecifrado, string textoDecifradoAtualizado)
    {
        Console.WriteLine("\nNúmero de caracteres do texto decifrado: " + textoDecifrado.Length);
        Console.WriteLine("Quantidade de palavras no texto decifrado: " + ContarPalavras(textoDecifrado));
        Console.WriteLine("\nTexto decifrado em maiúsculas:\n" + textoDecifradoAtualizado.ToUpper());
    }

    static int ContarPalavras(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
