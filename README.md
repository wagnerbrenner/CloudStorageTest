# API de Armazenamento em Nuvem - Envio de Arquivo JPEG para Google Drive

Esta API foi desenvolvida em C# .NET e permite enviar arquivos JPEG para o Google Drive de forma simples e eficiente.

## Requisitos

- Visual Studio (ou outra IDE compatível com C#)
- Conta de Serviços do Google Cloud com permissões para acessar o Google Drive
- Pacotes NuGet: `Google.Apis.Drive.v3`

## Configuração

1. Crie um projeto no Google Cloud Platform [console.cloud.google.com](https://console.cloud.google.com/)
2. Ative a API do Google Drive para o projeto
3. Crie uma Conta de Serviços e baixe o arquivo JSON de credenciais
4. Adicione o arquivo JSON de credenciais ao seu projeto C#
5. Instale o pacote NuGet `Google.Apis.Drive.v3` em seu projeto

## Utilização

1. Instancie um cliente `DriveService` utilizando suas credenciais do Google Cloud
2. Carregue o arquivo JPEG para enviar para o Google Drive
3. Crie um objeto `File` com as propriedades do arquivo a ser enviado
4. Utilize o método `Files.Create` do `DriveService` para enviar o arquivo para o Google Drive

```csharp
// Exemplo de código para enviar um arquivo JPEG para o Google Drive

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

namespace CloudStorageAPI
{
    class Program
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Cloud Storage API";

        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Carregue o arquivo JPEG
            byte[] fileBytes = File.ReadAllBytes("example.jpg");

            // Crie um objeto File com as propriedades do arquivo
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "example.jpg"
            };

            // Envie o arquivo para o Google Drive
            using (var stream = new MemoryStream(fileBytes))
            {
                var request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                var file = request.Execute();
                Console.WriteLine("File ID: " + file.Id);
            }
        }
    }
}
```

##Contribuição
  Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests ou abrir problemas.
