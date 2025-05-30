# Banco-Cem100

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-Core-green?logo=database)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux-blue)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-orange)

Projeto desenvolvido como parte de um desafio técnico bancário, com o objetivo de criar uma **API REST para transferência bancária**, utilizando .NET 8 e Entity Framework Core.

O desafio propõe o desenvolvimento de uma aplicação backend que permita **criar contas bancárias, realizar transferências entre contas e consultar saldos**, seguindo boas práticas de arquitetura e organização em camadas.

## 🛠️ Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- C#
- MySQL
- RESTful API

## 📁 Estrutura do Projeto

- **Controllers/** – Contém os controladores responsáveis por receber as requisições HTTP.
- **DTOs/** – Objetos de Transferência de Dados usados para comunicação entre camadas.
- **Models/** – Modelos que representam as entidades do banco de dados.
- **Mappers/** – Convertem entre Models e DTOs.
- **Services/** – Regras de negócio e lógica de aplicação.
- **Utils/** – Funções auxiliares para apoio ao projeto.
- **Database/** – Scripts e arquivos relacionados à base de dados.
- **Migrations/** – Migrações geradas pelo EF Core.

