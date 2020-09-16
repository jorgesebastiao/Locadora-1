# Locadora

Implementação de um sistema que realiza a administração de uma locadora.

Para a implementação foi utilizado o conceito de [Arquitetura em Camadas](http://www.macoratti.net/13/09/net_ncam.htm)

Alguns dados serão inseridos durante a criação do banco, essa inserção vai ocorrer ao executar a migração com o EntityFramework, através do comando

  ```sh
  Update-Database
  ```
Também foi utilizada a biblioteca [Dapper](https://www.nuget.org/packages/Dapper/) para realizar as consultas da entidade Genêro.

Para executar o backend deve ser aberto o projeto e pressionar o botão F5

A conectionString padrão é

  ``"Server=(localdb)\\mssqllocaldb;Database=RentalDatabase;Trusted_Connection=True;"``

portanto, é necessário possuir o SQL Server instalado localmente e o usuário atual deve ter permissões de administração do banco.
Essa connectionstring pode ser modificada no arquivo appsettings.json.

Também criei uma Collection no Postman que realiza as operações no Backend.
Ela está disponível no link [Locadora Collection](https://www.getpostman.com/collections/96d8c8df0693ba6b3397) e pode ser importada dentro do Postman.

O front-end foi desenvolvido em React e deve ser executado através do comando ``npm start``.

Para fazer login no front-end deve ser utilizado o ID informado no momento da criação do Cliente.

Existem testes de unidade para a entidade Filme.

Para todas as entidades foram criadas APIs de Adição, Busca, Update e Delete.
A entidade Cliente não possui opção de update e delete no momento.
