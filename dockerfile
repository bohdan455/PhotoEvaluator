FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/runtime:6.0
COPY --from=build-env /out .

ENTRYPOINT ["dotnet", "TGBot.dll"]