### MODULO GENÉRICO DE VENDAS ###

## Especs
# .NET 8
# EntityFramework Core

Projeto executado para atender os seguintes requisitos

01. Serilog para logs
02. Divisão em camadas (API, Domain, Data)
03. Aplicar Git Flow workflow
04. Aplicar Commit semântico
05. APIs REST
06. Clean Code
07. SOLID
08. DRY
09. YAGNI
10. Object Calisthenics
11. Testes de unidade
12. XUnit
13. FluentAssertions
14. Bogus
15. NSubstitute
16. Boas práticas de escrita de código
17. Test Container





Compilar o projeto
Abrir terminar em "Vendas.API"

Rodar o comando no terminal para criação da base de dados
dotnet ef database update --startup-project ../Vendas.API

A partir da solution

dotnet ef migrations add InitialCreate --project Vendas.Data --startup-project Vendas.API

dotnet ef database update --project Vendas.Data --startup-project Vendas.API


