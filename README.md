## Arquitetura do Projeto – SinglePaymentAPI
A SinglePaymentAPI segue uma arquitetura baseada nos princípios Clean Architecture e Separation of Concerns (SoC). O projeto está dividido em camadas bem definidas, com responsabilidades separadas, visando facilitar a manutenção, a testabilidade e a escalabilidade da aplicação.

### 🧭 Visão Geral
A estrutura do projeto está organizada da seguinte forma:

SinglePaymentAPI/
├── Controllers/
├── Data/
├── Mappers/
├── Migrations/
├── Models/
├── Properties/
├── Services/
├── Utils/

### Controllers/
Responsáveis por receber as requisições HTTP e delegar as operações para os serviços. Nesta API, temos:

TransferController.cs: Gerencia operações relacionadas a transferências financeiras.

WalletController.cs: Controla as ações relacionadas a carteiras digitais dos usuários.

### Data/
Contém a camada de persistência de dados e o contexto da aplicação.

ApplicationDbContext.cs: Classe de contexto que representa a conexão com o banco de dados, utilizando Entity Framework Core.

Repository/: Implementa o padrão Repository, isolando a lógica de acesso a dados.

Transfers/: Interfaces e classes de implementação do repositório de transferências.

ITransferRepository.cs

TransferRepository.cs

Wallets/: Interfaces e classes de repositório para carteiras digitais.

IWalletRepository.cs

WalletRepository.cs

### Mappers/
TransferMapper.cs: Responsável por converter entidades em DTOs (e vice-versa), promovendo a separação entre os modelos de banco e os objetos de transporte de dados.

### Migrations/
Contém os arquivos gerados automaticamente pelo Entity Framework Core para versionamento e aplicação das alterações no esquema do banco de dados.

### Models/
Contém todas as classes relacionadas a estrutura de dados da aplicação:

DTOs/: Objetos de Transferência de Dados usados entre camadas (ex: TransferDTO.cs).

Enum/: Enumerações utilizadas em diferentes partes do sistema (ex: UserType.cs).

Requests/: Representações das entradas das requisições (ex: TransferRequest.cs, WalletRequest.cs).

Responses/: Contém Result.cs, estrutura padrão de resposta da API com informações sobre sucesso ou falha.

TransferEntity.cs e WalletEntity.cs: Entidades do domínio mapeadas para o banco de dados via EF Core.

### Services/
Camada de serviços, onde reside a lógica de negócio da aplicação.

Authorizer/: Serviço para autorização de operações financeiras.

AuthorizerServices.cs, IAuthorizerServices.cs

Notifications/: Serviço para envio de notificações relacionadas às transações.

NotificationServices.cs, INotificationServices.cs

Transfers/: Contém a lógica de negócio relacionada às transferências.

TransferServices.cs, ITransferServices.cs

Wallets/: Lógica de criação, atualização e controle de carteiras digitais.

WalletServices.cs, IWalletServices.cs

### Utils/
SSNEINValidator.cs: Validador de números SSN/EIN (utilizado para validações de identidade fiscal).

SsnOrEinValidationAttribute.cs: Atributo customizado para validação automática de SSN/EIN em requisições.

### Properties/
launchSettings.json: Arquivo de configuração de ambiente de execução local no Visual Studio.

