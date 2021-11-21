# Desafio Sonda  
Código fonte de desafio do processo seletivo da Sonda

# Formulário de Cadastro de Usuário
 
Desenvolver uma aplicação utilizando ASP.NET Core MVC, esta aplicação deverá ter três páginas.

## Página 1
- Formulário de Cadastro de Usuário *
 
## Página 2
- Lista de usuários cadastrados
_Exibir apenas os nomes completos em lista e ao clicar em um nome ir para página 3._

## Página 3
- Detalhes do usuário selecionado
- Exibir todos os dados do usuário
---------------------------------------------------------------------------
 
## DESCRIÇÃO DO FORMULÁRIO
O formulário irá solicitar os seguintes campos do usuário.
 
**Dados de usuário**  
Nome Completo [STRING]  
Data de Nascimento [DATETIME]  
CPF [STRING]  
Email [STRING]  
 
**Dados de endereço**  
CEP [STRING]  
Logradouro [STRING]  
Complemento [STRING]  
Bairro [STRING]  
Cidade [STRING]  
Estado [STRING]

**Observações**

Adicionar uma validação de campos em javascript ou jquery no formulário de cadastro de usuário, todos os campos são obrigatórios.
 
Ao preencher o CEP as demais informações de endereço deverão ser preenchidas automaticamente.
https://viacep.com.br/
 
Ao salvar o formulário, salvar as informações em banco. UTILIZAR ENTITY FRAMEWORK
Utilizar duas tabelas, uma tabela Usuários para salvar os dados de um usuário e uma tabela Endereços para salvar os dados de endereço.
A associação neste caso é de 1:1.
 
Hospedar o código em um repositório público no GitHub e enviar o link.

## Aplicação

Para o uso e teste da aplicação favor utilizar o comando **git clone https://github.com/lekuranaga/HiringSonda.git**

O projeto foi dividido em camadas, sendo utilizado a onion architecture, além de utilizar entity framework core juntamente com migrations.
