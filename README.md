# 🧒💉 VacinasInfantis.API

API REST desenvolvida para auxiliar no controle da vacinação infantil, com foco no **alerta aos responsáveis** sobre vacinas pendentes, atuais e futuras, baseado no calendário vacinal brasileiro. Um projeto com propósito social que une tecnologia e saúde pública.

---

## 🚀 Objetivo

O projeto tem como principal meta **lembrar os pais sobre a vacinação das crianças**, promovendo a prevenção e salvando vidas. Por meio de notificações por e-mail, os responsáveis são alertados sobre as vacinas que a criança deve tomar no mês atual ou no mês seguinte.

---

## 🛠️ Tecnologias Utilizadas

- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- AutoMapper
- xUnit (Testes Unitários)
- Swagger e Postman (Documentação)
- Bogus (Requisições Fakes)
- Shoudle (Testes Unitários)
- Validações com FluentValidation
- Envio de e-mails com HTML personalizado

---

## 📁 Organização do Projeto

- `VacinasInfantis.API`: Camada principal da API (Controllers, Program.cs, appsettings)
- `VacinasInfantis.Aplicacao`: Regras de negócio e casos de uso
- `VacinasInfantis.Comunicacao`: Modelos de requisições e respostas
- `VacinasInfantis.Domain`: Entidades e repositórios
- `VacinasInfantis.Infraestrutura`: Implementações específicas (e-mail, banco etc)
- `testes`: Testes unitários com xUnit

---

## 📌 Funcionalidades

### 👶 Crianças

- **POST** `/api/v1/criancas/registrar`  
  Registra uma criança com nome, data de nascimento, nome da mãe, nome do pai (opcional) e e-mail do responsável (com validações robustas).

- **GET** `/api/v1/criancas/listar`  
  Lista todas as crianças registradas.

- **PUT** `/api/v1/criancas/atualizar/{idCrianca}`  
  Atualiza os dados de uma criança específica.

- **DELETE** `/api/v1/criancas/deletar/{idCrianca}`  
  Remove uma criança do sistema.

---

### 🏥 Enfermagem

- **POST** `/api/v1/enfermagem/registrar`  
  Registra um profissional de enfermagem (auxiliar ou técnico) com validações completas.

- **GET** `/api/v1/enfermagem/listar`  
  Lista todos os profissionais registrados.

- **GET** `/api/v1/enfermagem/listar-profissional-aplicador/{idProfissional}`  
  Verifica se o profissional já aplicou alguma vacina e exibe os dados.

- **PUT** `/api/v1/enfermagem/atualizar/{idProfissional}`  
  Atualiza os dados de um profissional.

- **DELETE** `/api/v1/enfermagem/deletar/{idProfissional}`  
  Remove um profissional do sistema.

---

### 💉 Vacinas

- **POST** `/api/v1/vacinas/registrar/{idCrianca}`  
  Registra uma vacina para uma criança específica (usando o ID dela).

- **GET** `/api/v1/vacinas/listar`  
  Lista todas as vacinas do calendário (0 a 48 meses).

- **GET** `/api/v1/vacinas/listar/{idCrianca}`  
  Mostra todas as vacinas aplicadas e previstas de uma criança.

- **GET** `/api/v1/vacinas/listar-vacinasAtuais/{idCrianca}`  
  Mostra as vacinas do mês atual com base na idade da criança.

- **GET** `/api/v1/vacinas/listar-vacinasMesSeguinte/enviarNotificacao/{idCrianca}`  
  Envia uma notificação por e-mail sobre as vacinas do próximo mês.

- **PUT** `/api/v1/vacinas/atualizar-vacinas/{idCrianca}/{idVacina}`  
  Atualiza o registro de uma vacina de uma criança específica.

- **DELETE** `/api/v1/vacinas/deletar-vacinas/{idCrianca}/{idVacina}`  
  Remove o registro de uma vacina específica.

---

## 🧪 Testes

- Testes automatizados com **xUnit**
- Cobertura para regras de negócios e validações
- Simulação de cenários reais com `Fakers`

---

## 🧠 Motivação Pessoal

> _"Meu projeto foi desenvolvido acima de muita insegurança e medo, mas mantive perseverança e fé na minha capacidade. Mesmo em dias que nenhuma ideia surgia, eu continuei. A ideia principal é alertar os pais para não esquecerem da vacinação infantil. A vacina salva vidas e o conhecimento é poder. Com a tecnologia, podemos fazer a diferença na população."_ 💪❤️

---
