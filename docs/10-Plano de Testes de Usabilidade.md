# Plano de Testes de Usabilidade

Objetivo do Teste:
O teste de usabilidade tem como objetivo avaliar a facilidade de uso das principais funcionalidades da Arborize, como o cadastro, login, visualização e monitoramento de árvores, além da inserção de novas informações pelos usuários.

Tarefas a Serem Testadas:
| Caso de Teste        | CT-01 – Cadastrar perfil                                                                                                                                                                      |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-001 - A aplicação deve permitir que os usuários se cadastrem.                                                                                                                          |
| **Objetivo do Teste**  | Verificar se o usuário consegue se cadastrar na aplicação.                                                                                                                                   |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Cadastro" <br> - Preencher os campos obrigatórios (e-mail, nome, endereço, senha, confirmação de senha) <br> - Clicar em "Registrar" |
| **Critério de Êxito**  | - O cadastro foi realizado com sucesso.                                                                                                                                                     |

| Caso de Teste        | CT-02 – Login na conta                                                                                                                                                                        |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-002 - A aplicação deve permitir ao usuário fazer o login da sua conta.                                                                                                                   |
| **Objetivo do Teste**  | Verificar se o usuário consegue fazer login na aplicação.                                                                                                                                   |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Login" <br> - Preencher os campos obrigatórios (e-mail e senha) <br> - Clicar em "Entrar"                      |
| **Critério de Êxito**  | - O login foi realizado com sucesso e o usuário foi direcionado para a página inicial.                                                                                                       |

| Caso de Teste        | CT-03 – Verificação de credenciais                                                                                                                                                           |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-003 - A aplicação deve verificar credenciais, como e-mail e senhas cadastradas.                                                                                                          |
| **Objetivo do Teste**  | Verificar se as credenciais do usuário estão sendo corretamente verificadas.                                                                                                                  |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Login" <br> - Inserir credenciais inválidas (e-mail ou senha) <br> - Clicar em "Entrar"                        |
| **Critério de Êxito**  | - O sistema deve exibir uma mensagem de erro informando que as credenciais estão incorretas.                                                                                                  |

| Caso de Teste        | CT-04 – Visualizar árvores cadastradas                                                                                                                                                       |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-004 - Visualizar as árvores cadastradas por outros usuários.                                                                                                                            |
| **Objetivo do Teste**  | Verificar se o usuário consegue visualizar as árvores cadastradas.                                                                                                                           |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a seção de árvores cadastradas                                                     |
| **Critério de Êxito**  | - O usuário deve conseguir visualizar a lista de árvores cadastradas por outros usuários.                                                                                                     |

| Caso de Teste        | CT-05 – Atualizar o estado das árvores                                                                                                                                                       |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-005 - Atualizar o estado das árvores que cadastrei.                                                                                                                                     |
| **Objetivo do Teste**  | Verificar se o usuário consegue atualizar o estado das árvores cadastradas.                                                                                                                 |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a árvore que deseja atualizar <br> - Alterar o estado e salvar                     |
| **Critério de Êxito**  | - O estado da árvore deve ser atualizado com sucesso.                                                                                                                                       |

| Caso de Teste        | CT-06 – Cadastrar nova árvore                                                                                                                                                                |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-006 - A aplicação deve permitir que o usuário cadastre os dados de uma nova árvore.                                                                                                      |
| **Objetivo do Teste**  | Verificar se o usuário consegue cadastrar uma nova árvore.                                                                                                                                  |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Clicar em "Cadastrar nova árvore" <br> - Preencher os campos obrigatórios (data, localização, espécie, condições iniciais) <br> - Clicar em "Salvar" |
| **Critério de Êxito**  | - A nova árvore deve ser cadastrada com sucesso.                                                                                                                                           |

| Caso de Teste        | CT-07 – Pesquisar árvore específica                                                                                                                                                          |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-007 - O sistema deve permitir que os usuários pesquisem a respeito de uma árvore específica cadastrada no sistema.                                                                      |
| **Objetivo do Teste**  | Verificar se o usuário consegue pesquisar por uma árvore específica.                                                                                                                       |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Utilizar a funcionalidade de pesquisa para encontrar a árvore desejada                          |
| **Critério de Êxito**  | - O usuário deve conseguir visualizar os detalhes da árvore pesquisada.                                                                                                                     |

| Caso de Teste        | CT-08 – Adicionar fotos e vídeos                                                                                                                                                             |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-008 - A aplicação deve permitir que os usuários adicionem fotos e vídeos.                                                                                                                |
| **Objetivo do Teste**  | Verificar se o usuário consegue adicionar fotos e vídeos à sua árvore.                                                                                                                      |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a árvore que deseja adicionar fotos/vídeos <br> - Carregar os arquivos e salvar      |
| **Critério de Êxito**  | - As fotos e vídeos devem ser adicionados com sucesso e exibidos na árvore.                                                                                                                 |

| Caso de Teste        | CT-09 – Dar feedback                                                                                                                                                                          |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-009 - A aplicação deve permitir que os usuários deem seu feedback.                                                                                                                      |
| **Objetivo do Teste**  | Verificar se o usuário consegue enviar feedback.                                                                                                                                             |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a seção de feedback <br> - Preencher o formulário de feedback e enviar             |
| **Critério de Êxito**  | - O feedback deve ser enviado com sucesso e uma mensagem de confirmação deve ser exibida.                                                                                                    |

| Caso de Teste        | CT-10 – Atualizar dados pessoais                                                                                                                                                              |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-010 - A aplicação deve permitir que o usuário atualize seu cadastro.                                                                                                                    |
| **Objetivo do Teste**  | Verificar se o usuário consegue atualizar suas informações pessoais.                                                                                                                          |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a seção de "Meu perfil" <br> - Atualizar os campos desejados e salvar            |
| **Critério de Êxito**  | - As informações pessoais devem ser atualizadas com sucesso.                                                                                                                                 |

| Caso de Teste        | CT-11 – Acessar acervo de árvores                                                                                                                                                             |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Requisito Associado** | RF-011 - A aplicação deve permitir que o usuário acesse um acervo de árvores.                                                                                                               |
| **Objetivo do Teste**  | Verificar se o usuário consegue acessar e visualizar o acervo de árvores.                                                                                                                     |
| **Passos**            | - Acessar o navegador <br> - Informar o endereço do site <br> - Fazer login na conta <br> - Navegar até a seção de acervo de árvores                                                      |
| **Critério de Êxito**  | - O usuário deve conseguir visualizar a lista do acervo de árvores disponível.                                                                                                               |


Métricas de sucesso dos testes: 



- **Tempo de conclusão de cada tarefa**
- **Número de erros cometidos durante a navegação**
- **Satisfação do usuário com o processo** (feedback qualitativo)
- **Se a tarefa foi completada com sucesso ou não**

Critérios de Avaliação: 



- **Eficiência: O tempo que os usuários levam para realizar as tarefas.**
- **Efetividade: A quantidade de erros cometidos e a capacidade de concluir as tarefas.**
- **Satisfação: Feedback positivo em relação à facilidade de uso e experiência com a aplicação.**
