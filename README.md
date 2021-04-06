# Correios.Pacotes

Obtenha informações dos seus pacotes ou encomendas dos correios brasileiros.

 
###### Este componente funciona com Qualquer Plataforma .Net.

* .NET Framework 4.6.1 +
* .NET Core
* Xamarin
* Xamarin.Forms


**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|Correios.Pacotes|[![NuGet](https://buildstats.info/nuget/Correios.Pacotes)](https://www.nuget.org/packages/Correios.Pacotes/)|


Exemplo

```csharp

 static void Main(string[] args)
        {
            Rastreador rastreador = new Rastreador();

            Pacote pacote = rastreador.ObterPacote("OF310011814BR");

            Console.WriteLine("Data - Localização - StatusCorreio - Observação");
            foreach (Status status in pacote?.Historico)
            {
                Console.WriteLine("{0:dd/MM/yyyy HH:mm} - {1} - {2} - {3}", status.Data, status.Localizacao, status.StatusCorreio, status.Observacao);
                Console.WriteLine("###############################################################");
            }

            Console.ReadLine();
        }

```

