
# Trabalho 1 – Laboratório de Engenharia de Software - Domain-Driven Design (DDD)

Grupo: 
- Marcelle Ranyelle da Costa Melo (20203018679)
- Matheus Ribeiro Ferraz (20213001530)
- Pablo Vasconcelos da Cruz (20203018801)
- Renan Unsonst Cruz (20203018740)

### 1.1 Introdução

    Domain-Driven Design é um conjunto de princípios para projeto de software

Esses princípios foram definidos e elaborados por Eric Evans em 2003, com o objetivo permitir o desenvolvimento de sistemas no qual o design está fortemente relacionado em conceitos presentes no domínio de negócio. É importante destacar que o design abordado pelo DDD não refere-se ao visual ou algo relacionado ao layout da aplicação, e sim ao projeto.

O **domínio** de um sistema diz a respeito à área e ao problema de negócio que ele pretende resolver. Nesse sentido, a modelagem de software em DDD deve refletir as competências da organização e a complexidade do negócio. Para Eric Evans, entender o negócio é o único meio de implementar o DDD em um projeto. Nessa implementação, existem basicamente dois papéis: **time de desenvolvimento** e **especialistas em domínio**. O time de desenvolvimento é o responsável pela implementação do projeto, enquanto os especialistas em domínio possuem como função o fornecimento de informações sobre o negócio.

![](https://i.zst.com.br/thumbs/12/2f/32/1458255726.jpg)

Domain-Driven Design oferece ferramentas de modelagem estratégica e tática para entregar um software de alta qualidade, com o intuito de acelerar o desenvolvimento de aplicações que lidam com processos de negócios complexos, sendo possível de ser utilizada independente da linguagem que é utilizada no projeto. 



### 1.2 Linguagem Ubíqua

Para que especialistas em domínio e time de desenvolvimento trabalhem de maneira eficiente em conjunto, é necesário que ambas as partes falem de forma a ser compreendidada por ambas as partes. Esse conceito apresentado é denominado **Linguagem Ubíqua.**

![](https://engsoftmoderna.info/artigos/figs/linguagem-onipresente.svg)

Os termos da Linguagem Ubíqua são utilizados para permitir uma comunicação eficiente entre desenvolvedores e especialistas no domínio, bem como para dar nomes a elementos do código do sistema, como classes, métodos, atributos, pacotes, módulos, tabelas de bancos de dados, rotas de APIs, entre outros.

### 1.3 Contextos Delimitados

Contextos Delimitados é um outro fundamento do DDD, está relacionado ao limite conceitual, uma vez que com o tempo, sistemas de software ficam mais complexos e abrangentes, pois todo o domínio está sendo colocado no mesmo modelo. Desse modo, Contextos Delimitados busca solucionar tal cenário, dado que esse fundamento busca quebrar tais domínios complexos em domínios menores, baseados, principalmente, nas intenções de negócio.

Cada Contexto Delimitado poderá ter:
- Linguagem Ubíqua
- Abordagem de arquitetura
- Armazenamenamento de dados
- Equipe de desenvolvimento

### 1.4 Objetos de domínio

A abordagem DDD foi desenvolvida baseando-se em sistemas orientados a objetos. Sob essa perspectiva, para criar o design desses sistemas, DDD destaca alguns tipos essenciais de elementos:

1. **Entidades:** São objetos que possuem identidades distintas, como, por exemplo, um usuário em um sistema, identificado por um número único de matrícula.

2. **Objetos de Valor:** São objetos caracterizados apenas pelo seu estado, não possuindo identidade única. Um exemplo seria o endereço de um usuário, que é definido pelos valores de seus atributos.

3. **Serviços:** Representam objetos dedicados a realizar operações de destaque no domínio que não se encaixam estritamente como entidades ou objetos de valor. Geralmente, eles não possuem estado e são implementados como singletons.

4. **Agregados:** Referem-se a coleções de entidades e objetos de valor que se unem para formar uma unidade coesa. Esses agregados possuem uma raiz, que é uma entidade, e são acessados externamente através dessa raiz.

5. **Repositórios:** São responsáveis por recuperar outros objetos de domínio a partir de um banco de dados. Eles oferecem uma abstração que facilita o acesso aos dados no banco, permitindo que os desenvolvedores se concentrem nas regras do domínio, em vez de se preocuparem com os detalhes de armazenamento de dados.
```csharp
public Cliente ObterPorId(Guid id)
{
    var cliente = RepoFake.Clientes.Where(x => x.Id == id).FirstOrDefault(); // Recuperar do banco

    return _mapper.Map<ClienteDbModel, Cliente>(cliente);
}
```

### 1.5 Camada Anticorrupção

A camada de "Anticorrupção" (ou "Anticorruption Layer" em inglês) é um conceito importante dentro da Arquitetura de Domínio Driven (DDD). Essa camada tem o propósito de isolar o domínio do seu ambiente externo, protegendo-o contra influências indesejadas e garantindo que o domínio mantenha sua integridade e consistência.

A principal função da camada de Anticorrupção é traduzir e adaptar dados, conceitos e padrões entre o domínio, que é a parte central e crítica do sistema, e outros sistemas ou tecnologias externas que podem ter diferentes estruturas de dados, regras de negócios ou vocabulários. Isso é particularmente importante em sistemas complexos que precisam interagir com sistemas legados, serviços de terceiros, ou diferentes componentes que não seguem o mesmo modelo de domínio.

A camada de Anticorrupção é construída com o propósito de fornecer uma interface limpa e coerente para o domínio, permitindo que ele opere de forma independente e focada em seu próprio contexto. Além disso, essa camada ajuda a reduzir o acoplamento entre o domínio e os elementos externos, facilitando a manutenção e evolução do sistema.

