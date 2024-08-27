FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
ENV DOTNET_ENVIRONMENT="Production"
RUN dotnet build
ENTRYPOINT [ "dotnet", "run" ]