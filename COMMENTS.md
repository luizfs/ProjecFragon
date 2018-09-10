# COMMENTS

### Explicação rápida da decisão arquitetura utilizada e o porquê.
- Arquitetura
  - Trabalhei separando o projeto em 4 camadas, API, Business, Front e Data.
  - Front: Responsável por apresentar os dados para o usuário(Todas as telas da aplicação) e fazer requisições para Api.
  - Api: Responsável por receber as requisições da camada Front e envia-las para a camada Business retornando para a camada Front os resultados.
  - Business: Separei essa camada em outras duas, a Entities onde fica a nossa entidade (atributos) e a camada Business que trata toda a regra de negócio da entidade e chama a nossa camada de dados.
  - Data: Responsável por fazer toda a manipulação dos dados no banco de dados, somente essa camada consegue acessar o banco.
- Porque
  -	Optei por trabalhar com essa arquitetura visando a escalabilidade da aplicação.
 
###  Lista de bibliotecas de teceiros utilizadas.
- Quais
   - Utilizei apenas 2 bibliotecas de terceiros: Angular Translate e Angular-ui- mask.
- Para 
  - Angular Translate: Foi utilizada para fazer a tradução do front.
  - Angular-ui-mask: Foi utilizada para inserir a máscara do CPF e da data de aniversário.

### O que você melhoraria se tivesse mais tempo

- A validação do CPF e da Data de Nascimento no front.
- Inserir autenticação na API.
- A validação de  todos os dados no Back-end, cheguei a implementar boa parte no back-end mas tirei porque não iria dar tempo de implementar no Font-end, o que iria acarretar alguns problemas.
- Criaria uma paginação para os dados.
- Melhorar o front-end com.

### Quais requisitos obrigatórios não foram entregues e o porquê

- Requisitos
  - Verificar se a data de nascimento é uma data válida.
  - Verificar se o CPF é valido e no momento do cadastro/edição, tratar para que não exista dois clientes com o mesmo CPF.
- Porque
  - Não consegui implementar no prazo estipulado.

 