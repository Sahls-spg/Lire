# Projeto Lire

Sistema desenvolvido para ajudar pessoas a desenvolverem ou manterem o hábito da leitura por meio de recomendações personalizadas, planos de leitura e biblioteca pessoal.

## Motivação

O projeto surgiu a partir da minha paixão pela leitura e da minha percepção de algumas dificuldades enfrentadas por leitores, como encontrar livros de acordo com seus interesses e manter uma rotina de leitura.

A partir disso, o Lire foi desenvolvido com o objetivo de centralizar essas necessidades e tornar a experiência de leitura mais organizada e personalizada.

## Arquitetura

A arquitetura utilizada no projeto é a **Arquitetura em Camadas**, dividida nas seguintes camadas:

- **Domínio** — Responsável pelas entidades e enumeradores.
- **Repositório** — Responsável pelo acesso e persistência dos dados.
- **Aplicação** — Responsável pelas regras de negócio.
- **API** — Responsável pelos endpoints e por receber as requisições do frontend.
- **Service** — Responsável pela integração com serviços externos.

## Tecnologias Utilizadas

### Backend

- C#
- .NET
- SQL Server
- Entity Framework Core
- Dapper

### Frontend

- JavaScript
- HTML
- CSS
- React

