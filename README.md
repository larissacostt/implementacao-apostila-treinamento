# Implementação – Treinamento ASP.NET Core MVC

Este projeto foi desenvolvido como parte de um **treinamento prático em ASP.NET Core MVC**, utilizando como material de apoio a apostila **“ASP.NET Core MVC: Aplicações modernas em conjunto com o Entity Framework”**, de **Everton Coimbra de Araújo**, publicada pela **Casa do Código**.

A implementação acompanha os conceitos apresentados na apostila, permitindo aplicar na prática conhecimentos relacionados ao desenvolvimento de aplicações web utilizando **ASP.NET Core MVC, Entity Framework Core e SQL Server**.

## 🎯 Objetivo do treinamento

O objetivo do projeto é colocar em prática os principais conceitos apresentados na apostila, desenvolvendo uma aplicação de gerenciamento de uma **Instituição de Ensino Superior (IES)**.

Durante o desenvolvimento são trabalhados conceitos fundamentais do desenvolvimento web com ASP.NET Core MVC, desde a criação de controladores e visões até persistência de dados, relacionamentos entre entidades, autenticação e interação dinâmica com a aplicação.

## 🧩 Principais conceitos abordados

Entre os principais conceitos estudados e aplicados estão:

* Arquitetura **MVC (Model-View-Controller)**
* ASP.NET Core MVC
* Entity Framework Core
* Mapeamento objeto-relacional (ORM)
* Acesso e persistência de dados
* CRUD (inclusão, consulta, alteração e exclusão)
* Relacionamentos entre entidades
* Migrations
* Data Annotations e validações
* Separação de responsabilidades
* Data Access Layer (DAL)
* Areas
* Autenticação e autorização
* ASP.NET Core Identity
* Sessions
* Bootstrap e layouts
* JavaScript e jQuery
* AJAX
* Listas e seleções dependentes
* Tratamento de erros
* Upload e download de arquivos

## 🏫 Entidades trabalhadas

O projeto utiliza como contexto uma **Instituição de Ensino Superior**, trabalhando com entidades relacionadas à administração acadêmica.

Entre as principais entidades implementadas estão:

* **Instituição**
* **Departamento**
* **Curso**
* **Disciplina**
* **Professor**
* **Acadêmico**
* **CursoProfessor**
* **CursoDisciplina**
* **Usuário da Aplicação**

Essas entidades permitem trabalhar, na prática, com diferentes tipos de relacionamentos e operações de persistência de dados utilizando o Entity Framework Core.

## 🛠️ Tecnologias utilizadas

* C#
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server / LocalDB
* ASP.NET Core Identity
* Bootstrap
* HTML
* CSS
* JavaScript
* jQuery
* AJAX
* Visual Studio Community

## 🗃️ Entity Framework Core

O Entity Framework Core é utilizado para o acesso e a persistência dos dados da aplicação.

Durante o desenvolvimento são trabalhados conceitos como:

- `DbContext`
- `DbSet`
- LINQ
- Relacionamentos entre entidades
- Migrations
- Persistência de dados
- Consultas ao banco de dados

## 📁 Estrutura do projeto

O projeto está organizado seguindo a arquitetura **ASP.NET Core MVC**, utilizando **Areas** para separar diferentes funcionalidades da aplicação.

### Principais diretórios

- `Areas/Cadastros` – funcionalidades relacionadas aos cadastros, como:
  - `Curso`
  - `Departamento`
  - `Disciplina`
  - `Instituicao`

- `Areas/Discente` – funcionalidades relacionadas aos acadêmicos.

- `Areas/Docente` – funcionalidades relacionadas aos professores.

- `Controllers` – controladores responsáveis pelo processamento das requisições da aplicação.

- `Data` – contexto e configurações relacionadas ao acesso aos dados.

- `Migrations` – migrations utilizadas pelo Entity Framework Core para controlar alterações na estrutura do banco de dados.

- `Models` – entidades e modelos utilizados pela aplicação.

- `Views` – páginas da aplicação, organizadas em:
  - `Home`
  - `Infra`
  - `Shared`

- `Views/Shared` – arquivos compartilhados entre as diferentes páginas, incluindo layouts, validações e páginas de erro.

- `Modelo` – projeto que contém a estrutura de modelos utilizada pela aplicação, organizado em áreas como:
  - `Cadastros`
  - `Discente`
  - `Docente`

### Principais arquivos

- `Program.cs` – ponto de configuração e inicialização da aplicação ASP.NET Core.
- `appsettings.json` – arquivo de configurações da aplicação, incluindo a Connection String do banco de dados.
- `libman.json` – arquivo utilizado para gerenciamento das bibliotecas do lado do cliente.
- `.gitignore` – define arquivos e diretórios que não devem ser versionados pelo Git.
- `.editorconfig` – configurações de padronização para edição dos arquivos do projeto.

## 📋 Requisitos

Para executar o projeto, é necessário ter instalado:

- .NET SDK compatível com a versão do projeto
- Visual Studio Community
- SQL Server LocalDB ou SQL Server
- Git

Também é necessário possuir uma instância do SQL Server disponível para a criação do banco de dados.

## 🗄️ Banco de dados

O projeto utiliza o Entity Framework Core para realizar o acesso e o gerenciamento dos dados.

- A conexão com o banco de dados é configurada no arquivo:

`appsettings.json`

- A aplicação utiliza uma Connection String para definir o servidor e o banco de dados utilizado. No ambiente de desenvolvimento, pode ser utilizado o SQL Server LocalDB.

Exemplo: Criação do banco de dados

```json
"ConnectionStrings": {
    "IESConnection": "Server=(localdb)\\MSSQLLocalDB;Database=IESCasaDoCodigo;Trusted_Connection=True"
}
```

- Após configurar a Connection String, o banco pode ser criado utilizando os recursos do Entity Framework Core e as configurações existentes no projeto.
- A Connection String deve ser ajustada de acordo com a configuração do SQL Server ou LocalDB disponível no ambiente de execução.

## ▶️ Como executar a aplicação

**1. Clonar o repositório:**

Clone o projeto para sua máquina:

```bash
git clone https://github.com/larissacostt/implementacao-apostila-treinamento.git
```
**2. Abrir o projeto:**

Abra a solução do projeto no Visual Studio Community.

**3. Configurar o banco de dados:**

Verifique a Connection String no arquivo:

`appsettings.json`

Configure o servidor e o nome do banco de dados conforme o ambiente local.

**4. Criar/atualizar o banco:**

No Package Manager Console do Visual Studio, execute:

`Update-Database`

Caso o projeto utilize a criação do banco por meio do inicializador configurado na aplicação, a estrutura e os dados iniciais também poderão ser preparados durante a execução.

**5. Executar a aplicação:**

No Visual Studio:

- Selecione o projeto como projeto de inicialização.
- Execute utilizando IIS Express ou o perfil da aplicação configurado no projeto.
- Aguarde a abertura do navegador.
- A aplicação será iniciada utilizando a URL configurada no ambiente de desenvolvimento.

## 📖 Finalidade

Este repositório tem como finalidade registrar a **implementação prática dos conhecimentos adquiridos durante o treinamento**, utilizando a apostila como material de apoio para compreender e aplicar os conceitos de desenvolvimento de aplicações web com **ASP.NET Core MVC e Entity Framework Core**.

O projeto representa uma aplicação prática dos conteúdos estudados, permitindo acompanhar a evolução do aprendizado ao longo do desenvolvimento.
