<h1 align="center">TDD-xUnit-e2e</h1>
<p align="center">
  <a href="#metodologias">Metodologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#projeto">Projeto</a>
</p>

## Metodologias

Para a modelagem do projeto de software foi utilizado um conceito chamado DDD, já para o processo de desenvolvimento utilizou-se o conceito TDD, explicados brevemente na sequêcia.

### TDD
TDD é uma sigla para *Test Driven Development*, ou Desenvolvimento Orientado a Testes que conciste em uma metodologias que auxilia a aplicação testes no código de maneira mais granular, por isso é indicada para testes unitários. A premissa para esse conceito é que os testes sejam codificados **sempre antes** do desenvolvimento do software.

A ideia do TDD é que o processo de desenvolvimento ocorra em ciclos. Estes ciclos devem acontecer na seguinte ordem:
1. Primeiro, escreva um teste unitário que inicialmente irá falhar, tendo em vista que o código ainda não foi implementado;
2. Crie o código que satisfaça esse teste, ou seja: implemente a funcionalidade em questão. Essa primeira implementação deverá satisfazer imediatamente o teste que foi escrito no ciclo anterior;
3. Quando o código estiver implementado e o teste satisfeito, refatore o código implementando conceitos de *Clean Code*, por exemplo. Logo após, execute o teste novamente. A nova versão do código também deverá passar sem que seja necessário modificar o teste escrito inicialmente.


<img align="center" src="https://github.com/ronaldops06/TDD-xUnit-e2e/blob/main/.github/tdd_ciclo.png" />

### DDD

DDD é um acrônimo para *Domain Driven Design*. Não se trata diretamente de uma arquitetura ou uma tecnologia; mas sim uma filosofia que prega o desenvolvimento de software de maneira alinhada aos aspectos de negócio com foco na entrega de valor.

No DDD, toda a arquitetura desenhada e até mesmo os termos utilizados nas documentações e no código devem ter relação direta com os componentes de negócio, ou seja, o domínio do software.
#### Linguagem ubíqua
Devido ao fato de o DDD ser totalmente voltado ao negócio, não existe espaço para a utilização de termos ambíguos para a definição das estruturas de software. Todos os times envolvidos no projeto devem utilizar os mesmos termos e nomes para se referenciarem aos componentes de negócio do projeto.

#### Bounded contexts

Apesar na premissa de que não devem existir ambíguidades, existem situações em que até mesmo a linguagem ubíqua pode sofrer variações dentro do mesmo domínio e subdomínio, o que é chamado de bounded contexts. Um exemplo pra isso pode ser o domínio **Controle de Fluxo**, com o subdomínio **Marketing** e com os bounded contexts **Lead** (Futuro cliente) e **Cliente** (Cliente efetivo). 

Utilizar o DDD para visualizar o domínio, os subdomínios e os bounded contexts pode ajudar no processo de design da arquitetura do projeto, já que estes conceitos já apresentam divisões lógicas de maneira totalmente alinhada com o negócio.

Geralmente, subdomínios e bounded contexts acabam por se tornar serviços e microserviços dentro da arquitetura proposta para a resolução do domínio.

#### Arquitetura Implementada com Base no DDD

<img align="center" src="https://github.com/ronaldops06/TDD-xUnit-e2e/blob/main/.github/ddd_organograma.png" />

1. Application:
	
	Esta camada é a "porta de entrada" do sistema, pois é nela que estão os controladores e serviços para efetuar as chamadas na API.
2. Service:

	É nessa camada que disponibiliza-se todas as regras de negócio e validações necessárias. O pacote instalado servirá como framework para efetuar validações de objetos referentes às entidades.
	
3. Domain:
	
	Essa camada implementada o domínio, que é basicamente o problema do ponto de vista de negócio a ser resolvido, o domínio justifica a existência do software.
4. Infrastruture:
	1. Cross Cutting:
	
		Representa uma camada cruzada (corte transversal), onde devem ser implementadas soluções que podem ser usadas por todos os outros projetos. Pode ser usada para implementar uma chamada de uma API externa, métodos genéricos para todas as aplicações, estender algo que possa ser colocado na estrutura, mapeamentos automáticos (AutoMapper), entre outros.
	
	2. Data
	
		É a camada responsável por realizar a persistência dos dados, gerenciando o banco de dados, desde a criação de tabelas até o tratamento dos dados efetivamente, ou em um sistema de arquivo, por exemplo.
	
## Projeto

### Comandos .Net
Criar uma nova Solution

> dotnet new sln --name <Nome Solution>

Criar um novo Projeto
* Executar na pasta onde se encontra a solution
> dotnet new <Tipo Projeto> -n <Nome Projeto> -o <Local (namespace) na Solution onde será criado> [-f <versão framework>]

