
# 🧪 API REST .NET 8 + SQL Server + Docker + GitHub Codespaces

Este proyecto es una base lista para usar en pruebas técnicas o desarrollo rápido con:
- ✅ ASP.NET Core 8 Web API
- ✅ Entity Framework Core
- ✅ SQL Server en contenedor Docker
- ✅ GitHub Codespaces (entorno listo en la nube)
- ✅ Pruebas unitarias con xUnit
- ✅ Precarga de datos iniciales

---

## 🚀 Requisitos

- Cuenta gratuita en GitHub
- Usar GitHub Codespaces (recomendado)
- Docker Desktop (opcional para correr local)

---

## ⚙️ ¿Cómo iniciar en GitHub Codespaces?

1. **Haz clic en "Use this template"** o sube el proyecto a tu repositorio
2. En tu repo, haz clic en el botón verde **"Code" → "Codespaces" → "Create codespace on main"**
3. Espera 1-2 minutos mientras se construye el entorno
4. En la terminal integrada, corre estos comandos:

```bash
dotnet ef migrations add Init
dotnet ef database update
dotnet run
```

5. Abre la URL generada por Codespaces para acceder a Swagger UI y probar la API

---

## 🗃️ Endpoints de la API

| Método | Ruta                         | Descripción                     |
|--------|------------------------------|---------------------------------|
| GET    | /api/login                   | Lista todos los usuarios        |
| POST   | /api/login/register          | Registra un nuevo usuario       |
| POST   | /api/login/login             | Login con email y password      |
| POST   | /api/login/logout/{id}       | Logout por ID                   |
| DELETE | /api/login/{id}              | Elimina un usuario              |

---

## 🧪 Pruebas Unitarias

Las pruebas están en el proyecto `LoginApi.Tests`. Para ejecutarlas:

```bash
dotnet test
```

---

## 🔐 Usuarios pre-cargados

Los siguientes usuarios se insertan al correr la API:

- `admin@example.com` / `adminpass`
- `user1@example.com` / `userpass`

---

## 🛠️ Herramientas

- `.NET 8 SDK`
- `SQL Server 2022 (Docker)`
- `Entity Framework Core`
- `xUnit`

---

## 🧼 Notas

- El contenedor de SQL Server se levanta con `docker-compose up -d`
- Los datos se insertan automáticamente al iniciar la API si la base de datos está vacía
- Puedes usar Postman, Swagger o curl para probar los endpoints

---
