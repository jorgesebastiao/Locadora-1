# Locadora

Implementação de um sistema que realiza o CRUD de Locações

Os filmes serão inseridos no banco ao executar a migração com o EntityFramework, através do comando

  ```sh
  Update-Database
  ```
Para executar o backend deve ser aberto o projeto e pressionar o botão F5

A conectionString padrão é

  ``"Server=(localdb)\\mssqllocaldb;Database=RentalDatabase;Trusted_Connection=True;"``
  
mas pode ser modificada no arquivo appsettings.json.

Também criei uma Collection no Postman que realiza as operações no Backend.
Ela está disponível no link [Locadora Collection](https://www.getpostman.com/collections/96d8c8df0693ba6b3397) e pode ser importada dentro do Postman.

O front-end foi desenvolvido em React e deve ser executado através do comando ``npm start``
