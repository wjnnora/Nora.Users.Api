# Stage 1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /src

COPY ./*.sln .
COPY ./nuget.config .
COPY ./Nora.Users.Api/Nora.Users.Api.csproj/ Nora.Users.Api/
COPY ./Nora.Users.Domain/Nora.Users.Domain.csproj/ Nora.Users.Domain/
COPY ./Nora.Users.Domain.Command/Nora.Users.Domain.Command.csproj/ Nora.Users.Domain.Command/
COPY ./Nora.Users.Domain.Query/Nora.Users.Domain.Query.csproj/ Nora.Users.Domain.Query/
COPY ./Nora.Users.Grpc/Nora.Users.Grpc.csproj/ Nora.Users.Grpc/
COPY ./Nora.Users.Infrastructure.Database/Nora.Users.Infrastructure.Database.csproj/ Nora.Users.Infrastructure.Database/

RUN dotnet restore
COPY . .

WORKDIR /src
RUN dotnet publish -c Release -o /app

# Stage 2

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8081

ENTRYPOINT ["dotnet", "Nora.Users.Api.dll"]