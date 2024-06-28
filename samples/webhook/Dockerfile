FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as base 

# CREATE AND CD INTO DIR
WORKDIR /src

EXPOSE 5000
EXPOSE 5001

# SETUP PRODUCTION ENV
ENV ASPNETCORE_URLS=http://+:5000

# SECOND STAGE
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as builder

WORKDIR /src

COPY ./webhook.csproj ./webhook.csproj

RUN dotnet restore "./webhook.csproj"

COPY . .

RUN dotnet build "./webhook.csproj" -c Release -o ./build

# THIRD STAGE BUILD
FROM builder as publish

RUN dotnet publish "./webhook.csproj" -c Release -o ./publish

FROM base as final

RUN apk update && \
    apk add --no-cache tzdata

ENV TZ=Asia/Bangkok

WORKDIR /src

# COPY --from=builder /src/efbundle ./

COPY --from=publish /src/publish ./

CMD ["dotnet", "webhook.dll"]