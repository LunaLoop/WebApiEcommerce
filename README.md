# 🛒 WebApiEcommerce

Una API RESTful para una tienda virtual construida con **ASP.NET Core 8.0**, **Entity Framework Core** y **MySQL**.

## 📚 Descripción

Este proyecto permite gestionar productos, pedidos, clientes y facturación para un sistema de comercio electrónico. Incluye conexión a base de datos MySQL y soporte para Swagger (documentación automática de la API).

---

## 🔧 Requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- Visual Studio 2022 (recomendado)
- Paquete NuGet: **Pomelo.EntityFrameworkCore.MySql**

---

## 📦 Instalación de Paquetes

Abre la Consola del Administrador de Paquetes de NuGet y ejecuta los siguientes comandos:
---
- Install-Package Microsoft.EntityFrameworkCore -Version 8.0.3
- Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.3
- Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.3
- Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.0


> ⚠️ Asegúrate de tener seleccionado el proyecto correcto como *Startup Project* antes de ejecutar estos comandos.

---

## 🔌 Conexión a la Base de Datos

Para generar el contexto y los modelos desde tu base de datos MySQL, usa este comando:

Scaffold-DbContext "server=localhost;port=3306;uid=root;pwd=tu_contraseña;database=TiendaVirtual" Pomelo.EntityFrameworkCore.MySql -OutputDir Data -f -NoPluralize -Context TiendaVirtualContext
---

⚠️ Reemplaza `TU_CONTRASEÑA` con la contraseña real de tu usuario MySQL.

---
## 🧪 Prueba de Conexión

Puedes verificar si la conexión está funcionando accediendo a alguno de tus endpoints a través de Swagger. Al ejecutar el proyecto, se abrirá una pestaña en tu navegador con Swagger UI.

---

## 🚀 ¿Cómo correr la API?

1. Asegúrate de que la base de datos está corriendo.
2. Ejecuta el proyecto en Visual Studio (F5 o Ctrl+F5).
3. Accede a Swagger en: `https://localhost:PORT/swagger`

---

## ✍️ Autores

Desarrollado por [Diamara Muñoz - Rene Oruño] – 2025









