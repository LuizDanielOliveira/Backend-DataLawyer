Terá o mesmo README entre os dois Diretórios pois decidi dividir em dois por costume e organização e facil manutenção :)

Gerenciador de Tarefas
Este projeto é dividido em dois diretórios principais:

## Backend: TaskManager.Api

Feito em .NET Core 6+, usando Entity Framework Core para persistência em SQLite.
Oferece uma API REST para criação, listagem, atualização e exclusão de tarefas.

## Frontend: taskmanager-frontend

Feito em Vue 3 + TypeScript, empacotado com Vite.
Exibe a lista de tarefas, formulário para criar/editar, exclusão e indicador de status.
Faz requisições ao backend via Axios.

## Pré-Requisitos
.NET 6 ou superior, utilizei o 9 
Node.js 14 ou superior
NPM (ou Yarn)

## Instalação e Execução do Backend (.NET)
Entre na pasta do backend e no terminal coloque o comando: cd TaskManager.Api Restaure as dependências com : dotnet restore Crie ou atualize o banco de dados, porem já vai com alguns dados para análise: dotnet ef database update , Execute o projeto com :dotnet run
Observe no console, ele deve mostrar algo como: http://localhost:5170 caso mude a porta, será necessário mudar a porta no FrontEnd no arquivo api.TS. apenas trocar a porta caso esteja diferente.

Instalação e Execução do Frontend (Vue + TS)
Entre na pasta do frontend: cd taskmanager-frontend ,  Instale as dependências com:  npm install , Ajuste a URL do backend no arquivo src/services/api.ts assim que o backend estiver rodando para obter a informação da porta, Rode o servidor de desenvolvimento com : npm run dev Irá mostrar a URL criada apenas clique direto no Terminal segurando CRTRL ou copie e cole no navegador

## Endpoints da API
GET /api/tasks — Retorna todas as tarefas
GET /api/tasks/{id} — Retorna uma tarefa específica
POST /api/tasks — Cria uma nova tarefa
PUT /api/tasks/{id} — Atualiza os campos de uma tarefa existente
PUT /api/tasks/{id}/renew — (Opcional) Renova o timer de uma tarefa
DELETE /api/tasks/{id} — Exclui a tarefa 

## Como Funciona: 
Funcionalidades do Frontend
Lista de Tarefas (TaskList.vue):

Exibe título, descrição, status, data de criação, e tempo (countdown ou horas passadas).
Botões Editar, Excluir, Renovar.
Se status for “Concluída”, a linha fica verde e exibe quanto tempo levou ou apenas Zera o timer
Formulário (TaskForm.vue):

Cria nova tarefa (POST)
Edita tarefa existente (PUT)
Campos obrigatórios: Título (e o que mais você desejar).
Navbar (Navbar.vue):

Exibe logo e o título “Gerenciador de Tarefas Data Lawyer” no topo com a Logo.
