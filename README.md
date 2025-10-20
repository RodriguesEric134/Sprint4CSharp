📘 Cadastro de Clientes - Sprint 4 (C#)
Descrição do Projeto
O projeto consiste em uma API desenvolvida em ASP.NET Core Web API utilizando Entity Framework para o gerenciamento completo de clientes. Inclui funcionalidades CRUD, consultas LINQ e integração com APIs externas, demonstrando boas práticas de arquitetura, documentação e deploy em ambiente de nuvem.
🧩 Tecnologias Utilizadas
- ASP.NET Core 8 (Web API)
- Entity Framework Core
- Swagger (Swashbuckle)
- LINQ para consultas e filtragens
- SQL Server LocalDB
- GitHub Actions (CI/CD)
- Azure App Service (configurado para publicação)


📁 Estrutura do Projeto
O projeto segue uma arquitetura organizada por camadas:

- **Controllers/**: contém os controladores responsáveis pelos endpoints da API.
- **DTOs/**: objetos de transferência de dados para requisições e respostas.
- **Services/**: camada de regra de negócio, realizando operações com o banco e regras de validação.
- **Models/**: classes de modelo representando as entidades do banco de dados.
- **Data/**: contexto do Entity Framework e configuração do banco de dados.
- **Program.cs**: configuração principal da aplicação e pipeline HTTP.
⚙️ Funcionalidades Implementadas
- CRUD completo de clientes (Create, Read, Update, Delete)
- Consultas utilizando LINQ (filtros, ordenação e busca)
- Integração com APIs externas (exemplo: API pública de CEP)
- Documentação via Swagger
- Deploy configurado em ambiente Cloud (Azure App Service)
☁️ Publicação em Nuvem
A aplicação foi configurada para deploy no Azure App Service com integração ao GitHub Actions. Devido à limitação de créditos estudantis na conta Azure, o serviço não pôde ser mantido ativo, mas toda a configuração e workflow de publicação foram implementados e testados localmente. O repositório contém o arquivo `.github/workflows/azure-webapp.yml` com o pipeline completo.
🧠 Consultas LINQ
A API utiliza LINQ para realizar buscas e filtragens no banco de dados, por exemplo:
- Buscar clientes por nome ou e-mail
- Ordenar clientes por data de cadastro
- Filtrar clientes com base em critérios específicos (como cidade ou estado)
📊 Diagrama da Arquitetura
O diagrama da arquitetura demonstra a interação entre as camadas do sistema e o fluxo de dados:

Usuário → Controller → Service → Repository → Banco de Dados

Essa estrutura garante separação de responsabilidades, facilidade de manutenção e escalabilidade.
🧾 Documentação Swagger
A documentação da API é gerada automaticamente via Swagger (Swashbuckle). Para acessá-la, basta executar o projeto e navegar até:

`https://localhost:7215/swagger`

ou, quando hospedado na nuvem:

`https://<seu-app>.azurewebsites.net/swagger`
📈 Endpoints Principais
- **GET /api/Cliente** → lista todos os clientes
- **GET /api/Cliente/{id}** → retorna um cliente específico
- **POST /api/Cliente** → cria um novo cliente
- **PUT /api/Cliente/{id}** → atualiza um cliente existente
- **DELETE /api/Cliente/{id}** → remove um cliente


💡 Desenvolvedores
- Eric Rodrigues - RM550249
- Victoria Pizza - RM550609


📘 Observações Finais
O projeto cumpre todos os requisitos exigidos pela Sprint 4 da disciplina de C#. O código está devidamente versionado no GitHub e estruturado para legibilidade, manutenção e escalabilidade.
