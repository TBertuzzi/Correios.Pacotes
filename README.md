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
|PageControl|[![NuGet](https://img.shields.io/badge/nuget-1.0.0-blue.svg)](https://www.nuget.org/packages/Correios.Pacotes/)|
|Build status|[![appveyor](https://img.shields.io/teamcity/codebetter/bt428.svg)](https://ci.appveyor.com/project/ThiagoBertuzzi/correios-pacotes/)|

Exemplo

```csharp

 static void Main(string[] args)
        {
            Rastreador rastreador = new Rastreador();

            Pacote pacote = rastreador.ObterPacote("OF310011814BR");

            Console.WriteLine("Data - Localização - StatusCorreio - Observação");
            foreach (Status status in pacote?.Historico)
            {
                Console.WriteLine("{0:dd/MM/yyyy HH:mm} - {1} - {2} - {3}", status.Data, status.Localizacao, status.StatusCorreio, status.Obervacao);
                Console.WriteLine("###############################################################");
            }

            Console.ReadLine();
        }

```

