# arquitetura-micro-servicos
Trabalhando com arquitetura de micro serviço c# e docker

## Gerador a imagem dotnet 6
- Abra o terminal no diretorio do Docker file e execute o comando:
``docker build -t dotnet .``

- Após gerar o build da imagem inicie um novo container:
``docker-composer up -d``

- acesse o container criado

- acessar o projeto GeekShopping.ProductAPI e rodar migration do dotnet 
``dotnet ef database update``

- será necessario criar o banco identity-server

- acessar o projeto GeekShopping.IdentityServer e rodar migration do dotnet 
``dotnet ef database update``
