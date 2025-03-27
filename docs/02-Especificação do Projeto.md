<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto.

## Personas

Personas são representações semi-ficcionais dos usuários ideais de um produto ou serviço, baseadas em dados reais e pesquisas de mercado. Elas ajudam a criar uma visão clara e detalhada de quem são os usuários, quais são suas necessidades, comportamentos e desafios. Pensando nisso, a seguir mostramos as personas que foram criadas por nós para entender melhor os diversos perfis de usuários e atender de forma mais precisa às suas necessidades:

![Imagem-persona 1](/docs/imgArborize/persona1.png)

![Imagem-persona 2](/docs/imgArborize/persona2.png)

![Imagem-persona 3](/docs/imgArborize/persona3.png)

![Imagem-persona 4](/docs/imgArborize/persona4.png)

![Imagem-persona 5](/docs/imgArborize/persona5.png)

## Histórias de Usuários

Com base na análise das personas identificadas, a seguir serão apresentadas as histórias de usuários:

|Num|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--|--------------------|------------------------------------|----------------------------------------|
|1|Usuário | Realizar meu cadastro na plataforma          | Para poder monitorar o plantio e o desenvolvimento das árvores que administro.  |
|2|Usuário | Realizar meu login na plataforma  | Para acessar minha conta, visualizar as árvores que planto e interagir com o feed.  |
|3|Usuário (Plantador)  | Visualizar minhas árvores e  as informações sobre elas | Para ter um registro das espécies plantadas e suas características.  |
|4|Gerente de Sustentabilidade  | Acessar estatísticas sobre plantio | Para entender as tendências de plantio e medir o sucesso das iniciativas sustentáveis.   |
|5|Usuário (Plantador)  | Definir e acompanhar metas de plantio| Para me motivar a plantar mais árvores e contribuir para a preservação do meio ambiente.  |
|6|Usuário (Plantador)  | Visualizar as árvores cadastradas por outros usuários | Para conhecer e me aprofundar sobre espécies de árvores e os lugares em que são nativas.   |
|7|Agricultor (Usuário)  | Adicionar fotos em meu feed (fotos das minhas arvores)  |Compartilhar e acompanhar o crescimento e desenvolvimento dela.  |
|8|Ativista Ambiental (Usuário) | Dar meu feedback sobre a plataforma | Para ajudar a melhorar a experiência dos usuários e a qualidade das informações disponíveis.  |
|9|Ativista Ambiental (Usuário)| Atualizar os meus dados |Manter minhas informações pessoais e de contato atualizadas.  |
|10|Ativista Ambiental (Usuário)| Receber pontos por tasks disponíveis no site e poder troca-los por recompensas  |Sentir que meu esforço está sendo recompensado.  |



## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir que os usuários se cadastrem. | ALTO | 
|RF-002| A aplicação deve permitir ao usuário fazer o login da sua conta. | ALTO |
|RF-003| A aplicação deve verificar credenciais, como e-mail e senhas cadastradas. | ALTO|
|RF-004| Visualizar as árvores cadastradas por outros usuários. | ALTO |
|RF-005| A aplicação deve permitir que o usuário visualize suas próprias árvores e informações sobre elas. | ALTO |
|RF-006| A aplicação deve permitir que o usuário seja capaz de cadastrar os dados de uma nova árvore. | ALTO |
|RF-007| A aplicação deve permitir que os usuários adicionem fotos de suas árvores. | ALTO |
|RF-008| A aplicação deve permitir que os usuários adicionem fotos em suas postagens no feed. | ALTO |
|RF-009| A aplicação deve permitir que os usuários forneçam feedback sobre a plataforma. | BAIXO |
|RF-010| A aplicação deve permitir que o usuário atualize seu cadastro. | ALTO |
|RF-011| A aplicação deve recompensar o usuário por completar tarefas específicas.  | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve obrigar a criação de uma senha forte com caracteres.  | ALTA | 
|RNF-002| O sistema deve ser compatível com os principais navegadores Chrome, Firefox, Safari, Opera e Edge.    | ALTA | 
|RNF-003| O sistema deve ter uma disponibilidade mínima de 99,9% durante o ano. | MÉDIA | 
|RNF-004| A aplicação deve ser responsiva para que os elementos se adaptem a diferentes resoluções de desktops. | ALTA | 




## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. 

![Diagrama-Imagem](/docs/imgArborize/DiagramUse_arborize.png)
