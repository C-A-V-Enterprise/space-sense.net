# SatGuard - API de Monitoramento Espacial (.NET) 🛰️🌍

Projeto desenvolvido para a **Global Solution 2026** da FIAP, focado no tema **Economia Espacial**. 

Esta é a ramificação do projeto construída em **.NET**, servindo como uma **API RESTful** para gerenciar o monitoramento espacial, prevenindo a poluição e protegendo ativos críticos no espaço.

## 🚀 Viabilidade, Inovação e Tecnologias

A inovação deste projeto baseia-se na proteção do ecossistema espacial (Economia Espacial). A solução utiliza:
- **.NET 9 (C#)** e **ASP.NET Core Web API**
- **Entity Framework Core** (ORM)
- Persistência com Banco de Dados Relacional (**SQLite** configurado nativamente)
- **Migrations** ativadas para controle de versão do banco de dados

## 🏗️ Diagramas e Arquitetura Avançada (Boas Práticas)

O projeto atende a estritas boas práticas de programação e arquitetura exigidas no mercado:
- **Padrão DTO (Data Transfer Objects):** A API não expõe diretamente os modelos do banco de dados. Todas as requisições passam por classes `[Model]RequestDTO` e `[Model]ResponseDTO` para garantir segurança e isolamento.
- **Validações Rigorosas:** Os DTOs implementam validações complexas com *Data Annotations* (ex: `[Required]`, `[StringLength]`, `[Range]`) para rejeitar dados inválidos automaticamente (Erro 400).
- **Tratamento de JSON Cycles:** Configuração global com `ReferenceHandler.IgnoreCycles` para evitar erros 500 ao serializar relacionamentos bidirecionais complexos.

*Diagrama Entidade-Relacionamento:*
As 7 entidades (Empresa, Orbita, Satelite, DetritoEspacial, Plataforma, Alerta e Usuario) foram mapeadas perfeitamente.
- **Relacionamentos (1:N e N:N):** Mapeados e blindados com os DTOs.

## ⚙️ Desenvolvimento e Como Executar

O desenvolvimento foi focado na criação de 7 Controladores CRUD baseados em REST que conversam exclusivamente via DTOs.

Para rodar o projeto localmente e acessar a documentação interativa:
1. Clone o repositório:
   ```bash
   git clone https://github.com/C-A-V-Enterprise/space-sense.net.git
   ```
2. Entre na pasta da API:
   ```bash
   cd space-sense.net/SpaceSense.Api
   ```
3. A base SQLite e a Migration inicial (`InitialCreate`) já estão integradas no repositório. Basta iniciar a aplicação:
   ```bash
   dotnet run
   ```

## 🧪 Instruções de Acesso e Interface Gráfica (Testes)

Para facilitar os testes sem a necessidade do Postman, a API conta com a interface visual do **Swagger UI** (Swashbuckle) integrada e configurada para redirecionamento automático!

1. Assim que o `dotnet run` iniciar, acesse o link no seu navegador (geralmente `http://localhost:5222`).
2. Você será automaticamente redirecionado para `http://localhost:5222/swagger`.
3. Use a interface gráfica do Swagger para testar todos os GET, POST, etc. 

*Experimente tentar enviar um POST de Satélite sem preencher os campos para ver a validação de DTO em ação (Erro 400 Bad Request)!*

## 👥 Integrantes

- **Gabriel Garcia** - RM: [SEU_RM_AQUI] - [GitHub](https://github.com/gabriel-g-dev)
- [NOME DO INTEGRANTE 2] - RM: [RM AQUI]
- [NOME DO INTEGRANTE 3] - RM: [RM AQUI]
