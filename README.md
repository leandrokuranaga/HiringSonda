# HiringSonda

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge\&logo=microsoft-sql-server\&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge\&logo=visual-studio\&logoColor=white)
![Windows 11](https://img.shields.io/badge/Windows%2011-0078D6?style=for-the-badge\&logo=windows\&logoColor=white)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)

---

## 🎬 Application

See the video below:

[![YoutubeVideo](src/HiringSonda.Api/wwwroot/assets/Sonda.png)](https://www.youtube.com/watch?v=pjoMfjlkklA)

---

## 🛠️ Tools & Database

To use and test the application, run the following:

```bash
git clone https://github.com/lekuranaga/HiringSonda.git
```

* Developed on **Windows 11**.
* Database: **SQL Server Express 2019**
* IDE: **Visual Studio 2022**
* Database name: `SondaLeandroKuranaga` (configurable in `appsettings.json`)

---

## 🧱 Project Architecture

The project uses **Onion Architecture**, with the following structure:

* ✅ **HiringSonda**: Controllers and Views (Presentation Layer)
* 🧠 **HiringSonda.Domain**: Business rules, Interfaces, and Models (Domain Layer)
* 💾 **HiringSonda.Infra**: DB Context, Mappings, Migrations, Repositories (Infrastructure Layer)

Entity Framework Core packages used:

* `Design`
* `Relational`
* `SqlServer`
* `Tools`

Migration created using:

```bash
add-migration SondaHiring
```

Database diagram:

![UML Diagram](src/HiringSonda.Api/wwwroot/assets/Banco.png)

Connection string example:

```
(localdb)\MSSQLLocalDB
```

Authentication: Windows Auth (compatible with SQL Server 2017 and 2019)

---

## 🔗 Dependencies

* `HiringSonda.Infra` depends on `HiringSonda.Domain`
* `HiringSonda` (application layer) depends on both `HiringSonda.Domain` and `HiringSonda.Infra`

---

## 📜 License

This project is licensed under the MIT License.
