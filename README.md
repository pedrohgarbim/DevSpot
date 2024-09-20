# DevSpot Project 🎯
Este projeto é um sistema completo desenvolvido com **ASP.NET Core**, focado em **Identity Management**, **Autenticação de Usuários**, **Padrões de Arquitetura** e **Testes Unitários**. O sistema inclui gerenciamento de usuários e papéis (roles), além de uma interface para postagens de trabalho.

## Estrutura do Projeto 🚀

### User and Role Management 👥
O gerenciamento de usuários é implementado usando **ASP.NET Core Identity**. A seguir estão os principais passos que foram seguidos:

- **Introdução ao Projeto**  
  O projeto foi iniciado com uma visão geral dos recursos que serão implementados, focando em uma plataforma para gerenciar postagens de trabalho com um sistema robusto de identidade e autenticação.

- **Criação e Configuração do Projeto**  
  O projeto foi configurado com todas as bibliotecas necessárias, como o **Entity Framework Core** e o **ASP.NET Identity**, garantindo que pudéssemos gerenciar usuários, papéis e permissões.

- **Instalação do ASP.NET Identity**  
  O **ASP.NET Core Identity** foi integrado para fornecer autenticação e gerenciamento de usuários. Isso permitirá que os usuários façam login, criem contas e gerenciem suas permissões de forma eficaz.

- **Criação do Identity DbContext**  
  Um **DbContext** foi criado especificamente para gerenciar as tabelas de identidade, como usuários, roles e tokens. Isso facilita a integração com o **Entity Framework**, permitindo uma persistência eficiente dos dados.

- **Registro do DbContext**  
  O contexto foi registrado no **Service Collection** do projeto, permitindo que seja injetado em qualquer parte da aplicação.

- **Criação e Leitura da Connection String**  
  A connection string para o banco de dados foi configurada no arquivo `appsettings.json`, conectando o projeto a um banco de dados SQL Server.

- **Configuração de Roles e Seeding de Usuários**  
  Foram criados scripts de seeding para garantir que papéis como **Admin** e **User** sejam criados automaticamente no banco de dados, e usuários com permissões específicas sejam atribuídos aos papéis correspondentes.
  ### Repository Design Pattern 🗂️
Foi implementado o **Repository Design Pattern** para estruturar o acesso ao banco de dados, promovendo uma arquitetura desacoplada e mais fácil de manter.

- **Criação de Interfaces Genéricas**  
  Uma interface genérica para o repositório foi criada para garantir que as operações de CRUD sejam facilmente reutilizáveis em várias partes da aplicação.

- **Criação de um Repositório de Job Postings**  
  Um repositório específico para **Postagens de Trabalho** foi criado, centralizando todas as interações com a tabela de postagens.

### Unit Testing 🧪
