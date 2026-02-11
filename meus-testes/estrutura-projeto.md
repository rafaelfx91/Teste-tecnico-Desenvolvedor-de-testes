# ESTRUTURA DO PROJETO ORIGINAL 
 
Data da an lise: 10/02/2026  9:50:55,52 
 
## ESTRUTURA RAIZ 
.editorconfig
api
data
Directory.Build.props
docker-compose.yml
README.md
sonar-project.properties
web
 
## API (.NET Back-end) 
``` 
Dockerfile
MinhasFinancas.API
MinhasFinancas.Application
MinhasFinancas.Domain
MinhasFinancas.Infrastructure
MinhasFinancas.slnx
nuget.config
``` 
 
## WEB (React Front-end) 
``` 
.gitignore
bun.lock
components.json
Dockerfile
eslint.config.js
index.html
package.json
postcss.config.js
public
README.md
src
tailwind.config.js
tsconfig.app.json
tsconfig.json
tsconfig.node.json
vite.config.ts
``` 
 
## DATA (Banco de Dados) 
``` 
minhasfinancas.db
``` 
 
## PROJETOS .NET DENTRO DE API 

 
### MinhasFinancas  
appsettings.Development.json
appsettings.json
Controllers
Extensions
Middlewares
MinhasFinancas.API.csproj
MinhasFinancas.API.http
minhasfinancas.db
Program.cs
Properties
 
### MinhasFinancas  
DTOs
Mapping
MinhasFinancas.Application.csproj
Services
Specifications
 
### MinhasFinancas  
DTOs
Entities
Interfaces
MinhasFinancas.Domain.csproj
ValueObjects
 
### MinhasFinancas  
Data
Extensions
Interfaces
MinhasFinancas.Infrastructure.csproj
Queries
Repositories
SeedData.cs
UnitOfWork.cs
 
