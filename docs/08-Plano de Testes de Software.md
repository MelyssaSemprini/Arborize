# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

 
| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - A aplicação deve apresentar, ao clicar no botão "cadastro" na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Cadastro" <br> - Preencher os campos obrigatórios (e-mail, nome, endereço, senha, confirmação de senha) - Clicar em "Registrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-02	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar no botão "Login" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Clicar em "Entrar" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-04 – Cadastro de Árvores |
|Requisito Associado | RF-06	- A aplicação deve permitir o cadastro de árvores. |
| Objetivo do Teste 	| Verificar se o usuário consegue cadastrar uma árvore com sucesso. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar no botão "Entrar" <br> - Clicar no botão "Cadastrar Árvore" <br> - Preencher o campo "Nome da Árvore" <br> -  Preencher o campo "Espécie" | <br> - Preencher o campo "Localização" <br> - Clicar em "Salvar" |
|Critério de Êxito | - O cadastro da árvore foi realizado com sucesso. | 
|  	|  	|
| Caso de Teste 	| CT-05 – Visualizar Árvores Cadastradas por Outros Usuários |
|Requisito Associado | RF-04	- A aplicação deve permitir visualizar árvores cadastradas por outros usuários. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar as árvores cadastradas por outros usuários. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar no botão "Visualizar Árvores" <br> -  Aguardar o carregamento da lista de árvores cadastradas por outros usuários <br> - Verificar se as árvores estão sendo exibidas corretamente na página |
|Critério de Êxito | - As árvores cadastradas por outros usuários foram exibidas com sucesso. | 
|  	|  	|
| Caso de Teste 	| CT-06 Atualizar o Estado das Árvores Cadastradas – |
|Requisito Associado | RF-05	- A aplicação deve permitir ao usuário atualizar o estado das árvores que ele cadastrou. |
| Objetivo do Teste 	| Verificar se o usuário consegue atualizar o estado das árvores que cadastrou. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar no botão "Minhas Árvores" <br> - Selecionar a árvore que deseja atualizar <br> -  Clicar em "Editar Estado" <br> -  Modificar o campo "Estado da Árvore" | <br> - Clicar em "Salvar Alterações"
|Critério de Êxito | - O estado da árvore foi atualizado com sucesso. | 
|  	|  	|
| Caso de Teste 	| CT-07 – Os usuários podem adicionar fotos e vídeos.	|
|Requisito Associado | RF-008	A aplicação deve permitir que os usuários adicionem fotos e vídeos. |
| Objetivo do Teste 	| Verificar se o usuário consegue adicionar fotos e vídeos corretamente. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site <br> - Realizar login <br> - Navegar até a página de adicionar mídia <br> - Clicar em "Adicionar Foto" ou "Adicionar Vídeo" <br> - Selecionar um arquivo de foto ou vídeo <br> - Clicar em "Salvar" |
|Critério de Êxito | - A foto ou vídeo é carregado e exibido corretamente na página do usuário. |
|  	|  	|
| Caso de Teste  | CT-08 – Os usuários podem dar feedback.             |
| Requisito Associado| RF-009 – A aplicação deve permitir que os usuários deem seu feedback.|
| Objetivo do Teste  | Verificar se o usuário consegue submeter um feedback com sucesso. |
| Passos  | - Acessar o navegador <br> - Informar o endereço do site <br> - Realizar login <br> - Navegar até a página de feedback <br> - Preencher o campo de texto com o feedback <br> - Clicar em "Enviar" |
| Critério de Êxito | - O feedback é enviado e uma confirmação de sucesso é exibida. |
|  	|  	|
| Caso de Teste  | CT-09 – O usuário pode atualizar seu cadastro.      |
| Requisito Associado  | RF-010 – A aplicação deve permitir que o usuário atualize seu cadastro. |
| Objetivo do Teste  | Verificar se o usuário consegue atualizar suas informações de cadastro com sucesso. |
| Passos | - Acessar o navegador <br> - Informar o endereço do site <br> - Realizar login <br> - Navegar até a página de perfil <br> - Atualizar os campos desejados (nome, e-mail, etc.) <br> - Clicar em "Salvar" |
| Critério de Êxito | - As informações do usuário são atualizadas com sucesso e exibidas corretamente. |
