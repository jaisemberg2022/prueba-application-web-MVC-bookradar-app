# 📦BookRadarApp - Apicacion Web MVC con Clean Architecture (.NET 8 + EF Core + Bootstrap 5)

## 📚 Descripción General

Este proyecto está estructurado siguiendo el enfoque de **Clean Architecture**, implementando el **patrón repositorio**, con el objetivo de construir un sistema **escalable, entendible, legible y mantenible**.

### 🧱 Arquitectura

El código se organiza en capas bien definidas:

- **Dominio**: Contiene las entidades del negocio y sus contratos.
- **Aplicación**: Define los casos de uso y las interfaces que interactúan con el dominio.
- **Infraestructura (Repositorio)**: Implementación concreta del acceso a datos mediante Entity Framework Core.
- **Web / Presentación**: Proyecto ASP.NET (MVC y Razor Pages) que sirve como interfaz de usuario.

> El mapeo de entidades se realiza mediante **Fluent API**, evitando el uso de Data Annotations como implementacion de buenas practicas.

El frontend está potenciado con **Bootstrap 5**, proporcionando una interfaz moderna, responsiva y sencilla.

---

## 🛠️ Requisitos Previos

Asegúrate de tener instalados los siguientes componentes:

- [.NET SDK 8.0.0](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express o LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/)
- Visual Studio 2022 o [Visual Studio Code](https://code.visualstudio.com/)

---
## 📦 Paquetes NuGet Utilizados
---

Este proyecto utiliza los siguientes paquetes NuGet clave para la configuración de Entity Framework Core y el acceso a datos con SQL Server:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
````

## 📥 Instalación y Configuración

### 1. Clonar el repositorio

```code
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo
````

### 2.  Restaurar los paquetes NuGet
```bash
dotnet restore
npm install --prefix BookRadarApp.Client
````
### 3.  Aplicar migraciones y generar base de datos
```bash
dotnet ef database update --project BookRadarApp
````