Adicionar o Projeto a Solution
* Executar na pasta onde se encontra a solution e o projeto
> dotnet sln add <Nome do Projeto>

Executar a restauração dos arquivos da aplicação
> dotnet restore

Executar o Build da Solution
* Executar na pasta onde se encontra a solution
> dotnet build

### Criação da Arquitetura do Projeto
1. Criar a Solution Api

> dotnet new sln --name Api

2. Criar o Projeto Application (WebApi) e Adicionar a Solution Api

> dotnet new webapi -n Application -o Api.Application
>
> dotnet sln add Api.Application

* Remover todas as classes relacionadas a WeatherForecast, criadas automaticamente.

3. Criar o Projeto Domain (ClassLibrary) e Adicionar a Solution Api

> dotnet new classlib -n Domain -o Api.Domain -f netcoreapp3.1

> dotnet sln add Api.Domain

4. Criar o Projeto CrossCutting (ClassLibrary) e Adicionar a Solution Api

> dotnet new classlib -n CrossCutting -o Api.CrossCutting -f netcoreapp3.1

> dotnet sln add Api.CrossCutting

5. Criar o Projeto Data (ClassLibrary) e Adicionar a Solution Api

> dotnet new classlib -n Data -o Api.Data -f netcoreapp3.1

> dotnet sln add Api.Data

6. Criar o Projeto Service (ClassLibrary) e Adicionar a Solution Api

> dotnet new classlib -n Service -o Api.Service -f netcoreapp3.1

> dotnet sln add Api.Service

### Desenvolvimento

<details>
<summary>Estrutura</summary>
<pre>
└───src
    │   Api.sln
<details><summary>Application</summary>
    ├───Api.Application
    │   │   application.csproj
    │   │   appsettings.Development.json
    │   │   appsettings.json
    │   │   Program.cs
    │   │   Startup.cs
    │   │
    │   ├───Controllers
    │   │       LoginController.cs -> ControllerBase
    │   │       UsersController.cs -> ControllerBase
    │   │
    │   └───Properties
    │           launchSettings.json
</details>
<details><summary>ApplicationTest</summary>
    ├───Api.Application.Test
    │   │   Api.Application.Test.csproj
    │   │
    │   └───User
    │       ├───WhenRequestCreate
    │       │       ReturnBadRequest.cs
    │       │       ReturnCreated.cs
    │       │
    │       ├───WhenRequestDelete
    │       │       ReturnBadRequest.cs
    │       │       ReturnDeleted.cs
    │       │
    │       ├───WhenRequestGet
    │       │       ReturnBadRequest.cs
    │       │       ReturnGet.cs
    │       │
    │       ├───WhenRequestGetAll
    │       │       ReturnBadRequest.cs
    │       │       ReturnGetAll.cs
    │       │
    │       └───WhenRequestUpdate
    │               ReturnBadRequest.cs
    │               ReturnUpdated.cs
</details>
<details><summary>CrossCutting</summary>
    ├───Api.CrossCutting
    │   │   CrossCutting.csproj
    │   │
    │   ├───DependencyInjection
    │   │       ConfigureRepository.cs
    │   │       ConfigureService.cs
    │   │
    │   ├───Mappings
    │   │       DtoToModelProfile.cs	-> Profile
    │   │       EntityToDtoProfile.cs	-> Profile
    │   │       ModelToEntityProfile.cs	-> Profile
    │   │
    │   │
    │   └───Properties
    │           launchSettings.json
</details>
<details><summary>Data</summary>
    ├───Api.Data
    │   │   Data.csproj
    │   │   global.json
    │   │
    │   ├───Context
    │   │       ContextFactory.cs	-> IDesignTimeDbContextFactory<MyContext>
    │   │       MyContext.cs	-> DbContext
    │   │
    │   ├───Implementations
    │   │       UserImplementation.cs	-> BaseRepository<Domain.Entities.UserEntity>, Domain.Repository.IUserRepository
    │   │
    │   ├───Mapping
    │   │       UserMap.cs	-> IEntityTypeConfiguration<Domain.Entities.UserEntity>
    │   │
    │   ├───Repository
    │   │       BaseRepository.cs	-> Domain.Interfaces.IRepository<T> where T : Domain.Entities.BaseEntity
    │   │
    │   └───Seeds
    │           UfSeeds.cs
</details>
<details><summary>DataTest</summary>
    ├───Api.Data.Test
    │   │   Api.Data.Test.csproj
    │   │   BaseTest.cs
    │   │   UserCrudComplete.cs
    │   │
