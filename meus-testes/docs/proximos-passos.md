# COMO CONTINUAR OS TESTES (PR‡XIMOS PASSOS) 
 
## 1. Testes de Integraá∆o (Correá∆o) 
```bash 
# Corrigir encoding dos arquivos .cs 
# Usar UTF-8 ao criar arquivos no CMD 
# Re-criar CustomWebApplicationFactory.cs manualmente no VS Code 
``` 
 
## 2. Testes Front-end (Execuá∆o) 
```bash 
# Instalar Node.js 18+ 
cd frontend-tests 
npm install 
npm run test:unit  # Testes Vitest 
npx playwright test  # Testes E2E 
``` 
 
## 3. CI/CD (GitHub Actions) 
```yaml 
# Criar .github/workflows/tests.yml 
# Configurar jobs para back-end e front-end 
# Executar automaticamente em push/pull_request 
``` 
