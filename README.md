# DevSpot Project 🎯

Este projeto será um sistema completo desenvolvido com **ASP.NET Core**, focado em **Identity Management**, **Autenticação de Usuários**, **Padrões de Arquitetura** e **Testes Unitários**. O sistema incluirá gerenciamento de usuários e papéis (roles), além de uma interface para postagens de trabalho.

## Estrutura do Projeto 🚀

### User and Role Management 👥
O gerenciamento de usuários será implementado usando **ASP.NET Core Identity**. A seguir estão os principais passos que serão seguidos:

- **Introdução ao Projeto**  
  O projeto será iniciado com uma visão geral dos recursos que serão implementados, focando em uma plataforma para gerenciar postagens de trabalho com um sistema robusto de identidade e autenticação.

- **Criação e Configuração do Projeto**  
  O projeto será configurado com todas as bibliotecas necessárias, como o **Entity Framework Core** e o **ASP.NET Identity**, garantindo que será possível gerenciar usuários, papéis e permissões.

- **Instalação do ASP.NET Identity**  
  O **ASP.NET Core Identity** será integrado para fornecer autenticação e gerenciamento de usuários. Isso permitirá que os usuários façam login, criem contas e gerenciem suas permissões de forma eficaz.

- **Criação do Identity DbContext**  
  Um **DbContext** será criado especificamente para gerenciar as tabelas de identidade, como usuários, roles e tokens. Isso facilitará a integração com o **Entity Framework**, permitindo uma persistência eficiente dos dados.

- **Registro do DbContext**  
  O contexto será registrado no **Service Collection** do projeto, permitindo que seja injetado em qualquer parte da aplicação.

- **Criação e Leitura da Connection String**  
  A connection string para o banco de dados será configurada no arquivo `appsettings.json`, conectando o projeto a um banco de dados SQL Server.

- **Configuração de Roles e Seeding de Usuários**  
  Serão criados scripts de seeding para garantir que papéis como **Admin** e **User** sejam criados automaticamente no banco de dados, e usuários com permissões específicas sejam atribuídos aos papéis correspondentes.

### Repository Design Pattern 🗂️
Será implementado o **Repository Design Pattern** para estruturar o acesso ao banco de dados, promovendo uma arquitetura desacoplada e mais fácil de manter.

- **Criação de Interfaces Genéricas**  
  Uma interface genérica para o repositório será criada para garantir que as operações de CRUD sejam facilmente reutilizáveis em várias partes da aplicação.

- **Criação de um Repositório de Job Postings**  
  Um repositório específico para **Postagens de Trabalho** será criado, centralizando todas as interações com a tabela de postagens.

### Unit Testing 🧪
Para garantir a qualidade do código, serão implementados **Testes Unitários** usando **xUnit**.

- **Configuração do Projeto de Testes**  
  Um projeto separado será criado para os testes unitários, garantindo que os métodos principais sejam validados automaticamente.

- **Testes de CRUD para Postagens de Trabalho**  
  Serão implementados testes para garantir que as operações de criação, leitura, atualização e exclusão (CRUD) estejam funcionando corretamente no contexto das postagens de trabalho.

### View Models e Autorização de Controladores 🔐
Para melhorar a separação de responsabilidades, **View Models** serão utilizados para transportar dados entre a camada de visualização e a de controle.

- **Autorização por Papéis nos Controladores**  
  A autorização será implementada nos controladores para restringir o acesso a determinadas páginas com base nas permissões do usuário. Por exemplo, apenas usuários com o papel **Admin** poderão acessar a página de gerenciamento de postagens de trabalho.

- **Validação e Exibição de Postagens**  
  Validações serão adicionadas para garantir que apenas postagens válidas possam ser criadas, e uma interface será construída para exibir todas as postagens disponíveis.


### O projeto ainda está em criação