</details>
<details><summary>Domain</summary>
    ├───Api.Domain
    │   │   Domain.csproj
    │   │
    │   ├───Dtos
    │   │   │   LoginDto.cs
    │   │   │
    │   │   └───User
    │   │           UserDto.cs
    │   │           UserDtoResult.cs
    │   │
    │   ├───Entities
    │   │       BaseEntity.cs
    │   │       UserEntity.cs	-> BaseEntity
    │   │
    │   ├───Interfaces
    │   │   │   IRepository.cs
    │   │   │
    │   │   └───Services
    │   │       │
    │   │       └───User
    │   │               ILoginService.cs
    │   │               IUserService.cs
    │   │
    │   ├───Models
    │   │       BaseModel.cs
    │   │       UserModel.cs	-> BaseModel
    │   │
    │   ├───Repository
    │   │       IUserRepository.cs	-> IRepository<UserEntity>
    │   │
    │   └───Security
    │           SigningConfiguration.cs
</details>
<details><summary>IntegrationTest</summary>
    ├───Api.Integration.Test
    │   │   Api.Integration.Test.csproj
    │   │   BaseIntegration.cs
    │   │   LoginResponseDto.cs
    │   │
    │   └───User
    │           WhenRequestUser.cs
</details>
<details><summary>Service</summary>
    ├───Api.Service
    │   │   Service.csproj
    │   │
    │   └───Services
    │           LoginService.cs	-> Domain.Interfaces.Services.User.ILoginService
    │           UserService.cs	-> Domain.Interfaces.Services.User.IUserService
</details>
<details><summary>ServiceTest</summary>
    └───Api.Service.Test
        │   Api.Service.Test.csproj
        │   BaseTestService.cs
        │
        ├───AutoMapper
        │       UserMapper.cs
        │
        ├───Login
        │       WhenExecuteFindByLogin.cs
        │
        └───User
                UserTest.cs
                WhenExecuteCreate.cs
                WhenExecuteDelete.cs
                WhenExecuteGet.cs
                WhenExecuteGetAll.cs
                WhenExecuteUpdate.cs
</details>
<pre>
</details>

<details>
<summary>Referências Entre Projetos</summary>

|**Projeto**|**Projeto Teste**|
|:-|:-|
|**Api.Application** |**Api.Application.Test** |
|└─ Api.Domain |└─ Api.Domain|
|└─ Api.Service |└─ Api.Service|
|└─ Api.CrossCutting|└─ Api.Application|
|||
|**Api.Service**|**Api.Service.Test**|
|└─ Api.Domain|└─ Api.Domain|
|└─ Api.Data|└─ Api.CrossCutting|
||└─ Api.Service|
|||
|**Api.Data**|**Api.Data.Test**|
|└─ Api.Domain|└─ Api.Domain|
||└─ Api.CrossCutting|
||└─ Api.Data|
|||
|**Api.CrossCutting**|
|└─ Api.Domain|
|└─ Api.Service|
|└─ Api.Data|
|||
|**Api.Domain**||
|Sem referências|
|||
||**Api.Integration.Test**|
||└─ Api.Application|
||└─ Api.Domain|
||└─ Api.Data|
||└─ Api.CrossCutting|

</details>

<details>
<summary>Pacotes Nuget Instalados</summary>

||Application|Domain|Service|CrossCutting|Data|Application.Test|Service.Test|Data.Test|Integration.Test|
|:-|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
|Swashbuckle.AspNetCore|x|-|-|-|-|-|-|-|-|
|Microsoft.AspNetCore.Authentication.JwtBearer|x|-|-|-|-|-|-|-|-|
|System.IdentityModel.Tokens.Jwt|-|x|-|-|-|-|-|-|-|
|Pomelo.EntityFrameworkCore.MySql|-|x|-|x|x|-|-|-|-|
|Microsoft.EntityFrameworkCore.Design|x|x|-|x|x|-|-|x|x|
|Microsoft.EntityFrameworkCore.Tools|x|x|-|x|x|-|-|x|x|
|AutoMapper|-|-|x|x|-|-|x|-|x|
|AutoMapper.Extensions.Microsoft.DependencyInjection|-|-|-|x|-|-|x|x|x|
|Microsoft.NET.Test.Sdk|-|-|-|-|-|x|x|x|x|
|xunit|-|-|-|-|-|x|x|x|x|
|xunit.runner.visualstudio|-|-|-|-|-|x|x|x|x|
|coverlet.collector|-|-|-|-|-|x|x|x|x|
|Faker.NETCore|-|-|-|-|-|x|x|x|x|99
|Moq|-|-|-|-|-|x|x|-|-|
|Newtonsoft.Json|-|-|-|-|-|-|-|-|x|
|Microsoft.AspNetCore.TestHost|-|-|-|-|-|-|-|-|x|

</details>