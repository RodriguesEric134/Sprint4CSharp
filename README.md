# 💻 Sprint 4 - C# API

[![.NET](https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208.x-blue?logo=nuget)](https://learn.microsoft.com/en-us/ef/core/)
[![Swagger](https://img.shields.io/badge/Swagger-UI-green?logo=swagger)](https://swagger.io/)
[![Status](https://img.shields.io/badge/status-concluído-brightgreen)](#)

API desenvolvida como parte da **Sprint 4 - C#** da FIAP.  
O projeto foi construído utilizando **ASP.NET Core Web API** e **Entity Framework**, implementando CRUD completo, consultas LINQ e integração com APIs externas.  
A aplicação foi configurada para deploy em ambiente Cloud (Azure App Service).

---

## 👥 Integrantes
- **Eric de Carvalho Rodrigues** - RM550249  
- **Victoria Franceschini Pizza** - RM550609  

---

## 🚀 Funcionalidades

- **CRUD completo** de clientes (Create, Read, Update, Delete).  
- **Consultas LINQ** para busca e filtragem.  
- **Integração com API externa** (ex: consulta de CEP).  
- **Documentação via Swagger**.  
- **Estrutura em camadas (Controllers, Services, DTOs, Models)**.  
- **Configuração pronta para deploy em nuvem** (Azure).  

---

## 📂 Estrutura do Projeto

```bash
Sprint4CSharp/
├── Controllers/
│   └── ClienteController.cs
├── DTOs/
│   └── ClienteDTO.cs
├── Models/
│   └── Cliente.cs
├── Services/
│   └── ClienteService.cs
├── Data/
│   └── AppDbContext.cs
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 🧩 Tecnologias Utilizadas

- **ASP.NET Core 8 (LTS)**  
- **Entity Framework Core**  
- **SQL Server LocalDB / Azure SQL**  
- **Swagger (Swashbuckle)**  
- **LINQ**  
- **GitHub Actions (CI/CD)**  
- **Azure App Service**  

---

## ☁️ Publicação em Nuvem

O projeto foi configurado para deploy no **Azure App Service**, com integração ao **GitHub Actions** para publicação contínua.  
Devido à limitação de créditos estudantis, o serviço não pôde ser mantido ativo, mas toda a configuração foi implementada e testada.  

> O repositório contém o arquivo `.github/workflows/azure-webapp.yml` com o pipeline configurado.  

---

## 🔍 Consultas LINQ

A API utiliza **LINQ** para realizar consultas como:  
- Busca de clientes por **nome** ou **e-mail**;  
- Ordenação por **data de cadastro**;  
- Filtragem por **UF** ou **cidade**.  

---

## 🧠 Endpoints Principais

| Método | Endpoint              | Descrição                         |
|---------|----------------------|-----------------------------------|
| GET     | `/api/Cliente`        | Retorna todos os clientes         |
| GET     | `/api/Cliente/{id}`   | Retorna um cliente específico     |
| POST    | `/api/Cliente`        | Cria um novo cliente              |
| PUT     | `/api/Cliente/{id}`   | Atualiza um cliente existente     |
| DELETE  | `/api/Cliente/{id}`   | Remove um cliente                 |

---

## 🧾 Documentação Swagger

A documentação é gerada automaticamente pelo Swagger.  
Após iniciar o projeto, acesse:  

```
https://localhost:7215/swagger
```
ou, quando hospedado:  
```
https://sprint4csharp.azurewebsites.net/swagger
```

---

## 🧱 Diagrama da Arquitetura

```
Usuário → Controller → Service → Repository → Banco de Dados
```

Essa estrutura garante separação de responsabilidades, clareza no código e facilidade de manutenção.

---

## 📘 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/RodriguesEric134/Sprint4CSharp.git
   ```

2. Acesse o diretório:
   ```bash
   cd Sprint4CSharp
   ```

3. Restaure os pacotes e compile:
   ```bash
   dotnet restore
   dotnet build
   ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```

5. Acesse o Swagger:
   [https://localhost:7215/swagger](https://localhost:7215/swagger)

---

## 🧩 Observações Finais

O projeto cumpre os requisitos propostos na **Sprint 4 de C#**:  
- CRUD completo com Entity Framework  
- Consultas LINQ  
- Documentação Swagger  
- Arquitetura em camadas  
- Publicação configurada em nuvem (Azure)

---

## 📄 Licença

Este projeto é de uso **acadêmico** e desenvolvido para fins didáticos.  
Sinta-se à vontade para clonar, estudar e evoluir o código.
