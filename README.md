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

# 🏗️ Repository Design Pattern

O **Padrão de Design de Repositório** é amplamente utilizado na arquitetura de software para separar a lógica de negócios do acesso aos dados. Isso ajuda a manter o código organizado, escalável e de fácil manutenção. A seguir, explicamos como esse padrão funciona de maneira clara e objetiva.

---

## 📋 Visão Geral

Quando um usuário realiza uma ação, como criar um novo anúncio de emprego, ele preenche um formulário e envia uma solicitação **POST** para o **Controlador** (Controller), que faz parte da arquitetura **MVC (Model-View-Controller)**. A função do controlador é:

- 📨 Receber as requisições do usuário
- 🧠 Processar a lógica de negócios
- 📡 Determinar a resposta apropriada do sistema

Tradicionalmente, o controlador estava diretamente conectado ao banco de dados, o que tornava o código mais acoplado e menos flexível. No entanto, com o **Padrão de Repositório**, essa responsabilidade é delegada a uma camada intermediária chamada **Repositório** (Repository).

---

## 🗄️ Introdução ao Padrão de Repositório

O **Repositório** é responsável por todas as operações de acesso a dados, como criar, excluir, atualizar e recuperar registros. Isso significa que o controlador não interage diretamente com o banco de dados, mas delega essas tarefas ao repositório.

Por exemplo, no caso de um sistema de anúncios de emprego, o **Repositório de Anúncios de Emprego** teria métodos como:

- Criar um novo anúncio de emprego
- Excluir um anúncio de emprego
- Recuperar todos os anúncios
- Obter um anúncio por ID
- Atualizar um anúncio existente

Essa estrutura permite que o controlador se concentre na interação com o usuário e na lógica de negócios, enquanto o repositório gerencia o acesso ao banco de dados.

---

## 🔧 Repositório Genérico

Em aplicações maiores, onde temos múltiplos modelos de dados, como **anúncios de emprego**, **faturas**, ou outros tipos de entidades, replicar o mesmo código de operações CRUD pode gerar duplicação desnecessária. 

É aqui que entra o **Repositório Genérico**. Ele define métodos comuns como `Create`, `Delete`, `Update` e `Get` para qualquer tipo de entidade, utilizando um tipo genérico `T`. 

Com isso, conseguimos aplicar as mesmas operações em diferentes modelos de dados sem duplicar código. O repositório genérico é implementado através de uma interface que é reutilizada por todos os repositórios específicos, como o de **anúncios** ou de **faturas**.

---

## 🌟 Benefícios

O uso do **Padrão de Repositório** traz várias vantagens:

- **🚀 Escalabilidade**: Facilita o crescimento da aplicação, adicionando novos modelos sem duplicar código.
- **🧩 Reutilização**: O repositório genérico permite que você reutilize operações CRUD para diferentes entidades.
- **🧼 Organização**: A separação entre lógica de negócios e acesso aos dados torna o código mais limpo e fácil de manter.
- **🧪 Testabilidade**: Camadas separadas tornam o código mais fácil de testar e manter.

---

## 📚 Resumo

- **Controlador**: Recebe as requisições do usuário e lida com a lógica de negócios, como navegação e interação com a interface do usuário.
- **Repositório**: Camada intermediária que abstrai o acesso ao banco de dados, fornecendo métodos para manipular os dados sem expor diretamente o contexto de dados ao controlador.
- **Repositório Genérico**: Permite a reutilização de código ao lidar com múltiplos modelos de dados, definindo operações CRUD comuns em uma interface genérica.

Ao aplicar o **Padrão de Design de Repositório**, conseguimos separar claramente a lógica de negócios do acesso aos dados, tornando o sistema mais fácil de manter, testar e escalar.


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


## O projeto ainda está em criação...
Toda a parte de  User and Role Management foi finalizada, agora falta entrar em Repository Design Pattern e fazer os **Testes Unitários**
