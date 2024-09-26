@echo off
set MIGRATIONS_PATH=.\Vendas.Data\Migrations
set PROJECT_PATH=Vendas.Data
set STARTUP_PROJECT_PATH=Vendas.API

echo Verificando se a pasta Migrations existe...
if exist %MIGRATIONS_PATH% (
    echo Pasta Migrations encontrada.
) else (
    echo A pasta Migrations não foi encontrada.
)

for /f %%a in ('wmic os get localdatetime ^| find "."') do set dt=%%a
set NEW_MIGRATION_NAME=Migration_%dt:~0,8%_%dt:~8,6%
echo Criando nova migration com o nome %NEW_MIGRATION_NAME%...

dotnet ef migrations add %NEW_MIGRATION_NAME% --project %PROJECT_PATH% --startup-project %STARTUP_PROJECT_PATH%
echo Nova migration criada com sucesso.

echo Verificando se o banco de dados existe...
dotnet ef database update --project %PROJECT_PATH% --startup-project %STARTUP_PROJECT_PATH% --dry-run > nul 2>&1
if %errorlevel%==0 (
    echo Banco de dados existe. Dropando o banco...
    dotnet ef database drop --project %PROJECT_PATH% --startup-project %STARTUP_PROJECT_PATH% -f
    echo Banco de dados dropado com sucesso.
) else (
    echo O banco de dados ainda não existe. Criando o banco de dados pela primeira vez...
)

echo Atualizando o banco de dados com a nova migration...
dotnet ef database update --project %PROJECT_PATH% --startup-project %STARTUP_PROJECT_PATH%
echo Banco de dados atualizado com sucesso.

echo Processo completo!
