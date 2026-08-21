# Chamado Manager

Sistema de gerenciamento de chamados desenvolvido com **C# e ASP.NET Core MVC**, com foco no controle de solicitações entre clientes, funcionários e administradores.

O projeto aplica conceitos de arquitetura MVC, autenticação, autorização, persistência de dados e organização de regras de negócio.

## Funcionalidades

* Cadastro e autenticação de usuários
* Controle de acesso por perfil
* Criação de chamados
* Edição de chamados
* Atribuição de funcionários
* Alteração de status
* Adição de comentários
* Histórico de alterações
* Gerenciamento de chamados por cliente
* Gerenciamento de chamados atribuídos aos funcionários

## Perfis de Usuário

### Cliente

Responsável por criar e acompanhar seus chamados.

### Funcionário

Responsável pelos chamados atribuídos, podendo atualizar o status e adicionar comentários.

### Administrador

Responsável pelo gerenciamento geral dos chamados e pela atribuição de funcionários.

## Tecnologias

### Backend

* C#
* ASP.NET Core
* ASP.NET Core MVC
* Entity Framework Core
* LINQ

### Banco de Dados

* SQL Server
* Entity Framework Core Migrations

### Autenticação e Segurança

* JWT
* Cookies
* BCrypt
* Roles e autorização de usuários

### Frontend

* Razor Views
* HTML
* CSS
* Bootstrap
* JavaScript

## Estrutura do Projeto

```text
ChamadoManager/
├── Controllers/
├── Data/
├── Enums/
├── Models/
├── Repositories/
├── Services/
├── Views/
├── wwwroot/
├── Program.cs
└── appsettings.json
```

O projeto utiliza uma camada de repositórios para separar o acesso aos dados da lógica presente nos controllers.

## Estrutura dos Chamados

Cada chamado possui informações relacionadas ao cliente responsável, funcionário atribuído, status atual e histórico da solicitação.

```text
Ticket
├── Title
├── Description
├── Status
├── Client
├── AssignedEmployee
├── CreatedAt
├── ResolvedAt
├── Comments
└── History
```

## Fluxo do Sistema

```text
Cliente cria um chamado
        |
        v
Chamado é registrado
        |
        v
Funcionário é atribuído
        |
        v
Chamado entra em atendimento
        |
        v
Comentários e alterações são registrados
        |
        v
Chamado é finalizado
```

## Relacionamentos

```text
User
├── Tickets criados
├── Tickets atribuídos
└── Comments

Ticket
├── Client
├── AssignedEmployee
├── Comments
└── History
```

O Entity Framework Core é utilizado para mapear as entidades e realizar a comunicação com o SQL Server.

## Objetivo

O Chamado Manager foi desenvolvido para consolidar conhecimentos em desenvolvimento de aplicações web utilizando o ecossistema .NET.

Entre os principais conceitos aplicados estão:

* Programação orientada a objetos
* Arquitetura MVC
* Autenticação e autorização
* Controle de acesso por perfil
* Modelagem de banco de dados
* Relacionamentos entre entidades
* Entity Framework Core
* Repository Pattern
* Validação e regras de negócio
* Desenvolvimento de interfaces com Razor Views

## Como Executar

Clone o repositório:

```bash
git clone URL_DO_REPOSITORIO
```

Acesse o diretório:

```bash
cd ChamadoManager
```

Configure a string de conexão do SQL Server no arquivo `appsettings.json`.

Execute as migrations:

```bash
dotnet ef database update
```

Execute a aplicação:

```bash
dotnet run
```
