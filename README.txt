Esta Open API serve para fins de entendimento de como funciona de forma básica o Entity Framework juntamente com o Swagger.

Requisitos Recomendados:
- SGBD com SQL Server;
- Visual Studio;

Para que você possa fazer a utilização da API, realize esses seguintes passos:
- Vá em appsettings.json e configure a sua conexão com o Banco de Dados informando o servidor e a senha;
- Depois, abra o Console do Package Manager e realize os seguintes comandos:
	- Add-Migration <Nome da sua Migration> -Context DatabaseContext;
	- Update-Database -Context DatabaseContext;
- Rode a API localmente com F5;
- Execute os métodos HTTP apresentados no Swagger, preencha os objetos e depois execute;
- Consulte o Banco de Dados via SQL Server para ver se foi realizada a ação corretamente.

Observações:
- O que é uma Migration?
Migration é uma forma de manter o Esquema de Banco de Dados sincronizado com o Entity Framework, assim montando todo
um código estruturado para realizar a criação do Banco de Dados;

- O que é o Update-Database?
Esse comando realiza as querys necessárias para a criação do Banco de Dados, assim também verifica as alterações no código C# e atualiza
o seu modelo de dados.
