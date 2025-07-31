# Use the official .NET 8 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy csproj file and restore dependencies
COPY Feediary/Feediary.csproj ./Feediary/
WORKDIR /src/Feediary
RUN dotnet restore

# Copy the entire project and build
WORKDIR /src
COPY . .
WORKDIR /src/Feediary
RUN dotnet build "Feediary.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "Feediary.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 8 runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copy the published application
COPY --from=build /app/publish .

# Create a non-root user for security
RUN groupadd -r feediary && useradd -r -g feediary feediary
RUN chown -R feediary:feediary /app
USER feediary

# Expose port 8080 (default for ASP.NET Core in containers)
EXPOSE 8080

# Set environment variables for production
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Feediary.dll"]