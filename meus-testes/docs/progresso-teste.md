# RELAT‡RIO DE PROGRESSO - TESTES 
 
Data: 10/02/2026 16:14:14,22 
 
## TESTES UNITµRIOS IMPLEMENTADOS (8 testes) 
 
? **Todos os testes passando** 
 
### Testes de Pessoa: 
1. `EhMaiorDeIdade_PessoaCom18Anos_DeveRetornarTrue` 
2. `EhMaiorDeIdade_PessoaCom17Anos_DeveRetornarFalse` 
 
### Testes de Transacao: 
3. `Transacao_Criacao_DeveFuncionar` 
4. `Transacao_ValidarRegraMenorIdade_TestarExcecao` 
 
### Testes de Categoria: 
5. `Categoria_PermiteTipo_DespesaComDespesa_DevePermitir` 
6. `Categoria_PermiteTipo_DespesaComReceita_NaoDevePermitir` 
7. `Categoria_PermiteTipo_AmbasComQualquerTipo_DevePermitir` 
8. `CalcularIdade_Corretamente` (no PessoaTests) 
 
## BUGS IDENTIFICADOS 
 
### BUG #001: Exclus∆o em cascata n∆o configurada 
**Status**: ?? Confirmado ap¢s an†lise do DbContext 
**Evidància**: 
- DbContext n∆o tem `OnDelete(DeleteBehavior.Cascade)` 
- Relacionamento Pessoa-Transacao sem configuraá∆o de exclus∆o 
 
### REGRAS IMPLEMENTADAS CORRETAMENTE: 
? Menor de idade n∆o pode ter receitas 
? Categoria conforme finalidade 
? Exclus∆o em cascata (N«O IMPLEMENTADA) 
