# CRUD de Itens - Projeto ASP.NET MVC

Bem-vindo ao projeto de teste para a oportunidade de Desenvolvedor Júnior na empresa Gobi. Este projeto demonstra um sistema básico de CRUD (Criar, Ler, Atualizar e Excluir) para gerenciamento de itens, utilizando ASP.NET MVC.

## Funcionalidades

- **Criar**: Adicionar novos itens ao sistema.
- **Editar**: Atualizar detalhes de itens existentes.
- **Excluir**: Remover itens do sistema.
- **Ordenar**: Organizar itens por status, com opções para visualizar itens não completados e completados.
- **Estilização**: Interface estilizada para uma melhor experiência do usuário.

## Tecnologias Utilizadas

- **ASP.NET MVC**: Framework para criação de aplicações web.
- **C#**: Linguagem de programação para desenvolvimento backend.
- **SQLite**: Banco de dados leve utilizado para armazenamento de dados.

## Instruções de Uso

### Configuração do Ambiente

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/pedro-pacheco16/Teste-Gobi.git
    ```

2. **Abra a solução no Visual Studio**:
   Navegue até a pasta do projeto e abra o arquivo `.sln` no Visual Studio.

3. **Instale as dependências**:
    Execute o comando `dotnet restore` no terminal para instalar todas as dependências necessárias.

4. **Configure o banco de dados**:
   O projeto usa SQLite. Certifique-se de que o arquivo do banco de dados está configurado corretamente em `appsettings.json`.

### Executando o Projeto

1. **Inicie o servidor**:
   No Visual Studio, pressione `F5` para iniciar o servidor e abrir a aplicação no navegador padrão.

## Funcionalidades do CRUD

- **Criar Item**:
  Preencha o formulário com os detalhes do item e clique em "Salvar".

- **Editar Item**:
  Clique no botão "Editar" ao lado do item desejado e faça as alterações necessárias. Clique em "Salvar" para atualizar.

- **Excluir Item**:
  Clique no botão "Excluir" ao lado do item desejado e confirme a exclusão.

## Estilização

O projeto inclui estilizações básicas utilizando CSS. As alterações podem ser feitas no arquivo `index.cshtml` para ajustar a aparência conforme necessário.
