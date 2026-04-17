# 🛒 Minha Lojinha API - Minicurso C# (Aula 4)

![.NET Core](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=black)

> Repositório oficial do minicurso "Introdução ao Backend Profissional". Na Aula 4, atingimos um padrão voltado ao mercado de trabalho: blindamos a nossa API para não expor o Banco de Dados à internet.

---

## Sobre a Evolução do Projeto

Na [Aula 3](https://github.com/joseHenrique346/MinhaLojinhaAPI-Terceira-Aula), conectamos nossas tabelas, mas acabamos utilizando "band-aids", como o atributo `[JsonIgnore]` e o `IgnoreCycles`, para evitar bugs de loop infinito na hora de exibir os dados no Swagger.

Nesta **Aula 4**, nós removemos essas soluções temporárias e introduzimos o padrão definitivo de mercado: os **DTOs (Data Transfer Objects)**. Agora, nossa API separa estritamente as Entidades (que vivem apenas no banco de dados) dos objetos que trafegam na Internet (DTOs). Nossa `Controller` virou uma verdadeira "catraca", repassando a validação pesada exclusivamente para a camada de `Service`.

## Novidades e Refatorações (Aula 4)

- [x] Remoção dos "band-aids" (`[JsonIgnore]` e limitadores de ciclo no JSON).
- [x] Criação da estrutura de **DTOs** para Entrada (`CreateDTO`, `UpdateDTO`) e Saída (`ResponseDTO`).
- [x] Uso avançado do **`implicit operator`** no C# para conversão mágica e limpa entre Entidades de Domínio e DTOs de resposta.
- [x] Adição das propriedades `Stock` (Estoque) e `Price` (Preço) na entidade `Product`.
- [x] Refatoração das Controllers para atuarem no padrão *Application Service* (Recebe DTO -> Processa no Service -> Devolve DTO).

---

## Estrutura de Pastas Atualizada

Nossa arquitetura finalizada e blindada ficou assim:
```text
MinhaLojinha/
├── Controllers/      # A catraca: agora só recebe e devolve DTOs. Não conhece Entidades!
├── DTOs/             # NOVA PASTA: Nossos "crachás" (Ex: CreateProductDTO.cs, ProductResponseDTO.cs)
├── Interface/        # Contratos atualizados exigindo DTOs no tráfego de dados
├── Models/           # Entidades de Domínio puras (com Estoque e Preço)
├── Repository/       # Acesso seguro ao banco de dados SQLite
├── Services/         # O cérebro: Valida o DTO, cria a Entidade, aplica Regras de Venda e Salva
└── Program.cs        # Configuração do motor e Injeção de Dependências
```
--- 
Projeto construído do zero à uma Arquitetura Limpa e escalável durante o Minicurso.
