@echo off
setlocal

set PROJECT_PATH=Vendas.Data
set STARTUP_PROJECT_PATH=Vendas.API

echo Atualizando o banco de dados com a migration CreateTablesMigrations...

dotnet ef database update --project %PROJECT_PATH% --startup-project %STARTUP_PROJECT_PATH%
if %errorlevel% neq 0 (
    echo Ocorreu um erro ao atualizar o banco de dados.
    exit /b
)

echo Banco de dados criado com sucesso com a migration CreateTablesMigrations.
endlocal
