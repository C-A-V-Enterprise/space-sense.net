# SatGuard - API de Monitoramento Espacial (.NET) 🛰️🌍

Projeto desenvolvido para a **Global Solution 2026** da FIAP, focado no tema **Economia Espacial**. 

Esta é a ramificação do projeto construída em **.NET**, servindo como uma **API RESTful** para gerenciar o monitoramento espacial, prevenindo a poluição e protegendo ativos críticos no espaço.

## 🚀 Viabilidade, Inovação e Tecnologias

A inovação deste projeto baseia-se na proteção do ecossistema espacial (Economia Espacial). A solução utiliza:
- **.NET 9 (C#)** e **ASP.NET Core Web API**
- **Entity Framework Core** (ORM)
- Persistência com Banco de Dados Relacional (**SQLite** configurado nativamente, pronto para Oracle)
- **Migrations** ativadas para controle de versão do banco de dados

## 🏗️ Diagramas e Arquitetura

O projeto atende a boas práticas de programação e arquitetura, mapeando os requisitos de banco de dados diretamente nos Models utilizando Data Annotations.

*Diagrama Entidade-Relacionamento:*
As 7 entidades (Empresa, Orbita, Satelite, DetritoEspacial, Plataforma, Alerta e Usuario) foram espelhadas no Entity Framework.
- **Relacionamentos (1:N e N:N):** Mapeados corretamente no `DbContext` (Ex: Um Satélite pertence a uma Empresa, etc).

## ⚙️ Desenvolvimento e Como Executar

O desenvolvimento foi focado na criação de 7 Controladores CRUD baseados em REST.

Para rodar o projeto e aplicar a persistência:
1. Clone o repositório:
   ```bash
   git clone https://github.com/C-A-V-Enterprise/space-sense.net.git
   ```
2. Entre na pasta:
   ```bash
   cd space-sense.net/SpaceSense.Api
   ```
3. (Opcional) Crie o banco de dados rodando as migrations:
   ```bash
   dotnet ef database update
   ```
4. Rode a API:
   ```bash
   dotnet run
   ```

## 🧪 Instruções de Acesso e Exemplos de Testes

A API subirá localmente (geralmente em `http://localhost:5222`).
Para testar, você pode utilizar o **Swagger** (adicionando `/openapi/v1.json` na URL) ou ferramentas como o Postman/Insomnia.

**Exemplo de Teste - Cadastrar Empresa (POST `/api/empresas`):**
```json
{
  "empresaNome": "SpaceX",
  "empresaPais": "EUA"
}
```

**Exemplo de Teste - Consultar Empresas (GET `/api/empresas`):**
```bash
curl -X GET "http://localhost:5222/api/empresas"
```

## 👥 Integrantes

- **Gabriel Garcia** - RM: [SEU_RM_AQUI] - [GitHub](https://github.com/gabriel-g-dev)
- [NOME DO INTEGRANTE 2] - RM: [RM AQUI]
- [NOME DO INTEGRANTE 3] - RM: [RM AQUI]
