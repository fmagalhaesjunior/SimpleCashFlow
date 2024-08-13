# SimpleCashFlow
Este projeto implementa uma solução para controlar o fluxo de caixa diário de um comerciante, gerenciando lançamentos de débitos e créditos e fornecendo um relatório de saldo diário consolidado.

## Sumário

- [Descrição](#descrição)
- [Arquitetura](#arquitetura)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Uso](#uso)
- [Testes](#testes)
- [Escalabilidade](#escalabilidade)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Descrição

O sistema é composto por dois serviços principais:

1. **Serviço de Controle de Lançamentos**: Responsável por gerenciar os lançamentos de débitos e créditos.
2. **Serviço de Consolidado Diário**: Responsável por calcular e fornecer o saldo diário consolidado com base nos lançamentos.

O sistema é projetado para ser escalável e resiliente, suportando picos de até 500 requisições por segundo no serviço de consolidado diário, com no máximo 5% de perda.

## Arquitetura

A arquitetura do sistema é baseada em microsserviços e inclui:

- **Backend**: .NET Core 8
- **Banco de Dados**: PostgreSQL
- **Mensageria**: RabbitMQ
- **Orquestração e Contêineres**: Docker e Docker Compose
- **Escalabilidade (Opcional)**: Kubernetes

### Diagrama de Arquitetura

[descrição da Arquitetura](descricao.txt)

## Pré-requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados em sua máquina:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [PostgreSQL](https://www.postgresql.org/download/)

## Instalação

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/fluxo-caixa-diario.git
   cd fluxo-caixa-diario
   ```
2. Configure as variáveis de ambiente:
   Crie um arquivo .env na raiz do projeto e adicione as seguintes variáveis:
     POSTGRES_DB=finance
     POSTGRES_USER=user
     POSTGRES_PASSWORD=password

3. Construa e suba os contêineres:
  ```bash
   docker-compose up --build
  ```

4. Acesse o sistema:
   O serviço de controle de lançamentos estará disponível em http://localhost:5000 e o serviço de consolidado diário em http://localhost:5001.

