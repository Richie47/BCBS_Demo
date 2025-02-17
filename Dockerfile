FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /BCBS-Demo

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "./DotNet.Docker.csproj"
# Build and publish a release
RUN dotnet publish -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
EXPOSE 8081
WORKDIR /BCBS-Demo
COPY --from=build /BCBS-Demo/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]